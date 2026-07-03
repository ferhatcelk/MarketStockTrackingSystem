using System;
using System.Collections.Generic;
using MarketStokTakip.Data;
using MarketStokTakip.Models;

namespace MarketStokTakip.Services
{
    /// <summary>
    /// Kategori işlemlerini (ekleme, güncelleme, silme, listeleme) yöneten servis sınıfı.
    /// Kategoriler Dictionary&lt;int, Category&gt; yapısında saklanır.
    /// </summary>
    public class CategoryService
    {
        private readonly DataStore _store;

        public CategoryService()
        {
            _store = DataStore.Instance;
        }

        // ── Kategori Ekleme ────────────────────────────────────────────────

        /// <summary>
        /// Yeni kategori ekler. Aynı isimde kategori varsa hata fırlatır.
        /// </summary>
        public void AddCategory(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Kategori adı boş bırakılamaz.");

            if (IsCategoryNameExists(name))
                throw new InvalidOperationException($"'{name}' kategorisi zaten mevcut.");

            int newId       = _store.GetNextCategoryId();
            var newCategory = new Category(newId, name.Trim());

            // Dictionary kullanımı: Id → Category eşlemesi
            _store.Categories[newId] = newCategory;
        }

        // ── Kategori Güncelleme ────────────────────────────────────────────

        /// <summary>
        /// Mevcut bir kategorinin adını günceller.
        /// Ürün nesneleri Category referansına sahip olduğundan değişiklik otomatik yansır.
        /// </summary>
        public void UpdateCategory(int categoryId, string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Kategori adı boş bırakılamaz.");

            if (!_store.Categories.ContainsKey(categoryId))
                throw new KeyNotFoundException("Güncellenecek kategori bulunamadı.");

            // Başka bir kategori aynı isimde mi?
            foreach (var kv in _store.Categories)
            {
                if (kv.Key != categoryId &&
                    kv.Value.Name.Equals(newName.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException($"'{newName}' kategorisi zaten mevcut.");
                }
            }

            _store.Categories[categoryId].Name = newName.Trim();
        }

        // ── Kategori Silme ─────────────────────────────────────────────────

        /// <summary>
        /// Kategoriyi siler. Kategoriye bağlı ürün varsa silme işlemi engellenir.
        /// </summary>
        public void DeleteCategory(int categoryId)
        {
            if (!_store.Categories.ContainsKey(categoryId))
                throw new KeyNotFoundException("Silinecek kategori bulunamadı.");

            // Bu kategoriye ait ürün var mı?
            bool hasProducts = _store.Products.Exists(
                p => p.Category != null && p.Category.Id == categoryId);

            if (hasProducts)
                throw new InvalidOperationException(
                    "Bu kategoriye ait ürünler var. Önce ürünleri silin veya başka kategoriye taşıyın.");

            _store.Categories.Remove(categoryId);
        }

        // ── Kategori Listeleme ─────────────────────────────────────────────

        /// <summary>
        /// Sistemdeki tüm kategorileri liste olarak döndürür.
        /// </summary>
        public List<Category> GetAllCategories()
        {
            return new List<Category>(_store.Categories.Values);
        }

        /// <summary>
        /// Id ile kategori döndürür; bulunamazsa null döner.
        /// </summary>
        public Category GetCategoryById(int id)
        {
            _store.Categories.TryGetValue(id, out var category);
            return category;
        }

        // ── Yardımcı Metot ─────────────────────────────────────────────────

        private bool IsCategoryNameExists(string name)
        {
            foreach (var kv in _store.Categories)
            {
                if (kv.Value.Name.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
    }
}
