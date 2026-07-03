using System;
using System.Drawing;
using System.Windows.Forms;
using MarketStokTakip.Services;

namespace MarketStokTakip.Forms
{
    /// <summary>
    /// Stok hareketleri sayfası (UserControl).
    /// Stack içindeki kayıtlar DataGridView'de renkli satırlarla gösterilir.
    /// </summary>
    public partial class StockMovementControl : UserControl
    {
        private readonly StockMovementService _movementService;
        private readonly ToolTip _toolTip = new ToolTip();

        public StockMovementControl(StockMovementService movementService)
        {
            InitializeComponent();
            _movementService = movementService;

            ConfigureDataGridView();
            ConfigureToolTips();
            LoadMovements();
        }

        /// <summary>Ana sayfadan çağrılarak veriyi yeniler.</summary>
        public void RefreshData() => LoadMovements();

        // ── DataGridView ───────────────────────────────────────────────────

        private void ConfigureDataGridView()
        {
            dgvMovements.AutoGenerateColumns = false;
            dgvMovements.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            dgvMovements.MultiSelect         = false;
            dgvMovements.ReadOnly            = true;
            dgvMovements.AllowUserToAddRows  = false;
            dgvMovements.RowHeadersVisible   = false;

            dgvMovements.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText   = "Ürün Adı",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvMovements.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "İşlem Türü", Width = 120,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });
            dgvMovements.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Miktar", Width = 80,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });
            dgvMovements.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tarih & Saat", Width = 170,
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
                int rowIdx = dgvMovements.Rows.Add(
                    m.ProductName,
                    m.OperationType,
                    m.Quantity,
                    m.DateTime.ToString("dd.MM.yyyy HH:mm:ss"));

                // İşlem türüne göre satır arka plan rengi
                var row = dgvMovements.Rows[rowIdx];
                switch (m.OperationType)
                {
                    case "Ekleme":
                        row.DefaultCellStyle.BackColor    = Color.FromArgb(240, 253, 244);
                        row.DefaultCellStyle.ForeColor    = Color.FromArgb(22, 101, 52);
                        break;
                    case "Silme":
                        row.DefaultCellStyle.BackColor    = Color.FromArgb(255, 241, 242);
                        row.DefaultCellStyle.ForeColor    = Color.FromArgb(153, 27, 27);
                        break;
                    case "Güncelleme":
                        row.DefaultCellStyle.BackColor    = Color.FromArgb(255, 251, 235);
                        row.DefaultCellStyle.ForeColor    = Color.FromArgb(146, 64, 14);
                        break;
                }
            }

            lblCount.Text = $"{_movementService.GetMovementCount()} hareket kaydı  "
                          + "  |  🟢 Ekleme   🔴 Silme   🟡 Güncelleme";
        }

        private void ConfigureToolTips()
        {
            _toolTip.SetToolTip(btnRefresh, "Hareket listesini yenileyin.");
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadMovements();
    }
}
