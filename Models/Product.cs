namespace MarketStokTakip.Models
{
    /// <summary>
    /// Markette satılan bir ürünü temsil eden model sınıfı.
    /// </summary>
    public class Product
    {
        /// <summary>Ürünün benzersiz kimliği.</summary>
        public int Id { get; set; }

        /// <summary>Barkod numarası.</summary>
        public string Barcode { get; set; }

        /// <summary>Ürün adı.</summary>
        public string Name { get; set; }

        /// <summary>Ürünün ait olduğu kategori.</summary>
        public Category Category { get; set; }

        /// <summary>Alış fiyatı (TL).</summary>
        public decimal BuyPrice { get; set; }

        /// <summary>Satış fiyatı (TL).</summary>
        public decimal SellPrice { get; set; }

        /// <summary>Mevcut stok miktarı.</summary>
        public int Stock { get; set; }

        public Product() { }

        public Product(int id, string barcode, string name, Category category,
                       decimal buyPrice, decimal sellPrice, int stock)
        {
            Id       = id;
            Barcode  = barcode;
            Name     = name;
            Category = category;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
            Stock    = stock;
        }

        public override string ToString() => $"{Barcode} - {Name}";
    }
}
