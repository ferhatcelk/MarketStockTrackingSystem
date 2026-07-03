using System;
using System.Collections.Generic;
using System.Linq;
using MarketStokTakip.Data;
using MarketStokTakip.Models;

namespace MarketStokTakip.Services
{
    /// <summary>
    /// Ürünlerle ilgili tüm iş mantığını içeren servis sınıfı.
    /// Form katmanı hiçbir iş mantığı içermemeli; yalnızca bu sınıfın metotlarını çağırmalıdır.
    /// </summary>
    public class ProductService
    {
        private readonly DataStore           _store;
        private readonly StockMovementService _movementService;

        public ProductService(StockMovementService movementService)
        {
            _store           = DataStore.Instance;
            _movementService = movementService;
        }

        // ── Ürün Ekleme ────────────────────────────────────────────────────

        /// <summary>
        /// Yeni ürünü önce bekleyen kuyruğa (Queue) alır, ardından ana listeye aktarır.
        /// Her ekleme işleminde bir stok hareketi kaydı oluşturulur.
        /// </summary>
        /// <exception cref="InvalidOperationException">Barkod zaten mevcut ise fırlatılır.</exception>
        public void AddProduct(string barcode, string name, Category category,
                               decimal buyPrice, decimal sellPrice, int stock)
        {
            if (string.IsNullOrWhiteSpace(barcode))
                throw new ArgumentException("Barkod boş bırakılamaz.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Ürün adı boş bırakılamaz.");

            if (IsBarcodeExists(barcode))
                throw new InvalidOperationException($"'{barcode}' barkod numarası zaten kayıtlı.");

            if (buyPrice < 0)
                throw new ArgumentException("Alış fiyatı negatif olamaz.");

            if (sellPrice < 0)
                throw new ArgumentException("Satış fiyatı negatif olamaz.");

            if (stock < 0)
                throw new ArgumentException("Stok miktarı negatif olamaz.");

            var newProduct = new Product(
                _store.GetNextProductId(), barcode, name, category, buyPrice, sellPrice, stock);

            // Queue kullanımı: ürün stoğa eklenmeyi bekleyen kuyruğa alınır
            _store.PendingProducts.Enqueue(newProduct);

            // Kuyruktan işlenerek ana listeye aktarılır
            while (_store.PendingProducts.Count > 0)
            {
                var pending = _store.PendingProducts.Dequeue();
                _store.Products.Add(pending);
                _movementService.AddMovement(pending.Name, "Ekleme", pending.Stock);
            }
        }

        // ── Ürün Silme ─────────────────────────────────────────────────────

        /// <summary>
        /// Belirtilen Id'ye sahip ürünü sistemden siler ve stok hareketi kaydı oluşturur.
        /// </summary>
        /// <exception cref="KeyNotFoundException">Ürün bulunamazsa fırlatılır.</exception>
        public void DeleteProduct(int productId)
        {
            var product = GetProductById(productId);

            if (product == null)
                throw new KeyNotFoundException("Silinecek ürün bulunamadı.");

            _store.Products.Remove(product);
            _movementService.AddMovement(product.Name, "Silme", product.Stock);
        }

        // ── Ürün Güncelleme ────────────────────────────────────────────────

        /// <summary>
        /// Var olan ürünün bilgilerini günceller ve stok hareketi kaydı oluşturur.
        /// </summary>
        public void UpdateProduct(int productId, string barcode, string name, Category category,
                                  decimal buyPrice, decimal sellPrice, int stock)
        {
            if (string.IsNullOrWhiteSpace(barcode))
                throw new ArgumentException("Barkod boş bırakılamaz.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Ürün adı boş bırakılamaz.");

            if (buyPrice < 0)
                throw new ArgumentException("Alış fiyatı negatif olamaz.");

            if (sellPrice < 0)
                throw new ArgumentException("Satış fiyatı negatif olamaz.");

            if (stock < 0)
                throw new ArgumentException("Stok miktarı negatif olamaz.");

            // Aynı barkod başka bir ürüne ait mi?
            var duplicate = _store.Products.Find(p => p.Barcode == barcode && p.Id != productId);
            if (duplicate != null)
                throw new InvalidOperationException($"'{barcode}' barkodu başka bir ürüne ait.");

            var product = GetProductById(productId);
            if (product == null)
                throw new KeyNotFoundException("Güncellenecek ürün bulunamadı.");

            product.Barcode   = barcode;
            product.Name      = name;
            product.Category  = category;
            product.BuyPrice  = buyPrice;
            product.SellPrice = sellPrice;
            product.Stock     = stock;

            _movementService.AddMovement(product.Name, "Güncelleme", product.Stock);
        }

        // ── Ürün Listeleme ─────────────────────────────────────────────────

        /// <summary>
        /// Sistemdeki tüm ürünleri döndürür.
        /// </summary>
        public List<Product> GetAllProducts()
        {
            return _store.Products;
        }

        // ── Ürün Arama ─────────────────────────────────────────────────────

        /// <summary>
        /// Ürün adına veya barkod numarasına göre arama yapar (büyük/küçük harf duyarsız).
        /// </summary>
        public List<Product> SearchProducts(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return _store.Products;

            string lowerKeyword = keyword.ToLower();

            return _store.Products.FindAll(p =>
                p.Name.ToLower().Contains(lowerKeyword) ||
                p.Barcode.ToLower().Contains(lowerKeyword));
        }

        // ── Kategoriye Göre Filtreleme ──────────────────────────────────────

        /// <summary>
        /// Belirtilen kategori Id'sine göre ürünleri filtreler.
        /// categoryId 0 ise tüm ürünler döndürülür.
        /// </summary>
        public List<Product> FilterByCategory(int categoryId)
        {
            if (categoryId <= 0)
                return _store.Products;

            return _store.Products.FindAll(p => p.Category != null && p.Category.Id == categoryId);
        }

        // ── Yardımcı Metotlar ──────────────────────────────────────────────

        /// <summary>Id'ye göre ürünü döndürür; bulunamazsa null döner.</summary>
        public Product GetProductById(int id)
        {
            return _store.Products.Find(p => p.Id == id);
        }

        /// <summary>Barkodun sistemde kayıtlı olup olmadığını kontrol eder.</summary>
        public bool IsBarcodeExists(string barcode)
        {
            return _store.Products.Exists(p => p.Barcode == barcode);
        }

        // ── İstatistik Metotları ───────────────────────────────────────────

        /// <summary>
        /// Stok miktarı belirtilen eşiğin altında veya eşit olan ürünleri döndürür.
        /// Dashboard'da düşük stok uyarısı için kullanılır.
        /// </summary>
        public List<Product> GetLowStockProducts(int threshold = 5)
        {
            return _store.Products.FindAll(p => p.Stock <= threshold)
                         .OrderBy(p => p.Stock)
                         .ToList();
        }

        /// <summary>Tüm ürünlerin alış fiyatı × stok toplamını döndürür (maliyet değeri).</summary>
        public decimal GetTotalInventoryValue()
        {
            return _store.Products.Sum(p => p.BuyPrice * p.Stock);
        }

        /// <summary>Tüm ürünlerin satış fiyatı × stok toplamını döndürür (piyasa değeri).</summary>
        public decimal GetTotalSaleValue()
        {
            return _store.Products.Sum(p => p.SellPrice * p.Stock);
        }

        /// <summary>Stok miktarına göre sıralanmış ilk N ürünü döndürür.</summary>
        public List<Product> GetTopProductsByStock(int count = 5)
        {
            return _store.Products
                         .OrderByDescending(p => p.Stock)
                         .Take(count)
                         .ToList();
        }
    }
}
