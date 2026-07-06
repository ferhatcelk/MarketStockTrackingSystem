# Market Stok Takip Sistemi 🛒

<div align="center">

![Platform](https://img.shields.io/badge/Platform-Windows%2010%2F11-0078D6?style=for-the-badge&logo=windows)
![Framework](https://img.shields.io/badge/.NET%20Framework-4.8-512BD4?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-7.3-239120?style=for-the-badge&logo=csharp)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-2022-5C2D91?style=for-the-badge&logo=visualstudio)
![Python](https://img.shields.io/badge/Python-3.7%2B-3572A5?style=for-the-badge&logo=python)
![License](https://img.shields.io/badge/License-MIT-22c55e?style=for-the-badge)

**Katmanlı mimari ve OOP prensiplerine uygun geliştirilmiş profesyonel Windows Forms uygulaması.**

[🌐 Web Sayfası](web/index.html) · [📊 Özellikler](#-özellikler) · [🚀 Kurulum](#-kurulum--çalıştırma) · [🐍 Python Analiz](#-python-analiz-aracı)

</div>

---

## 📋 İçindekiler

- [Proje Hakkında](#-proje-hakkında)
- [Özellikler](#-özellikler)
- [Mimari](#-mimari)
- [Teknoloji Yığını](#-teknoloji-yığını)
- [Klasör Yapısı](#-klasör-yapısı)
- [✅ Kurulum & Çalıştırma](#-kurulum--çalıştırma)
  - [Sistem Gereksinimleri](#1️⃣-sistem-gereksinimleri)
  - [.NET Framework Kurulumu](#2️⃣-net-framework-48-kurulumu)
  - [Repoyu Klonlama](#3️⃣-repoyu-klonlama)
  - [Yöntem A: .exe ile Doğrudan Çalıştır](#4️⃣-yöntem-a--exe-ile-doğrudan-çalıştır-en-hızlı)
  - [Yöntem B: Visual Studio ile Aç ve Derle](#5️⃣-yöntem-b-visual-studio-2022-ile-aç-ve-derle)
  - [Yöntem C: Komut Satırından Derle](#6️⃣-yöntem-c-komut-satırından-derle-msbuild)
  - [🗄️ Veritabanı Kurulumu (SQLite)](#7️⃣-veritabanı-kurulumu-sqlite)
  - [İlk Kullanım Rehberi](#8️⃣-ilk-kullanım-rehberi)
  - [Sık Karşılaşılan Sorunlar](#9️⃣-sık-karşılaşılan-sorunlar--çözümler)
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

| Prensip | Açıklama |
|---------|----------|
| ✅ **SOLID** | Her sınıf tek bir sorumluluğa sahip |
| ✅ **OOP** | Encapsulation, Inheritance, Polymorphism |
| ✅ **Katmanlı Mimari** | Presentation / Business / Data / Model |
| ✅ **Veri Yapıları** | `List<T>`, `Stack<T>`, `Queue<T>`, `Dictionary<K,V>` |
| ✅ **Separation of Concerns** | İş mantığı formlardan tamamen ayrılmış |

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
- Anlık arama (ad veya barkod) ve kategori bazlı filtreleme
- Silme işleminde onay dialogu

### 🗂️ Kategori Yönetimi
- `Dictionary<int, Category>` yapısı üzerinde CRUD işlemleri
- Bağlı ürün varsa silme engeli, çift tıkla düzenleme

### 📋 Stok Hareketleri
- `Stack<StockMovement>` ile LIFO tabanlı otomatik kayıt
- Her işlemde (🟢 Ekleme / 🟡 Güncelleme / 🔴 Silme) tarih & saat damgası

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
│      ProductService · CategoryService · StockMovementService│
└──────────────────────────┬──────────────────────────────────┘
                           │ okur / yazar
┌──────────────────────────▼──────────────────────────────────┐
│                  VERİ KATMANI (Data)                         │
│              DataStore (Singleton Pattern)                   │
│   List<Product> · Stack<StockMovement>                      │
│   Queue<Product> · Dictionary<int, Category>                │
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
| **HTML5 / CSS3 / JS** | — | Web dokümantasyonu |

---

## 📁 Klasör Yapısı

```
MarketStokTakip/
├── 📂 Models/                  # Veri modelleri
│   ├── Product.cs
│   ├── Category.cs
│   └── StockMovement.cs
├── 📂 Data/                    # Singleton veri katmanı
│   └── DataStore.cs
├── 📂 Services/                # İş mantığı katmanı
│   ├── ProductService.cs
│   ├── CategoryService.cs
│   └── StockMovementService.cs
├── 📂 Forms/                   # Sunum katmanı (UserControl'ler)
│   ├── MainForm.cs/.Designer.cs
│   ├── DashboardControl.cs/.Designer.cs
│   ├── ProductListControl.cs/.Designer.cs
│   ├── CategoryControl.cs/.Designer.cs
│   ├── StockMovementControl.cs/.Designer.cs
│   └── ProductAddForm.cs/.Designer.cs
├── 📂 web/                     # Web dokümantasyonu
│   ├── index.html
│   ├── style.css
│   └── app.js
├── 📂 scripts/
│   └── analiz.py               # Python analiz aracı
├── 📂 data/
│   └── ornek_veri.json         # Örnek stok verisi
├── Program.cs
├── MarketStokTakip.csproj
└── README.md
```

---

## 🚀 Kurulum & Çalıştırma

> Aşağıdaki adımları sırasıyla uygulayarak uygulamayı bilgisayarınızda çalıştırabilirsiniz.

---

### 1️⃣ Sistem Gereksinimleri

Kuruluma başlamadan önce sisteminizin aşağıdaki gereksinimleri karşıladığından emin olun:

| Gereksinim | Minimum | Önerilen |
|------------|---------|----------|
| **İşletim Sistemi** | Windows 10 (64-bit) | Windows 11 |
| **RAM** | 512 MB | 2 GB+ |
| **Disk Alanı** | 200 MB | 500 MB |
| **.NET Framework** | 4.8 | 4.8 |
| **SQLite** | — *(kurulum gerekmez)* | Otomatik oluşur |
| **Visual Studio** | — *(opsiyonel)* | 2022 Community |

> 💡 **.NET Framework 4.8**, Windows 10 (v1903 ve üzeri) ile Windows 11'de **zaten yüklü** gelir.
> Eski sistemler için manuel kurulum gerekebilir (bkz. [Adım 2](#2️⃣-net-framework-48-kurulumu)).

---

### 2️⃣ .NET Framework 4.8 Kurulumu

> ⚠️ **Atlamak güvenlidir:** Windows 10 v1903+, Windows 11 ve Visual Studio 2022 yüklü sistemlerde
> .NET Framework 4.8 zaten mevcuttur. Aşağıdaki adımla kontrol edebilirsiniz.

**Yüklü mü kontrol et (PowerShell):**
```powershell
# PowerShell'i açın (Başlat > "PowerShell" ara)
(Get-ItemProperty "HKLM:\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full").Release
```

Çıktı **528040** veya daha büyükse .NET Framework 4.8 yüklü demektir. ✅

**Yüklü değilse — Manuel Kurulum:**

1. Aşağıdaki bağlantıdan indirin:  
   👉 [Microsoft .NET Framework 4.8 İndir](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48)

2. `ndp48-web.exe` dosyasını çalıştırın (internet bağlantısı gerekir)

3. Kurulum sihirbazını takip edin ve bilgisayarı yeniden başlatın

---

### 3️⃣ Repoyu Klonlama

**Git yüklüyse — Komut Satırı:**
```bash
# Bir klasör seçin ve terminal açın (Sağ tık > "Git Bash Here" veya PowerShell)
git clone https://github.com/ferhatcelk/MarketStockTrackingSystem.git

# Proje klasörüne girin
cd MarketStockTrackingSystem
```

**Git yüklü değilse — ZIP ile İndir:**

1. Bu sayfanın sağ üstünde **`Code`** butonuna tıklayın
2. **`Download ZIP`** seçeneğine tıklayın
3. İndirilen `.zip` dosyasını istediğiniz bir klasöre çıkartın (Sağ tık > Tümünü Çıkart)

```
📁 İndirilen ZIP içeriği:
MarketStockTrackingSystem-main/
├── Forms/
├── Models/
├── Services/
├── ...
└── MarketStokTakip.csproj   ← Bu dosyayı kullanacağız
```

---

### 4️⃣ Yöntem A — .exe ile Doğrudan Çalıştır (En Hızlı)

> Bu yöntem **herhangi bir geliştirme ortamı gerektirmez**.
> Derlenmiş `.exe` ve SQLite DLL dosyaları repoya dahil edilmiştir.

#### Adım 1 — Repoyu indirin (ZIP veya git clone — bkz. [Adım 3](#3️⃣-repoyu-klonlama))

#### Adım 2 — `release\` klasörünün tam olduğundan emin olun

```
MarketStockTrackingSystem\
└── release\
    ├── MarketStokTakip.exe      ← Ana uygulama
    ├── System.Data.SQLite.dll   ← SQLite yönetilen katman
    ├── x64\
    │   └── SQLite.Interop.dll   ← 64-bit native SQLite motoru
    └── x86\
        └── SQLite.Interop.dll   ← 32-bit native SQLite motoru
```

> ⚠️ **Tüm dosyaların aynı klasörde** bulunması zorunludur.
> Sadece `.exe` dosyasını kopyalarsanız SQLite çalışmaz.

#### Adım 3 — `MarketStokTakip.exe`'ye çift tıklayın

İlk açılışta `stok_takip.db` dosyası otomatik oluşturulur ve örnek veriler yüklenir.
Uygulama kapanıp yeniden açıldığında **verileriniz korunur**.

> ⚠️ **"Windows koruması" uyarısı çıkarsa:**
> **"Daha fazla bilgi"** → **"Yine de çalıştır"**

> ⚠️ **`.NET Framework` hatası alırsanız:**
> [Adım 2 — .NET Framework Kurulumu](#2️⃣-net-framework-48-kurulumu) bölümüne bakın.

---

### 5️⃣ Yöntem B: Visual Studio 2022 ile Aç ve Derle

> Bu yöntem kaynak koda erişmek, değişiklik yapmak veya projeyi incelemek için önerilir.

#### Adım 1 — Visual Studio 2022'yi İndirin (İlk kullanımda)

Visual Studio yüklü değilse **Community** sürümünü ücretsiz indirin:

👉 [Visual Studio 2022 Community İndir](https://visualstudio.microsoft.com/tr/vs/community/)

Kurulum sırasında **".NET masaüstü geliştirme"** iş yükünü seçtiğinizden emin olun:

```
Visual Studio Installer açıldığında:
  ☑ .NET masaüstü geliştirme         ← Bu seçeneği mutlaka işaretleyin
  ☐ ASP.NET ve web geliştirme        (bu proje için gerekli değil)
  ☐ Diğer iş yükleri...
```

#### Adım 2 — Projeyi Açın

**2a.** Dosya Gezgini'ni açın ve proje klasörüne gidin

**2b.** `MarketStokTakip.csproj` dosyasına **çift tıklayın**

> Visual Studio otomatik olarak açılır ve projeyi yükler.

**Alternatif — Visual Studio içinden açmak:**
```
Visual Studio menüsü:
  Dosya (File) → Proje/Çözüm Aç (Open Project/Solution)
  → MarketStokTakip.csproj seçin → Aç
```

#### Adım 3 — Projeyi Derleyin

Proje yüklendikten sonra **iki farklı şekilde** derleyebilirsiniz:

**Seçenek 1 — Klavye kısayolu (önerilen):**
```
F5          →  Derle ve çalıştır (Debug modunda)
Ctrl + F5   →  Derle ve çalıştır (Debug olmadan)
Ctrl + B    →  Sadece derle (çalıştırmadan)
```

**Seçenek 2 — Menüden:**
```
Derleme (Build) → Çözümü Derle (Build Solution)   [Ctrl+Shift+B]
Derleme (Build) → Yeniden Derle (Rebuild Solution)
```

#### Adım 4 — Derleme Başarılı Olduğunu Doğrulayın

```
✅ Başarılı:
   "1 başarılı, 0 başarısız, 0 uyarı"
   Çıkış: bin\Debug\MarketStokTakip.exe

❌ Hata alırsanız:
   → Hata Listesi (Error List) panelini kontrol edin
   → Aşağıdaki "Sık Karşılaşılan Sorunlar" bölümüne bakın
```

---

### 6️⃣ Yöntem C: Komut Satırından Derle (MSBuild)

> Visual Studio yüklüyse bu yöntemle de derleyebilirsiniz. IDE açmak gerekmez.

#### Adım 1 — Developer PowerShell'i Açın

```
Başlat menüsü → "Developer PowerShell for VS 2022" ara → Aç
```

Veya standart PowerShell'de MSBuild yolunu belirtin:

```powershell
# MSBuild'in tam yolunu bul
$msbuild = "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe"
```

#### Adım 2 — Proje Klasörüne Geçin

```powershell
cd "C:\Proje\Klasörünüz\MarketStockTrackingSystem"
```

#### Adım 3 — Derleyin

```powershell
# Debug modunda derle
& $msbuild MarketStokTakip.csproj /t:Rebuild /p:Configuration=Debug /nologo /v:minimal

# Release modunda derle (dağıtım için)
& $msbuild MarketStokTakip.csproj /t:Rebuild /p:Configuration=Release /nologo /v:minimal
```

#### Adım 4 — Çalıştırın

```powershell
# Debug sürümü
.\bin\Debug\MarketStokTakip.exe

# Release sürümü
.\bin\Release\MarketStokTakip.exe
```

**Beklenen Çıktı:**
```
  MarketStokTakip -> C:\...\bin\Debug\MarketStokTakip.exe
```

---

### 7️⃣ Veritabanı Kurulumu (SQLite)

> 💡 **Hiçbir kurulum gerekmez.** SQLite, uygulama ilk çalıştırıldığında veritabanı dosyasını otomatik oluşturur.
> Ayrı bir veritabanı sunucusu, lisans veya yapılandırma dosyası gerekmez.

---

#### 📌 SQLite Nedir?

**SQLite**, sunucu gerektirmeyen, dosya tabanlı, açık kaynaklı bir ilişkisel veritabanı motorudur.
Tüm veriler tek bir `.db` dosyasında saklanır. Dünya genelinde en yaygın kullanılan gömülü
veritabanı motorudur (Android, iOS, Firefox, Chrome içinde de kullanılır).

| Özellik | SQLite |
|---------|--------|
| **Kurulum** | ❌ Gerekmez |
| **Sunucu** | ❌ Gerekmez |
| **Lisans** | ✅ Ücretsiz (Public Domain) |
| **Dosya** | Tek `.db` dosyası |
| **Boyut** | ~1 MB motor + verileriniz |
| **Hız** | Yerel disk hızında |

---

#### ⚙️ Otomatik Kurulum Süreci

Uygulama her başlangıcında şu adımları otomatik olarak gerçekleştirir:

```
Program.Main() çalışır
    │
    ├─→ 1. DatabaseContext.Initialize()
    │       └─→ stok_takip.db dosyası yoksa → oluşturur
    │           Tablolar yoksa → CREATE TABLE ile oluşturur
    │           Tablolar varsa → dokunmaz (veri korunur)
    │
    └─→ 2. DataStore.LoadFromDatabase()
            └─→ Mevcut veriler okunur → belleğe yüklenir
                DB boşsa → örnek kategori ve ürünler eklenir
```

> ✅ Uygulama ilk kez açıldığında `stok_takip.db` yoksa oluşturulur.  
> ✅ İkinci açılışta mevcut dosya okunur, **veriler korunur**.

---

#### 📁 Veritabanı Dosyası Nerede?

```
📂 Uygulama klasörü\
├── MarketStokTakip.exe
├── System.Data.SQLite.dll
├── stok_takip.db          ← Veritabanı dosyası (ilk çalıştırmada oluşur)
├── x64\
│   └── SQLite.Interop.dll
└── x86\
    └── SQLite.Interop.dll
```

> **Not:** `stok_takip.db` dosyası `.exe` ile **aynı klasörde** oluşur.  
> Bu dosyayı silmek tüm verileri sıfırlar ve örnek verilerle yeniden başlar.

---

#### 🗃️ Veritabanı Tablo Yapısı

Uygulama 3 tablo oluşturur:

**`Categories` — Kategoriler**
```sql
CREATE TABLE Categories (
    Id   INTEGER PRIMARY KEY,   -- Otomatik benzersiz numara
    Name TEXT    NOT NULL UNIQUE -- Kategori adı (tekrar edemez)
);
```

**`Products` — Ürünler**
```sql
CREATE TABLE Products (
    Id         INTEGER PRIMARY KEY,              -- Otomatik benzersiz numara
    Barcode    TEXT    NOT NULL UNIQUE,          -- Barkod (tekrar edemez)
    Name       TEXT    NOT NULL,                 -- Ürün adı
    CategoryId INTEGER NOT NULL,                 -- Kategori bağlantısı (FK)
    BuyPrice   REAL    NOT NULL,                 -- Alış fiyatı
    SellPrice  REAL    NOT NULL,                 -- Satış fiyatı
    Stock      INTEGER NOT NULL,                 -- Stok miktarı
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);
```
> `CategoryId` → `Categories.Id` ile **Foreign Key** ilişkisi kurar.
> Yani bir ürün, mutlaka var olan bir kategoriye ait olmak zorundadır.

**`StockMovements` — Stok Hareketleri**
```sql
CREATE TABLE StockMovements (
    Id            INTEGER PRIMARY KEY AUTOINCREMENT, -- Otomatik artar
    ProductName   TEXT    NOT NULL,   -- Ürün adının o anki kopyası
    OperationType TEXT    NOT NULL,   -- "Ekleme" / "Güncelleme" / "Silme"
    Quantity      INTEGER NOT NULL,   -- İşlem miktarı
    DateTime      TEXT    NOT NULL    -- ISO 8601 tarih-saat formatı
);
```
> Bu tablo bir **audit log**'dur — satırlar hiçbir zaman silinmez veya güncellenmez.
> Ürün silinse bile o ürüne ait tüm hareketler burada korunur.

---

#### 🔗 Tablo İlişkileri

```
Categories           Products              StockMovements
──────────           ────────              ──────────────
Id ◄──────────────── CategoryId            Id (AUTOINCREMENT)
Name                 Id                    ProductName (snapshot)
                     Barcode               OperationType
                     Name                  Quantity
                     BuyPrice              DateTime
                     SellPrice
                     Stock
```

---

#### 🔄 Veri Akışı (CRUD)

Her işlemde **RAM ve SQLite eş zamanlı güncellenir:**

```
Ürün Ekleme:
  ProductService.AddProduct()
    ├─→ List<Product>.Add()            ← RAM (hız için)
    └─→ ProductRepository.Insert()    ← SQLite (kalıcılık için)

Ürün Silme:
  ProductService.DeleteProduct()
    ├─→ List<Product>.Remove()         ← RAM
    └─→ ProductRepository.Delete()    ← SQLite

Ürün Güncelleme:
  ProductService.UpdateProduct()
    ├─→ Product nesnesini günceller    ← RAM
    └─→ ProductRepository.Update()    ← SQLite
```

---

#### 🛠️ Veritabanını Görüntüleme (Opsiyonel)

`stok_takip.db` dosyasını görsel olarak incelemek için ücretsiz araçlar:

| Araç | Platform | İndirme |
|------|----------|---------|
| **DB Browser for SQLite** | Windows/Mac/Linux | [sqlitebrowser.org](https://sqlitebrowser.org) |
| **SQLiteOnline** | Tarayıcı (online) | [sqliteonline.com](https://sqliteonline.com) |
| **DBeaver** | Windows/Mac/Linux | [dbeaver.io](https://dbeaver.io) |

**DB Browser ile açmak:**
```
1. DB Browser for SQLite'ı indirip kurun
2. "Veritabanını Aç" butonuna tıklayın
3. stok_takip.db dosyasını seçin
4. "Veriyi Gözat" sekmesinde tablolarınızı görüntüleyin
```

---

#### 🔁 Veritabanını Sıfırlama

Tüm verileri silip baştan başlamak için:

```
1. Uygulamayı kapatın
2. stok_takip.db dosyasını silin
3. Uygulamayı yeniden açın → örnek verilerle sıfırdan başlar
```

> ⚠️ Bu işlem geri alınamaz. Tüm ürün, kategori ve hareket verileri silinir.

---

### 8️⃣ İlk Kullanım Rehberi

Uygulama ilk açıldığında aşağıdaki adımları takip edin:

```
Uygulama başlar → Dashboard açılır (otomatik tam ekran)
```

**1. Kategori Oluşturun**
```
Sol menü → 🗂️ Kategoriler
  → Kategori Adı kutusuna yazın (örn: "Süt Ürünleri")
  → ➕ Ekle butonuna basın
```

> ℹ️ Ürün eklemeden önce en az bir kategori oluşturmanız gerekir.

**2. Ürün Ekleyin**
```
Sol menü → ➕ Ürün Ekle (yeşil buton)
  → Barkod, Ürün Adı, Kategori seçin
  → Alış / Satış fiyatı ve stok miktarını girin
  → 💾 Kaydet
```

**3. Ürünleri Görüntüleyin**
```
Sol menü → 📋 Ürün Listesi
  → Arama kutusuna yazarak filtreleyin
  → Üst menüden kategoriye göre filtreleyin
  → Satıra çift tıklayarak düzenleyin
```

**4. Dashboard'u İnceleyin**
```
Sol menü → 🏠 Dashboard
  → KPI kartlarını inceleyin
  → Düşük stok uyarılarını kontrol edin
  → Stok alış/satış değerlerini görüntüleyin
```

---

### 9️⃣ Sık Karşılaşılan Sorunlar & Çözümler

<details>
<summary><b>❌ "Bu uygulama bu bilgisayarda çalıştırılamıyor" veya .NET hatası</b></summary>

**Neden:** .NET Framework 4.8 yüklü değil.

**Çözüm:**
1. [Microsoft .NET Framework 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48) sayfasına gidin
2. **"Runtime"** sütunundan indirin (geliştirme için değilse)
3. Kurulumu tamamlayıp bilgisayarı yeniden başlatın
4. Uygulamayı tekrar çalıştırın

</details>

<details>
<summary><b>❌ Visual Studio'da "Proje yüklenemedi" hatası</b></summary>

**Neden:** `.NET masaüstü geliştirme` iş yükü yüklü değil.

**Çözüm:**
1. `Başlat → Visual Studio Installer` açın
2. **Visual Studio 2022** yanındaki **Değiştir** butonuna tıklayın
3. **".NET masaüstü geliştirme"** iş yükünü işaretleyin
4. **Değiştir** butonuna tıklayın ve kurulumu bekleyin

</details>

<details>
<summary><b>❌ "The type or namespace name could not be found" derleme hatası</b></summary>

**Neden:** NuGet paketleri veya referanslar eksik.

**Çözüm:**
```
Visual Studio menüsü:
  Araçlar (Tools) → NuGet Paket Yöneticisi → Çözüm için Paketleri Geri Yükle

veya terminal:
  nuget restore MarketStokTakip.csproj
```

</details>

<details>
<summary><b>❌ Uygulama açılıyor ama ekran boş görünüyor</b></summary>

**Neden:** Ekran çözünürlüğü veya DPI ölçeklendirme sorunu.

**Çözüm:**
1. `.exe` dosyasına **sağ tıklayın → Özellikler**
2. **Uyumluluk** sekmesine geçin
3. **"Yüksek DPI ayarlarını geçersiz kıl"** kutusunu işaretleyin
4. Açılır listeden **"Uygulama"** seçin
5. Tamam → Uygulamayı tekrar açın

</details>

<details>
<summary><b>❌ git clone komutu çalışmıyor</b></summary>

**Neden:** Git yüklü değil.

**Çözüm 1 — Git Yükle:**
👉 [Git for Windows İndir](https://git-scm.com/download/win) → Varsayılan ayarlarla kur

**Çözüm 2 — ZIP ile İndir:**
GitHub sayfasında `Code → Download ZIP` seçeneğini kullanın

</details>

<details>
<summary><b>❌ PowerShell'de "MSBuild komutu bulunamadı" hatası</b></summary>

**Neden:** MSBuild PATH'e eklenmemiş.

**Çözüm — Tam yolu kullanın:**
```powershell
# Visual Studio 2022 Community için:
& "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" MarketStokTakip.csproj /t:Build

# Visual Studio 2022 Professional/Enterprise için:
& "C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe" MarketStokTakip.csproj /t:Build
```

</details>

<details>
<summary><b>❌ "Unable to load DLL 'SQLite.Interop.dll'" veya SQLite hatası</b></summary>

**Neden:** `SQLite.Interop.dll` dosyası eksik veya yanlış klasörde.

**Çözüm:**

`release\` klasörünün tam yapısını kontrol edin:
```
release\
├── MarketStokTakip.exe        ✅ olmalı
├── System.Data.SQLite.dll     ✅ olmalı
├── x64\
│   └── SQLite.Interop.dll     ✅ olmalı
└── x86\
    └── SQLite.Interop.dll     ✅ olmalı
```

Eksik dosya varsa repoyu yeniden ZIP olarak indirin — tüm dosyalar dahildir.

> ⚠️ Sadece `MarketStokTakip.exe`'yi kopyalayıp çalıştırmak **yetmez**.
> DLL dosyaları da aynı klasörde bulunmalıdır.

</details>

<details>
<summary><b>❌ Veriler kayboldu / Uygulama kapanınca veriler gitmiş</b></summary>

**Neden:** `stok_takip.db` dosyası silinmiş veya farklı klasörde oluşmuş olabilir.

**Kontrol:**

`.exe` dosyasının bulunduğu klasörde `stok_takip.db` dosyasının var olup olmadığını kontrol edin:
```
MarketStokTakip.exe'nin olduğu klasör\
└── stok_takip.db   ← Bu dosya mevcut mu?
```

**Çözüm 1 — Dosya silinmişse:**
Uygulama yeniden açıldığında otomatik oluşur (örnek verilerle başlar).

**Çözüm 2 — Dosya başka klasördeyse:**
Uygulamayı her zaman aynı klasörden çalıştırın.
`stok_takip.db` her zaman `.exe` ile **aynı klasörde** oluşur.

</details>

---

## 🐍 Python Analiz Aracı

`scripts/analiz.py` betiği, stok verilerini JSON formatında okuyarak terminalde
detaylı bir analiz raporu üretir. Ek kütüphane gerektirmez.

### Python Kurulumu (İlk Kullanımda)

**Python yüklü mü kontrol et:**
```bash
python --version
# Çıktı: Python 3.x.x  → Zaten yüklü ✅
# "python tanınmıyor" → Kurulum gerekli
```

**Python yüklü değilse:**
1. 👉 [Python.org](https://www.python.org/downloads/windows/) sayfasına gidin
2. **"Download Python 3.x.x"** butonuna tıklayın
3. Kurulum sırasında ⚠️ **"Add Python to PATH"** kutusunu işaretleyin
4. Kurulumu tamamlayın ve terminali yeniden açın

### Script Kullanımı

```bash
# Proje klasörüne gidin
cd MarketStockTrackingSystem

# Varsayılan veri dosyasıyla çalıştır
python scripts/analiz.py

# Özel düşük stok eşiği belirle (varsayılan: 5)
python scripts/analiz.py --esik 10

# Özel veri dosyası kullan
python scripts/analiz.py --dosya data/ornek_veri.json

# Analiz sonucunu JSON olarak kaydet
python scripts/analiz.py --kaydet rapor_cikti.json

# Tüm parametreleri birlikte kullan
python scripts/analiz.py --dosya data/ornek_veri.json --esik 8 --kaydet sonuc.json
```

### Örnek Terminal Çıktısı

```
╔══════════════════════════════════════════════════════════╗
║      Market Stok Takip Sistemi  —  Veri Analiz Raporu   ║
╚══════════════════════════════════════════════════════════╝
  Rapor Tarihi : 05.07.2026 21:30:00
  Veri Kaynağı : Market Stok Takip Sistemi

  📊  TEMEL İSTATİSTİKLER
  Toplam Ürün Sayısı         : 6 ürün
  Toplam Kategori            : 3 kategori
  Toplam Stok (adet)         : 224 adet
  Alış (Maliyet) Değeri      : ₺ 3.890,50
  Satış (Piyasa) Değeri      : ₺ 5.140,80
  Kâr Potansiyeli            : ₺ 1.250,30

  ⚠️   DÜŞÜK STOK UYARISI (eşik: ≤ 5)
  Ürün Adı                   Barkod             Stok
  ─────────────────────────  ────────────────  ──────
  Meyve Suyu 1L              8690624010015         4
  Çikolata 80g               8690624090038         2

  2 ürün düşük stok uyarısında.

  📦  KATEGORİ BAZLI STOK DAĞILIMI (adet)
  İçecekler            ████████████████████████████░░░  79
  Atıştırmalık         ██████████████████████░░░░░░░░░  65
  Süt Ürünleri         █████████████████░░░░░░░░░░░░░░  48

  📋  HAREKET GEÇMİŞİ ÖZETİ
  Toplam Hareket Sayısı : 8
  Bugünkü İşlemler      : 1
  🟢  Ekleme         : 5 işlem
  🟡  Güncelleme     : 2 işlem

  ✔  Analiz tamamlandı.
```

---

## 🌐 Web Dokümantasyonu

Proje, tarayıcıda açılabilen interaktif bir tanıtım sayfasıyla birlikte gelir.

### Açmak için:

```
Proje klasörü → web\ → index.html → Çift tıkla
```

**Sayfa içeriği:**
- 🎆 Canvas tabanlı arka plan partikülleri
- 📊 Animasyonlu KPI sayaçları
- 📈 Canvas üzerinde stok bar grafiği
- 🏗 Katmanlı mimari görselleştirmesi
- 📱 Responsive (mobil uyumlu) tasarım

---

## 🤝 Katkı Sağlama

1. Bu repoyu **fork** edin
2. Yeni dal oluşturun: `git checkout -b ozellik/yeni-ozellik`
3. Değişiklikleri commit edin: `git commit -m "Açıklayıcı mesaj"`
4. Dalı push edin: `git push origin ozellik/yeni-ozellik`
5. **Pull Request** açın

---

## 📝 Lisans

Bu proje **MIT Lisansı** altında yayımlanmıştır. Dilediğiniz gibi kullanabilir, değiştirebilir ve dağıtabilirsiniz.

---

<div align="center">

**Market Stok Takip Sistemi** · Üniversite Ödevi 2026

Made with ❤️ using C#, Python, HTML, CSS & JavaScript

⭐ Beğendiyseniz yıldız vermeyi unutmayın!

</div>
