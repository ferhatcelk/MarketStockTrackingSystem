#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
============================================================
  Market Stok Takip Sistemi  —  Veri Analiz Modülü
  Dosya : scripts/analiz.py
  Yazar : Ferhat Çelik
  Tarih : 2026-07-04

  Açıklama:
    Bu betik, C# Windows Forms uygulamasından JSON formatında
    ihraç edilen stok verilerini okuyarak aşağıdaki analizleri
    gerçekleştirir:

      1. Temel istatistikler (ürün sayısı, kategori, toplam değer)
      2. Düşük stok uyarısı
      3. Kategori bazlı stok dağılımı
      4. Hareket geçmişi özeti
      5. Kâr potansiyeli hesabı
      6. Metin tabanlı çubuk grafik (terminalde görüntülenebilir)

  Kullanım:
      python analiz.py                         # varsayılan veri dosyası
      python analiz.py --dosya <yol/dosya.json>
      python analiz.py --esik 10               # düşük stok eşiği

  Gereksinimler:
      Python 3.7+  (ek kütüphane gerekmez)
============================================================
"""

import json
import os
import sys
import argparse
from datetime import datetime
from collections import defaultdict, Counter


# ── Sabitler ─────────────────────────────────────────────────────────

VARSAYILAN_DOSYA = os.path.join(
    os.path.dirname(__file__), "..", "data", "ornek_veri.json"
)
DUSUK_STOK_ESIGI_DEFAULT = 5

# Konsol renkleri (Windows CMD/PowerShell desteği için ANSI)
class R:
    SIFIRLA  = "\033[0m"
    KALIN    = "\033[1m"
    KIRMIZI  = "\033[91m"
    YESIL    = "\033[92m"
    SARI     = "\033[93m"
    MAVI     = "\033[94m"
    VIOLET   = "\033[95m"
    CYAN     = "\033[96m"
    BEYAZ    = "\033[97m"

def _renkli(metin: str, renk: str) -> str:
    """Terminal renk çıktısı (renk yoksa düz metin)."""
    try:
        import sys
        if sys.platform == "win32":
            os.system("color")   # Windows'ta ANSI etkinleştir
        return f"{renk}{metin}{R.SIFIRLA}"
    except Exception:
        return metin


# ── Veri Yükleme ─────────────────────────────────────────────────────

def veri_yukle(dosya_yolu: str) -> dict:
    """JSON dosyasından stok verilerini yükler."""
    if not os.path.exists(dosya_yolu):
        print(_renkli(f"HATA: Dosya bulunamadı → {dosya_yolu}", R.KIRMIZI))
        sys.exit(1)

    with open(dosya_yolu, encoding="utf-8") as f:
        veri = json.load(f)

    return veri


# ── Temel İstatistikler ───────────────────────────────────────────────

def temel_istatistikler(veri: dict) -> dict:
    """Toplam ürün, stok ve değer hesaplamalarını döndürür."""
    urunler = veri.get("urunler", [])

    toplam_stok      = sum(u["stok"] for u in urunler)
    alis_degeri      = sum(u["alis_fiyat"] * u["stok"] for u in urunler)
    satis_degeri     = sum(u["satis_fiyat"] * u["stok"] for u in urunler)
    kar_potansiyeli  = satis_degeri - alis_degeri

    fiyatlar = [u["satis_fiyat"] for u in urunler]
    ort_fiyat = sum(fiyatlar) / len(fiyatlar) if fiyatlar else 0

    return {
        "urun_sayisi"     : len(urunler),
        "kategori_sayisi" : len(veri.get("kategoriler", [])),
        "toplam_stok"     : toplam_stok,
        "alis_degeri"     : alis_degeri,
        "satis_degeri"    : satis_degeri,
        "kar_potansiyeli" : kar_potansiyeli,
        "ortalama_fiyat"  : round(ort_fiyat, 2),
    }


# ── Düşük Stok Analizi ────────────────────────────────────────────────

def dusuk_stok_analizi(veri: dict, esik: int) -> list:
    """Belirtilen eşiğin altındaki ürünleri listeler."""
    return [
        u for u in veri.get("urunler", [])
        if u["stok"] <= esik
    ]


# ── Kategori Bazlı Dağılım ────────────────────────────────────────────

def kategori_dagilimi(veri: dict) -> dict:
    """Kategori başına toplam stok miktarını hesaplar."""
    kat_adlari = {k["id"]: k["ad"] for k in veri.get("kategoriler", [])}
    dagilim    = defaultdict(int)

    for u in veri.get("urunler", []):
        kat_id   = u.get("kategori_id", 0)
        kat_adi  = kat_adlari.get(kat_id, f"Kategori-{kat_id}")
        dagilim[kat_adi] += u["stok"]

    return dict(sorted(dagilim.items(), key=lambda x: x[1], reverse=True))


# ── Hareket Geçmişi Analizi ───────────────────────────────────────────

def hareket_analizi(veri: dict) -> dict:
    """İşlem türüne göre hareket sayılarını özetler."""
    hareketler = veri.get("stok_hareketleri", [])
    tur_sayac  = Counter(h["islem"] for h in hareketler)

    # Bugünkü hareketler
    bugun = datetime.today().date()
    bugun_sayisi = sum(
        1 for h in hareketler
        if datetime.fromisoformat(h["tarih"]).date() == bugun
    )

    return {
        "toplam_hareket" : len(hareketler),
        "tur_dagilimi"   : dict(tur_sayac),
        "bugun_sayisi"   : bugun_sayisi,
    }


# ── Metin Tabanlı Bar Grafik ──────────────────────────────────────────

def bar_grafik(veri: dict, baslik: str, maks_uzunluk: int = 40) -> str:
    """Terminalde görüntülenebilir ASCII bar grafiği oluşturur."""
    if not veri:
        return "(Veri yok)"

    maks_deger = max(veri.values()) or 1
    satirlar   = [f"\n  {_renkli(baslik, R.KALIN + R.CYAN)}\n"]

    for anahtar, deger in veri.items():
        bar_uzunluk = int((deger / maks_deger) * maks_uzunluk)
        bar  = "█" * bar_uzunluk
        bos  = "░" * (maks_uzunluk - bar_uzunluk)
        satir = (
            f"  {anahtar:<20} "
            f"{_renkli(bar, R.VIOLET)}{_renkli(bos, R.BEYAZ)}  "
            f"{_renkli(str(deger), R.SARI)}"
        )
        satirlar.append(satir)

    return "\n".join(satirlar)


# ── Rapor Çıktısı ─────────────────────────────────────────────────────

def rapor_yazdir(veri: dict, istatistikler: dict, esik: int) -> None:
    """Konsola biçimlendirilmiş rapor yazar."""
    sep = "─" * 60

    # Başlık
    print()
    print(_renkli("╔══════════════════════════════════════════════════════════╗", R.VIOLET))
    print(_renkli("║      Market Stok Takip Sistemi  —  Veri Analiz Raporu   ║", R.VIOLET))
    print(_renkli("╚══════════════════════════════════════════════════════════╝", R.VIOLET))
    print(f"  Rapor Tarihi : {_renkli(datetime.now().strftime('%d.%m.%Y %H:%M:%S'), R.CYAN)}")
    print(f"  Veri Kaynağı : {_renkli(veri.get('meta', {}).get('sistem', '—'), R.CYAN)}")
    print(sep)

    # Temel istatistikler
    print(_renkli("\n  📊  TEMEL İSTATİSTİKLER\n", R.KALIN))
    satırlar = [
        ("Toplam Ürün Sayısı",    f"{istatistikler['urun_sayisi']} ürün"),
        ("Toplam Kategori",       f"{istatistikler['kategori_sayisi']} kategori"),
        ("Toplam Stok (adet)",    f"{istatistikler['toplam_stok']} adet"),
        ("Alış (Maliyet) Değeri", f"₺ {istatistikler['alis_degeri']:,.2f}"),
        ("Satış (Piyasa) Değeri", f"₺ {istatistikler['satis_degeri']:,.2f}"),
        ("Kâr Potansiyeli",       f"₺ {istatistikler['kar_potansiyeli']:,.2f}"),
        ("Ortalama Satış Fiyatı", f"₺ {istatistikler['ortalama_fiyat']:.2f}"),
    ]
    for etiket, deger in satırlar:
        print(f"  {etiket:<26} : {_renkli(deger, R.YESIL)}")

    # Düşük stok uyarısı
    print(f"\n{sep}")
    dusuk = dusuk_stok_analizi(veri, esik)
    print(_renkli(f"\n  ⚠️   DÜŞÜK STOK UYARISI  (eşik: ≤ {esik})\n", R.KALIN))

    if not dusuk:
        print(_renkli(f"  ✅  Tüm ürünler {esik} adetten fazla stokta.", R.YESIL))
    else:
        print(f"  {'Ürün Adı':<25} {'Barkod':<16} {'Stok':>6}")
        print(f"  {'─'*25} {'─'*16} {'─'*6}")
        for u in dusuk:
            stok_str = _renkli(f"{u['stok']:>6}", R.KIRMIZI if u["stok"] == 0 else R.SARI)
            print(f"  {u['ad']:<25} {u['barkod']:<16} {stok_str}")
        print(f"\n  {_renkli(str(len(dusuk)), R.KIRMIZI)} ürün düşük stok uyarısında.")

    # Kategori dağılımı grafiği
    print(f"\n{sep}")
    kat_dagilim = kategori_dagilimi(veri)
    print(bar_grafik(kat_dagilim, "  📦  KATEGORİ BAZLI STOK DAĞILIMI (adet)"))

    # Hareket analizi
    print(f"\n{sep}")
    har = hareket_analizi(veri)
    print(_renkli("\n  📋  HAREKET GEÇMİŞİ ÖZETİ\n", R.KALIN))
    print(f"  Toplam Hareket Sayısı : {_renkli(str(har['toplam_hareket']), R.CYAN)}")
    print(f"  Bugünkü İşlemler      : {_renkli(str(har['bugun_sayisi']), R.CYAN)}")
    print()
    for tur, sayi in har["tur_dagilimi"].items():
        icon = {"Ekleme": "🟢", "Güncelleme": "🟡", "Silme": "🔴"}.get(tur, "⚪")
        print(f"  {icon}  {tur:<14} : {_renkli(str(sayi), R.YESIL)} işlem")

    print(f"\n{sep}")
    print(_renkli("  ✔  Analiz tamamlandı.\n", R.YESIL))


# ── JSON Raporu Kaydet ────────────────────────────────────────────────

def rapor_kaydet(istatistikler: dict, dusuk: list, dagilim: dict,
                  hareket: dict, cikti_dosyasi: str) -> None:
    """Analiz sonuçlarını JSON dosyasına kaydeder."""
    rapor = {
        "olusturma_tarihi": datetime.now().isoformat(),
        "temel_istatistikler": istatistikler,
        "dusuk_stok_urunleri": [
            {"ad": u["ad"], "barkod": u["barkod"], "stok": u["stok"]}
            for u in dusuk
        ],
        "kategori_stok_dagilimi": dagilim,
        "hareket_ozeti": hareket,
    }

    with open(cikti_dosyasi, "w", encoding="utf-8") as f:
        json.dump(rapor, f, ensure_ascii=False, indent=2)

    print(f"  Rapor kaydedildi → {_renkli(cikti_dosyasi, R.CYAN)}")


# ── Argüman Ayrıştırıcı ───────────────────────────────────────────────

def arguman_ayristir() -> argparse.Namespace:
    parser = argparse.ArgumentParser(
        description="Market Stok Takip Sistemi — Veri Analiz Aracı",
        formatter_class=argparse.RawDescriptionHelpFormatter,
        epilog="""
