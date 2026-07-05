using System.Collections.Generic;
using System.Data.SQLite;
using MarketStokTakip.Models;

namespace MarketStokTakip.Data.Repositories
{
    /// <summary>
    /// Kategori verilerini SQLite veritabanında kalıcı olarak yöneten repository sınıfı.
    /// </summary>
    public class CategoryRepository
    {
        private readonly DatabaseContext _db = DatabaseContext.Instance;

        // ── Tüm Kategorileri Getir ─────────────────────────────────────────

        /// <summary>Veritabanındaki tüm kategorileri döndürür.</summary>
        public List<Category> GetAll()
        {
            var list = new List<Category>();
            using (var conn = _db.CreateConnection())
            using (var cmd  = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, Name FROM Categories ORDER BY Name;";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Category(
                            reader.GetInt32(0),
                            reader.GetString(1)));
                    }
                }
            }
            return list;
        }

        // ── Ekle ──────────────────────────────────────────────────────────

        /// <summary>
        /// Yeni kategoriyi veritabanına kaydeder.
        /// Belirtilen Id ile satır oluşturur (in-memory sayacıyla uyumlu çalışır).
        /// </summary>
        public void Insert(Category category)
        {
            using (var conn = _db.CreateConnection())
            using (var cmd  = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Categories (Id, Name) VALUES (@id, @name);";
                cmd.Parameters.AddWithValue("@id",   category.Id);
                cmd.Parameters.AddWithValue("@name", category.Name);
                cmd.ExecuteNonQuery();
            }
        }

        // ── Güncelle ──────────────────────────────────────────────────────

        /// <summary>Var olan kategorinin adını veritabanında günceller.</summary>
        public void Update(Category category)
        {
            using (var conn = _db.CreateConnection())
            using (var cmd  = conn.CreateCommand())
            {
                cmd.CommandText = "UPDATE Categories SET Name = @name WHERE Id = @id;";
                cmd.Parameters.AddWithValue("@name", category.Name);
                cmd.Parameters.AddWithValue("@id",   category.Id);
                cmd.ExecuteNonQuery();
            }
        }

        // ── Sil ───────────────────────────────────────────────────────────

        /// <summary>Belirtilen Id'ye sahip kategoriyi veritabanından siler.</summary>
        public void Delete(int categoryId)
        {
            using (var conn = _db.CreateConnection())
            using (var cmd  = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Categories WHERE Id = @id;";
                cmd.Parameters.AddWithValue("@id", categoryId);
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
                cmd.CommandText = "SELECT COUNT(*) FROM Categories;";
                return (long)cmd.ExecuteScalar() == 0;
            }
        }
    }
}
