using System;
using System.Data.SQLite;
using System.IO;

namespace MarketStokTakip.Data
{
    /// <summary>
    /// SQLite veritabanı bağlantısını yöneten Singleton sınıf.
    /// Tabloları oluşturur ve bağlantı nesnesi sağlar.
    /// </summary>
    public sealed class DatabaseContext
    {
        // ── Singleton ──────────────────────────────────────────────────────
        private static readonly DatabaseContext _instance = new DatabaseContext();
        public static DatabaseContext Instance => _instance;
        private DatabaseContext() { }

        // ── Bağlantı Ayarları ──────────────────────────────────────────────
        private const string DbFileName = "stok_takip.db";

        /// <summary>Veritabanı dosyasının tam yolu (exe ile aynı klasörde).</summary>
        public static string DbPath =>
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DbFileName);

        /// <summary>SQLite bağlantı dizesi.</summary>
        public string ConnectionString =>
            $"Data Source={DbPath};Version=3;Foreign Keys=True;";

        // ── Başlatma ───────────────────────────────────────────────────────

        /// <summary>
        /// Veritabanı dosyasını ve tabloları oluşturur.
        /// Uygulama başlangıcında bir kez çağrılmalıdır.
        /// </summary>
        public void Initialize()
        {
            using (var conn = CreateConnection())
            using (var cmd  = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    -- Kategoriler tablosu
                    CREATE TABLE IF NOT EXISTS Categories (
                        Id   INTEGER PRIMARY KEY,
                        Name TEXT    NOT NULL UNIQUE
                    );

                    -- Ürünler tablosu
                    CREATE TABLE IF NOT EXISTS Products (
                        Id         INTEGER PRIMARY KEY,
                        Barcode    TEXT    NOT NULL UNIQUE,
                        Name       TEXT    NOT NULL,
                        CategoryId INTEGER NOT NULL,
                        BuyPrice   REAL    NOT NULL,
                        SellPrice  REAL    NOT NULL,
                        Stock      INTEGER NOT NULL,
                        FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
                    );

                    -- Stok hareketleri tablosu
                    CREATE TABLE IF NOT EXISTS StockMovements (
                        Id            INTEGER PRIMARY KEY AUTOINCREMENT,
                        ProductName   TEXT    NOT NULL,
                        OperationType TEXT    NOT NULL,
                        Quantity      INTEGER NOT NULL,
                        DateTime      TEXT    NOT NULL
                    );
                ";
                cmd.ExecuteNonQuery();
            }
        }

        // ── Bağlantı Fabrikası ─────────────────────────────────────────────

        /// <summary>Açık bir SQLite bağlantısı döndürür. Çağıran 'using' ile kapatmalıdır.</summary>
        public SQLiteConnection CreateConnection()
        {
            var conn = new SQLiteConnection(ConnectionString);
            conn.Open();
            return conn;
        }
    }
}
