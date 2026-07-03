using System;
using System.Windows.Forms;
using MarketStokTakip.Services;

namespace MarketStokTakip.Forms
{
    /// <summary>
    /// Stok hareketleri geçmişini gösteren form.
    /// Stack&lt;StockMovement&gt; içindeki kayıtlar DataGridView'de listelenir (en yeni üstte).
    /// </summary>
    public partial class StockMovementForm : Form
    {
        private readonly StockMovementService _movementService;
        private readonly ToolTip              _toolTip = new ToolTip();

        public StockMovementForm(StockMovementService movementService)
        {
            InitializeComponent();
            _movementService = movementService;

            ConfigureDataGridView();
            ConfigureToolTips();
            LoadMovements();
        }

        // ── DataGridView Yapılandırması ────────────────────────────────────

        private void ConfigureDataGridView()
        {
            dgvMovements.AutoGenerateColumns = false;
            dgvMovements.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            dgvMovements.MultiSelect         = false;
            dgvMovements.ReadOnly            = true;
            dgvMovements.AllowUserToAddRows  = false;
            dgvMovements.RowHeadersVisible   = false;

            // Sütunlar
            dgvMovements.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ürün Adı",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvMovements.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText   = "İşlem Türü",
                Width        = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });
            dgvMovements.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText   = "Miktar",
                Width        = 70,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });
            dgvMovements.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText   = "Tarih & Saat",
                Width        = 160,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });
        }

        // ── Veri Yükleme ───────────────────────────────────────────────────

        private void LoadMovements()
        {
            dgvMovements.Rows.Clear();
            var movements = _movementService.GetAllMovements();

            foreach (var m in movements)
            {
                int rowIndex = dgvMovements.Rows.Add(
                    m.ProductName,
                    m.OperationType,
                    m.Quantity,
                    m.DateTime.ToString("dd.MM.yyyy HH:mm:ss"));

                // İşlem türüne göre satır rengi
                var row = dgvMovements.Rows[rowIndex];
                switch (m.OperationType)
                {
                    case "Ekleme":
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(232, 245, 233);
                        break;
                    case "Silme":
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 235, 238);
                        break;
                    case "Güncelleme":
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 248, 225);
                        break;
                }
            }

            lblCount.Text = $"Toplam {_movementService.GetMovementCount()} hareket kayıtlı  "
                          + "| 🟢 Ekleme  🔴 Silme  🟡 Güncelleme";
        }

        private void ConfigureToolTips()
        {
            _toolTip.SetToolTip(btnRefresh, "Listeyi yenileyin.");
        }

        // ── Yenile Butonu ──────────────────────────────────────────────────

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMovements();
        }
    }
}