Örnekler:
  python analiz.py
  python analiz.py --dosya ../data/ornek_veri.json --esik 10
  python analiz.py --kaydet rapor_cikti.json
        """
    )
    parser.add_argument(
        "--dosya", "-d",
        default=VARSAYILAN_DOSYA,
        help="JSON veri dosyası yolu (varsayılan: data/ornek_veri.json)"
    )
    parser.add_argument(
        "--esik", "-e",
        type=int,
        default=DUSUK_STOK_ESIGI_DEFAULT,
        help=f"Düşük stok uyarı eşiği (varsayılan: {DUSUK_STOK_ESIGI_DEFAULT})"
    )
    parser.add_argument(
        "--kaydet", "-k",
        metavar="DOSYA",
        help="Analiz sonuçlarını JSON dosyasına kaydet"
    )
    return parser.parse_args()


# ── Ana Akış ─────────────────────────────────────────────────────────

def main() -> None:
    args = arguman_ayristir()

    # Veri yükle
    veri = veri_yukle(args.dosya)

    # Analizleri çalıştır
    istatistikler = temel_istatistikler(veri)
    dusuk         = dusuk_stok_analizi(veri, args.esik)
    dagilim       = kategori_dagilimi(veri)
    hareket       = hareket_analizi(veri)

    # Konsol raporu
    rapor_yazdir(veri, istatistikler, args.esik)

    # İsteğe bağlı JSON çıktısı
    if args.kaydet:
        rapor_kaydet(istatistikler, dusuk, dagilim, hareket, args.kaydet)


if __name__ == "__main__":
    main()
