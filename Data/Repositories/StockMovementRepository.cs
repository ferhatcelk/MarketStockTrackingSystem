using System;
using System.Collections.Generic;
using System.Data.SQLite;
using MarketStokTakip.Models;

namespace MarketStokTakip.Data.Repositories
{
    /// <summary>
    /// Stok hareketi kayıtlarını SQLite veritabanında kalıcı olarak yöneten repository sınıfı.
    /// Hareketler yalnızca eklenir; güncelleme ve silme işlemi yapılmaz (audit log prensibi).
    /// </summary>
    public class StockMovementRepository
    {
        private readonly DatabaseContext _db = DatabaseContext.Instance;

        // ── Tüm Hareketleri Getir ─────────────────────────────────────────

        /// <summary>
        /// Veritabanındaki tüm stok hareketlerini en yeniden eskiye doğru döndürür.
        /// Stack yapısıyla uyumlu olması için LIFO sırası korunur.
        /// </summary>
        public IEnumerable<StockMovement> GetAll()
        {
            var list = new List<StockMovement>();
            using (var conn = _db.CreateConnection())
            using (var cmd  = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT ProductName, OperationType, Quantity, DateTime
                    FROM StockMovements
                    ORDER BY Id DESC;";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new StockMovement
                        {
                            ProductName   = reader.GetString(0),
                            OperationType = reader.GetString(1),
                            Quantity      = reader.GetInt32(2),
                            DateTime      = DateTime.Parse(reader.GetString(3))
                        });
                    }
                }
            }
            return list;
        }

        // ── Ekle ──────────────────────────────────────────────────────────

        /// <summary>Yeni bir stok hareketini veritabanına kaydeder.</summary>
        public void Insert(StockMovement movement)
        {
            using (var conn = _db.CreateConnection())
            using (var cmd  = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO StockMovements (ProductName, OperationType, Quantity, DateTime)
                    VALUES (@productName, @operationType, @quantity, @dateTime);";

                cmd.Parameters.AddWithValue("@productName",   movement.ProductName);
                cmd.Parameters.AddWithValue("@operationType", movement.OperationType);
                cmd.Parameters.AddWithValue("@quantity",      movement.Quantity);
                cmd.Parameters.AddWithValue("@dateTime",      movement.DateTime.ToString("o"));
                cmd.ExecuteNonQuery();
            }
        }
    }
}
