using System;
using System.Windows.Forms;

namespace MarketStokTakip
{
    /// <summary>
    /// Uygulamanın giriş noktası.
    /// </summary>
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.MainForm());
        }
    }
}
