using System;
using System.Windows.Forms;
using MarketStokTakip.Data;

namespace MarketStokTakip
{
    /// <summary>
    /// Uygulamanın giriş noktası.
    /// Veritabanı başlatma işlemi burada yapılır.
    /// </summary>
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // 1. SQLite veritabanını ve tabloları başlat
                DatabaseContext.Instance.Initialize();

                // 2. Verileri SQLite'tan bellek yapılarına yükle
                DataStore.Instance.LoadFromDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Veritabanı başlatılırken hata oluştu:\n\n{ex.Message}\n\n" +
                    $"Uygulama yine de çalışacak ancak veriler kaydedilmeyecektir.",
                    "Veritabanı Hatası",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            Application.Run(new Forms.MainForm());
        }
    }
}
