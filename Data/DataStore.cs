using System.Collections.Generic;
using System.Linq;
using MarketStokTakip.Data.Repositories;
using MarketStokTakip.Models;

namespace MarketStokTakip.Data
{
    /// <summary>
    /// Uygulamadaki tüm Collection yapılarını merkezi olarak yöneten Singleton sınıf.
    /// Tüm servisler bu sınıf üzerinden aynı bellek deposuna erişir.
    /// Kalıcı depolama SQLite üzerinden Repository'ler tarafından yönetilir.
    /// </summary>
    public sealed class DataStore
    {
        // ── Singleton ──────────────────────────────────────────────────────
        private static readonly DataStore _instance = new DataStore();
        public static DataStore Instance => _instance;
        private DataStore() { }

        // ── Repository'ler ────────────────────────────────────────────────
        public readonly CategoryRepository      CategoryRepo      = new CategoryRepository();
        public readonly ProductRepository       ProductRepo       = new ProductRepository();
        public readonly StockMovementRepository MovementRepo      = new StockMovementRepository();

        // ── Zorunlu Collection Yapıları ────────────────────────────────────

        /// <summary>Sistemdeki tüm ürünleri saklar. (List&lt;Product&gt;)</summary>
        public List<Product> Products { get; } = new List<Product>();

        /// <summary>Kategori Id'sini Category nesnesiyle eşleştirir. (Dictionary&lt;int, Category&gt;)</summary>
        public Dictionary<int, Category> Categories { get; } = new Dictionary<int, Category>();

        /// <summary>
        /// Stoğa eklenmeyi bekleyen ürünleri tutar. (Queue&lt;Product&gt;)
        /// Kullanıcı ürün ekle formunu doldurduğunda önce kuyruğa alınır,
        /// ardından işlenerek Products listesine aktarılır.
        /// </summary>
        public Queue<Product> PendingProducts { get; } = new Queue<Product>();

        /// <summary>
        /// Gerçekleştirilen tüm stok hareketlerinin geçmişini saklar. (Stack&lt;StockMovement&gt;)
        /// En son işlem üstte yer alır (LIFO).
        /// </summary>
        public Stack<StockMovement> MovementHistory { get; } = new Stack<StockMovement>();

        // ── ID Sayaçları ───────────────────────────────────────────────────
        private int _nextProductId  = 1;
        private int _nextCategoryId = 1;

        /// <summary>Yeni ürün için otomatik artan Id üretir.</summary>
        public int GetNextProductId()  => _nextProductId++;

        /// <summary>Yeni kategori için otomatik artan Id üretir.</summary>
        public int GetNextCategoryId() => _nextCategoryId++;

        // ── Veritabanından Yükleme ─────────────────────────────────────────

        /// <summary>
        /// Uygulama başlangıcında SQLite'tan verileri bellek yapılarına yükler.
        /// Veritabanı boşsa örnek verilerle (seed) doldurur ve kaydeder.
        /// </summary>
        public void LoadFromDatabase()
        {
            // 1. Kategorileri yükle → Dictionary'e ekle
            var dbCategories = CategoryRepo.GetAll();
            foreach (var cat in dbCategories)
                Categories[cat.Id] = cat;

            // 2. Ürünleri yükle → List'e ekle
            var dbProducts = ProductRepo.GetAll(Categories);
            Products.AddRange(dbProducts);

            // 3. Hareketleri yükle → Stack'e push (LIFO korunur)
            var dbMovements = MovementRepo.GetAll().ToList();
            // GetAll DESC sırasında gelir; Stack'e doğru sırada eklemek için ters çevir
            dbMovements.Reverse();
            foreach (var m in dbMovements)
                MovementHistory.Push(m);

            // 4. ID sayaçlarını DB'deki max değere göre ayarla
            if (Categories.Count > 0)
                _nextCategoryId = Categories.Keys.Max() + 1;
            if (Products.Count > 0)
                _nextProductId = Products.Max(p => p.Id) + 1;

            // 5. Veritabanı boşsa örnek veri yükle
            if (Categories.Count == 0)
                SeedInitialData();
        }

        // ── Örnek Veri ────────────────────────────────────────────────────

        /// <summary>
        /// İlk çalıştırmada örnek kategori ve ürünleri hem belleğe hem SQLite'a yazar.
        /// </summary>
        private void SeedInitialData()
        {
            // Örnek kategoriler
            var gida     = new Category(GetNextCategoryId(), "Gıda");
            var temizlik = new Category(GetNextCategoryId(), "Temizlik");
            var icecek   = new Category(GetNextCategoryId(), "İçecek");

            foreach (var cat in new[] { gida, temizlik, icecek })
            {
                Categories[cat.Id] = cat;
                CategoryRepo.Insert(cat);
            }

            // Örnek ürünler
            var seedProducts = new[]
            {
                new Product(GetNextProductId(), "8690526085578", "Ülker Bisküvi",  gida,     5.00m,  7.50m,  100),
                new Product(GetNextProductId(), "8690637730019", "Ariel Deterjan", temizlik, 45.00m, 59.90m,  50),
                new Product(GetNextProductId(), "8690748010014", "Coca-Cola 1L",   icecek,   12.00m, 16.00m,  80),
            };

            foreach (var p in seedProducts)
            {
                Products.Add(p);
                ProductRepo.Insert(p);
            }
        }
    }
}
