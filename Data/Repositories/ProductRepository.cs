using System.Collections.Generic;
using System.Data.SQLite;
using MarketStokTakip.Models;

namespace MarketStokTakip.Data.Repositories
{
    /// <summary>
    /// Ürün verilerini SQLite veritabanında kalıcı olarak yöneten repository sınıfı.
    /// </summary>
    public class ProductRepository
    {
        private readonly DatabaseContext _db = DatabaseContext.Instance;

        // ── Tüm Ürünleri Getir ────────────────────────────────────────────

        /// <summary>
        /// Veritabanındaki tüm ürünleri döndürür.
        /// Kategori nesnelerini bulmak için categories sözlüğünü kullanır.
        /// </summary>
        public List<Product> GetAll(Dictionary<int, Category> categories)
        {
            var list = new List<Product>();
            using (var conn = _db.CreateConnection())
            using (var cmd  = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT Id, Barcode, Name, CategoryId, BuyPrice, SellPrice, Stock
                    FROM Products
                    ORDER BY Id;";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int catId = reader.GetInt32(3);
                        categories.TryGetValue(catId, out var category);

                        list.Add(new Product(
                            reader.GetInt32(0),       // Id
                            reader.GetString(1),      // Barcode
                            reader.GetString(2),      // Name
                            category,                 // Category nesnesi (null olabilir)
                            (decimal)reader.GetDouble(4),  // BuyPrice
                            (decimal)reader.GetDouble(5),  // SellPrice
                            reader.GetInt32(6)));     // Stock
                    }
                }
            }
            return list;
        }

        // ── Ekle ──────────────────────────────────────────────────────────

        /// <summary>Yeni ürünü veritabanına kaydeder.</summary>
        public void Insert(Product product)
        {
            using (var conn = _db.CreateConnection())
            using (var cmd  = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO Products (Id, Barcode, Name, CategoryId, BuyPrice, SellPrice, Stock)
                    VALUES (@id, @barcode, @name, @catId, @buyPrice, @sellPrice, @stock);";

                cmd.Parameters.AddWithValue("@id",       product.Id);
                cmd.Parameters.AddWithValue("@barcode",  product.Barcode);
                cmd.Parameters.AddWithValue("@name",     product.Name);
                cmd.Parameters.AddWithValue("@catId",    product.Category?.Id ?? 0);
                cmd.Parameters.AddWithValue("@buyPrice", (double)product.BuyPrice);
                cmd.Parameters.AddWithValue("@sellPrice",(double)product.SellPrice);
                cmd.Parameters.AddWithValue("@stock",    product.Stock);
                cmd.ExecuteNonQuery();
            }
        }

        // ── Güncelle ──────────────────────────────────────────────────────

        /// <summary>Var olan ürünün tüm alanlarını veritabanında günceller.</summary>
        public void Update(Product product)
        {
            using (var conn = _db.CreateConnection())
            using (var cmd  = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    UPDATE Products
                    SET Barcode   = @barcode,
                        Name      = @name,
                        CategoryId = @catId,
                        BuyPrice  = @buyPrice,
                        SellPrice = @sellPrice,
                        Stock     = @stock
                    WHERE Id = @id;";

                cmd.Parameters.AddWithValue("@id",       product.Id);
                cmd.Parameters.AddWithValue("@barcode",  product.Barcode);
                cmd.Parameters.AddWithValue("@name",     product.Name);
                cmd.Parameters.AddWithValue("@catId",    product.Category?.Id ?? 0);
                cmd.Parameters.AddWithValue("@buyPrice", (double)product.BuyPrice);
                cmd.Parameters.AddWithValue("@sellPrice",(double)product.SellPrice);
                cmd.Parameters.AddWithValue("@stock",    product.Stock);
                cmd.ExecuteNonQuery();
            }
        }

        // ── Sil ───────────────────────────────────────────────────────────

        /// <summary>Belirtilen Id'ye sahip ürünü veritabanından siler.</summary>
        public void Delete(int productId)
        {
            using (var conn = _db.CreateConnection())
            using (var cmd  = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Products WHERE Id = @id;";
                cmd.Parameters.AddWithValue("@id", productId);
                cmd.ExecuteNonQuery();
            }
        }

        // ── Var mı Kontrolü ───────────────────────────────────────────────

        /// <summary>Tabloda hiç kayıt yoksa true döner (ilk başlatma için).</summary>
        public bool IsEmpty()
        {
            using (var conn = _db.CreateConnection())
            using (var cmd  = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Products;";
                return (long)cmd.ExecuteScalar() == 0;
            }
        }
    }
}
