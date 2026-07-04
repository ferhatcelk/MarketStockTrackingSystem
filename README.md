# Market Stok Takip Sistemi 🛒

<div align="center">

![Platform](https://img.shields.io/badge/Platform-Windows-0078D6?style=for-the-badge&logo=windows)
![Framework](https://img.shields.io/badge/.NET%20Framework-4.8-512BD4?style=for-the-badge&logo=dotnet)
![Language](https://img.shields.io/badge/C%23-100%25-239120?style=for-the-badge&logo=csharp)
![IDE](https://img.shields.io/badge/Visual%20Studio-2022-5C2D91?style=for-the-badge&logo=visualstudio)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

**Katmanlı mimari ve OOP prensiplerine uygun geliştirilmiş profesyonel Windows Forms uygulaması.**

[🌐 Web Sayfası](web/index.html) · [📊 Dashboard](#-özellikler) · [🐍 Python Analiz](#-python-analiz-aracı)

</div>

---

## 📋 İçindekiler

- [Proje Hakkında](#-proje-hakkında)
- [Özellikler](#-özellikler)
- [Ekran Görüntüleri](#-ekran-görüntüleri)
- [Mimari](#-mimari)
- [Teknoloji Yığını](#-teknoloji-yığını)
- [Klasör Yapısı](#-klasör-yapısı)
- [Kurulum & Çalıştırma](#-kurulum--çalıştırma)
- [Python Analiz Aracı](#-python-analiz-aracı)
- [Web Dokümantasyonu](#-web-dokümantasyonu)
- [Katkı Sağlama](#-katkı-sağlama)

---

## 🎯 Proje Hakkında

**Market Stok Takip Sistemi**, bir marketteki ürünlerin eklenmesini, stoklarının takibini,
güncellenmesini, silinmesini, aranmasını ve filtrelenmesini sağlayan kullanıcı dostu bir
Windows masaüstü uygulamasıdır.

Bu proje **üniversite bitirme ödevi** kapsamında geliştirilmiş olup aşağıdaki yazılım
geliştirme standartlarına uymaktadır:

- ✅ **SOLID** prensipleri
- ✅ **OOP** (Encapsulation, Inheritance, Polymorphism)
- ✅ **Katmanlı Mimari** (Presentation / Business / Data / Model)
- ✅ **Veri Yapıları**: `List<T>`, `Stack<T>`, `Queue<T>`, `Dictionary<K,V>`
- ✅ **Separation of Concerns** — İş mantığı formlardan tamamen ayrılmış

---

## ✨ Özellikler

### 📊 Dashboard
| Özellik | Açıklama |
|---------|----------|
| KPI Kartları | Toplam ürün, düşük stok, kategori sayısı, günlük işlem |
| Canlı Saat | Saniyede bir güncellenen tarih/saat gösterimi |
| Son Hareketler | İşlem türüne göre renk kodlu son 12 hareket |
| Stok Değeri | Alış, satış ve kâr potansiyeli hesabı |
| Düşük Stok Uyarısı | Eşiğin (≤10) altındaki ürünler otomatik listelenir |

### 📦 Ürün Yönetimi
- Barkod, ad, kategori, alış/satış fiyatı ve stok girişi
- Çift tıklama ile hızlı düzenleme
- Anlık arama (ad veya barkod)
- Kategori bazlı filtreleme
- Silme işleminde onay dialogu

### 🗂️ Kategori Yönetimi
- `Dictionary<int, Category>` yapısı üzerinde CRUD işlemleri
- Bağlı ürün varsa silme engeli
- Çift tıklama ile düzenleme kutusu doldurma

### 📋 Stok Hareketleri
- `Stack<StockMovement>` ile LIFO tabanlı kayıt
- Her işlemde (Ekleme 🟢 / Güncelleme 🟡 / Silme 🔴) otomatik hareket kaydı
- Tarih & saat damgası

---

## 📸 Ekran Görüntüleri

> Uygulamayı açarak veya `bin/Debug/MarketStokTakip.exe` çalıştırarak görebilirsiniz.

| Dashboard | Ürün Listesi |
|:---------:|:------------:|
| KPI kartları + Son hareketler | Arama, filtreleme, DataGridView |

| Kategori Yönetimi | Stok Hareketleri |
|:-----------------:|:----------------:|
| İki panelli düzen | Renkli hareket geçmişi |

---

## 🏗 Mimari

```
┌─────────────────────────────────────────────────────────────┐
│                    SUNUM KATMANI (Forms)                     │
│  MainForm · DashboardControl · ProductListControl           │
│  CategoryControl · StockMovementControl · ProductAddForm    │
└──────────────────────────┬──────────────────────────────────┘
                           │ çağırır
┌──────────────────────────▼──────────────────────────────────┐
│               İŞ MANTIĞI KATMANI (Services)                  │
│         ProductService · CategoryService                     │
│         StockMovementService                                 │
└──────────────────────────┬──────────────────────────────────┘
                           │ okur/yazar
┌──────────────────────────▼──────────────────────────────────┐
│                  VERİ KATMANI (Data)                         │
│              DataStore (Singleton Pattern)                   │
│   List<Product>  ·  Stack<StockMovement>                    │
│   Queue<Product> ·  Dictionary<int, Category>               │
└──────────────────────────┬──────────────────────────────────┘
                           │ modeller
┌──────────────────────────▼──────────────────────────────────┐
│                   MODEL KATMANI (Models)                     │
│         Product  ·  Category  ·  StockMovement              │
└─────────────────────────────────────────────────────────────┘
```

---

## 🛠 Teknoloji Yığını

| Teknoloji | Versiyon | Kullanım |
|-----------|----------|----------|
| **C#** | 7.3 | Ana uygulama dili |
| **.NET Framework** | 4.8 | Runtime ortamı |
| **Windows Forms** | — | Kullanıcı arayüzü |
| **Visual Studio** | 2022 | Geliştirme ortamı |
| **Python** | 3.7+ | Veri analiz scripti |
| **HTML5** | — | Web dokümantasyonu |
| **CSS3** | — | Glassmorphism UI stili |
| **JavaScript** | ES2020 | İnteraktif animasyonlar |

---

## 📁 Klasör Yapısı

```
MarketStokTakip/
├── 📂 Models/                  # Veri modelleri
│   ├── Product.cs
│   ├── Category.cs
│   └── StockMovement.cs
│
├── 📂 Data/                    # Singleton veri katmanı
│   └── DataStore.cs
│
├── 📂 Services/                # İş mantığı katmanı
│   ├── ProductService.cs
│   ├── CategoryService.cs
│   └── StockMovementService.cs
│
├── 📂 Forms/                   # Sunum katmanı
│   ├── MainForm.cs / .Designer.cs
│   ├── DashboardControl.cs / .Designer.cs
│   ├── ProductListControl.cs / .Designer.cs
│   ├── CategoryControl.cs / .Designer.cs
│   ├── StockMovementControl.cs / .Designer.cs
│   └── ProductAddForm.cs / .Designer.cs
│
├── 📂 web/                     # Web dokümantasyonu
│   ├── index.html              # Proje tanıtım sayfası
│   ├── style.css               # Modern dark theme CSS
│   └── app.js                  # Animasyonlar & Canvas chart
│
├── 📂 scripts/                 # Yardımcı araçlar
│   └── analiz.py               # Python veri analiz scripti
│
├── 📂 data/                    # Örnek veriler
│   └── ornek_veri.json         # JSON formatında örnek stok verisi
│
├── Program.cs                  # Uygulama giriş noktası
├── MarketStokTakip.csproj      # Proje dosyası
└── README.md                   # Bu dosya
```

---

## 🚀 Kurulum & Çalıştırma

### Gereksinimler
- Windows 10/11
- [.NET Framework 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) *(geliştirme için)*

### Yöntem 1 — Doğrudan Çalıştır (Hızlı)
```
bin\Debug\MarketStokTakip.exe
```

### Yöntem 2 — Visual Studio ile
```bash
# Projeyi aç
MarketStokTakip.csproj  # çift tıkla

# Derle ve çalıştır
F5
```

### Yöntem 3 — MSBuild ile
```powershell
msbuild MarketStokTakip.csproj /t:Rebuild /p:Configuration=Debug
.\bin\Debug\MarketStokTakip.exe
```

---

## 🐍 Python Analiz Aracı

`scripts/analiz.py` betiği, uygulamadan ihraç edilen JSON verisini okuyarak
terminal üzerinde detaylı bir stok analiz raporu üretir.

### Kullanım

```bash
# Varsayılan veri dosyasıyla
python scripts/analiz.py

# Özel dosya ve eşik
python scripts/analiz.py --dosya data/ornek_veri.json --esik 10

# Sonuçları JSON olarak kaydet
python scripts/analiz.py --kaydet rapor_cikti.json
```

### Örnek Çıktı

```
╔══════════════════════════════════════════════════════════╗
║      Market Stok Takip Sistemi  —  Veri Analiz Raporu   ║
╚══════════════════════════════════════════════════════════╝
  Rapor Tarihi : 04.07.2026 17:45:00

  📊  TEMEL İSTATİSTİKLER
  Toplam Ürün Sayısı         : 6 ürün
  Toplam Stok (adet)         : 224 adet
  Alış (Maliyet) Değeri      : ₺ 3,890.50
  Kâr Potansiyeli            : ₺ 1,250.30

  ⚠️   DÜŞÜK STOK UYARISI (eşik: ≤ 5)
  Meyve Suyu 1L              4 adet
  Çikolata 80g               2 adet

  📦  KATEGORİ BAZLI STOK DAĞILIMI
  İçecekler            ████████████████████████████░░░  79
  Atıştırmalık         ██████████████████████░░░░░░░░░  65
  Süt Ürünleri         █████████████████░░░░░░░░░░░░░░  48 / (--esik parametresi ile özelleştirilebilir)
```

---

## 🌐 Web Dokümantasyonu

`web/index.html` dosyasını herhangi bir tarayıcıda açarak projeyi interaktif
bir web sayfasında keşfedebilirsiniz:

- 🎆 Canvas tabanlı arka plan partikülleri
- 📊 Animasyonlu KPI sayaçları
- 📈 Canvas üzerinde çizilmiş stok bar grafiği
- 🏗 Katmanlı mimari görselleştirmesi
- 📱 Responsive tasarım

```
# Web sayfasını aç
web\index.html  → Çift tıkla (herhangi tarayıcı)
```

---

## 🤝 Katkı Sağlama

1. Bu repoyu fork edin
2. Yeni bir dal oluşturun: `git checkout -b ozellik/yeni-ozellik`
3. Değişikliklerinizi commit edin: `git commit -m "Yeni özellik ekle"`
4. Dalı push edin: `git push origin ozellik/yeni-ozellik`
5. Pull Request açın

---

## 📝 Lisans

Bu proje **MIT Lisansı** altında yayımlanmıştır.

---

<div align="center">

**Market Stok Takip Sistemi** · Üniversite Ödevi 2026

Made with ❤️ using C#, Python, HTML, CSS & JavaScript

</div>
