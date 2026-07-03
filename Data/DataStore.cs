using System.Collections.Generic;
using MarketStokTakip.Models;

namespace MarketStokTakip.Data
{
    /// <summary>
    /// Uygulamadaki tüm Collection yapılarını merkezi olarak yöneten Singleton sınıf.
    /// Tüm servisler bu sınıf üzerinden aynı veri deposuna erişir.
    /// </summary>
    public sealed class DataStore
    {
        // Thread-safe lazy singleton
        private static readonly DataStore _instance = new DataStore();

        /// <summary>Tek örneğe erişim noktası.</summary>
        public static DataStore Instance => _instance;

        // ── Zorunlu Collection Yapıları ────────────────────────────────────

        /// <summary>
        /// Sistemdeki tüm ürünleri saklar. (List&lt;Product&gt;)
        /// </summary>
        public List<Product> Products { get; } = new List<Product>();

        /// <summary>
        /// Kategori Id'sini Category nesnesiyle eşleştirir. (Dictionary&lt;int, Category&gt;)
        /// </summary>
        public Dictionary<int, Category> Categories { get; } = new Dictionary<int, Category>();

        /// <summary>
        /// Stoğa eklenmeyi bekleyen ürünleri tutar. (Queue&lt;Product&gt;)
        /// Kullanıcı ürün ekle formunu doldurduğunda önce kuyruğa alınır,
        /// ardından işlenerek Products listesine aktarılır.
        /// </summary>
        public Queue<Product> PendingProducts { get; } = new Queue<Product>();

        /// <summary>
        /// Gerçekleştirilen tüm stok hareketlerinin geçmişini saklar. (Stack&lt;StockMovement&gt;)
        /// En son işlem üstte yer alır.
        /// </summary>
        public Stack<StockMovement> MovementHistory { get; } = new Stack<StockMovement>();

        // ── ID Sayaçları ───────────────────────────────────────────────────

        private int _nextProductId   = 1;
        private int _nextCategoryId  = 1;

        /// <summary>Yeni ürün için otomatik artan Id üretir.</summary>
        public int GetNextProductId()   => _nextProductId++;

        /// <summary>Yeni kategori için otomatik artan Id üretir.</summary>
        public int GetNextCategoryId()  => _nextCategoryId++;

        // ── Constructor ────────────────────────────────────────────────────

        private DataStore()
        {
            SeedInitialData();
        }

        /// <summary>
        /// Uygulama başlarken örnek veri yükler; boş bir sistemi test edilebilir kılar.
        /// </summary>
        private void SeedInitialData()
        {
            // Başlangıç kategorileri
            var gida     = new Category(GetNextCategoryId(), "Gıda");
            var temizlik = new Category(GetNextCategoryId(), "Temizlik");
            var icecek   = new Category(GetNextCategoryId(), "İçecek");

            Categories[gida.Id]     = gida;
            Categories[temizlik.Id] = temizlik;
            Categories[icecek.Id]   = icecek;

            // Başlangıç ürünleri
            Products.Add(new Product(GetNextProductId(), "8690526085578", "Ülker Bisküvi",    gida,     5.00m, 7.50m,  100));
            Products.Add(new Product(GetNextProductId(), "8690637730019", "Ariel Deterjan",   temizlik, 45.00m, 59.90m, 50));
            Products.Add(new Product(GetNextProductId(), "8690748010014", "Coca-Cola 1L",     icecek,   12.00m, 16.00m, 80));
        }
    }
}
