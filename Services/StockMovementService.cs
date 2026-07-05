using System.Collections.Generic;
using MarketStokTakip.Data;
using MarketStokTakip.Models;

namespace MarketStokTakip.Services
{
    /// <summary>
    /// Stok hareketi geçmişini Stack&lt;StockMovement&gt; yapısı üzerinden yöneten servis sınıfı.
    /// Her ürün işlemi (ekleme/güncelleme/silme) bu servis aracılığıyla kaydedilir.
    /// </summary>
    public class StockMovementService
    {
        private readonly DataStore _store;

        public StockMovementService()
        {
            _store = DataStore.Instance;
        }

        // ── Hareket Ekleme ─────────────────────────────────────────────────

        /// <summary>
        /// Yeni bir stok hareketi kaydı oluşturarak Stack'in tepesine ekler.
        /// </summary>
        /// <param name="productName">İşleme konu olan ürünün adı.</param>
        /// <param name="operationType">İşlem türü: Ekleme, Güncelleme, Silme.</param>
        /// <param name="quantity">İşlem yapılan stok miktarı.</param>
        public void AddMovement(string productName, string operationType, int quantity)
        {
            var movement = new StockMovement(productName, operationType, quantity);

            // Stack kullanımı: En son işlem en üstte (LIFO)
            _store.MovementHistory.Push(movement);
            _store.MovementRepo.Insert(movement);   // ← SQLite'a kaydet
        }

        // ── Tüm Hareketleri Listele ────────────────────────────────────────

        /// <summary>
        /// Stack'teki tüm stok hareketlerini en yeniden en eskiye doğru sıralı döndürür.
        /// Stack bozulmadan okunur.
        /// </summary>
        public List<StockMovement> GetAllMovements()
        {
            // Stack.ToArray() en üstten (son eklenen) başlar — bu doğal sıra bize uygundur
            return new List<StockMovement>(_store.MovementHistory.ToArray());
        }

        // ── Son Hareketi Görüntüle ─────────────────────────────────────────

        /// <summary>
        /// Stack boş değilse en son gerçekleştirilen hareketi döndürür; yoksa null döner.
        /// </summary>
        public StockMovement GetLastMovement()
        {
            if (_store.MovementHistory.Count == 0)
                return null;

            return _store.MovementHistory.Peek();
        }

        /// <summary>Toplam hareket sayısını döndürür.</summary>
        public int GetMovementCount() => _store.MovementHistory.Count;

        // ── İstatistik Metotları ──────────────────────────────────────────

        /// <summary>Bugün gerçekleşen hareketleri döndürür.</summary>
        public System.Collections.Generic.List<StockMovement> GetTodayMovements()
        {
            var today = System.DateTime.Today;
            var result = new System.Collections.Generic.List<StockMovement>();
            foreach (var m in _store.MovementHistory)
            {
                if (m.DateTime.Date == today)
                    result.Add(m);
            }
            return result;
        }

        /// <summary>En son N hareketi döndürür (Stack'ten LIFO sırasıyla).</summary>
        public System.Collections.Generic.List<StockMovement> GetRecentMovements(int count = 10)
        {
            var result = new System.Collections.Generic.List<StockMovement>();
            int taken = 0;
            foreach (var m in _store.MovementHistory)
            {
                if (taken >= count) break;
                result.Add(m);
                taken++;
            }
            return result;
        }

        /// <summary>Belirli bir işlem türüne ait toplam hareketi sayar.</summary>
        public int CountByType(string operationType)
        {
            int count = 0;
            foreach (var m in _store.MovementHistory)
                if (m.OperationType == operationType) count++;
            return count;
        }
    }
}
