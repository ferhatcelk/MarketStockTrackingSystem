namespace MarketStokTakip.Models
{
    /// <summary>
    /// Ürün kategorisini temsil eden model sınıfı.
    /// </summary>
    public class Category
    {
        /// <summary>Kategorinin benzersiz kimliği.</summary>
        public int Id { get; set; }

        /// <summary>Kategori adı.</summary>
        public string Name { get; set; }

        public Category() { }

        public Category(int id, string name)
        {
            Id   = id;
            Name = name;
        }

        public override string ToString() => Name;
    }
}
