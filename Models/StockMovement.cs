using System;

namespace MarketStokTakip.Models
{
    /// <summary>
    /// Stok hareketi (ekleme, güncelleme, silme) kaydını temsil eden model sınıfı.
    /// Stack&lt;StockMovement&gt; içinde saklanır.
    /// </summary>
    public class StockMovement
    {
        /// <summary>İşleme konu olan ürünün adı.</summary>
        public string ProductName { get; set; }

        /// <summary>Yapılan işlemin türü: Ekleme, Güncelleme, Silme.</summary>
        public string OperationType { get; set; }

        /// <summary>İşlem yapılan stok miktarı.</summary>
        public int Quantity { get; set; }

        /// <summary>İşlemin gerçekleştiği tarih ve saat.</summary>
        public DateTime DateTime { get; set; }

        public StockMovement() { }

        public StockMovement(string productName, string operationType, int quantity)
        {
            ProductName   = productName;
            OperationType = operationType;
            Quantity      = quantity;
            DateTime      = DateTime.Now;
        }
    }
}
