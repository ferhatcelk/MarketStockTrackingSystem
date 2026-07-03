using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MarketStokTakip.Models;
using MarketStokTakip.Services;

namespace MarketStokTakip.Forms
{
    /// <summary>
    /// Ana istatistik sayfası (Dashboard).
    /// KPI kartları, canlı saat, son hareketler, düşük stok uyarıları ve stok değeri gösterir.
    /// Tüm UI bu sınıfın içinde kod olarak inşa edilir (Designer dosyası yoktur).
    /// </summary>
    public partial class DashboardControl : UserControl
    {
        private readonly ProductService       _productService;
        private readonly CategoryService      _categoryService;
        private readonly StockMovementService _movementService;

        // Canlı saat
        private Label _lblClock;

        // KPI kartlarındaki büyük sayı etiketleri (RefreshData'da güncellenir)
        private Label _lblKpiProducts;
        private Label _lblKpiLowStock;
        private Label _lblKpiCategories;
        private Label _lblKpiMovements;

        // Alt bölüm kontrolleri
        private DataGridView _dgvRecent;
        private Panel        _pnlAlertList;
        private Label        _lblBuyValue;
        private Label        _lblSellValue;

        private readonly System.Windows.Forms.Timer _clockTimer;

        // ── Renkler ────────────────────────────────────────────────────────
        private static readonly Color Blue   = Color.FromArgb(59,  130, 246);
        private static readonly Color Red    = Color.FromArgb(239, 68,  68);
        private static readonly Color Amber  = Color.FromArgb(245, 158, 11);
        private static readonly Color Violet = Color.FromArgb(139, 92,  246);
        private static readonly Color Green  = Color.FromArgb(16,  185, 129);
        private static readonly Color BgColor = Color.FromArgb(241, 245, 249);

        public DashboardControl(ProductService productService,
                                CategoryService categoryService,
                                StockMovementService movementService)
        {
            _productService  = productService;
            _categoryService = categoryService;
            _movementService = movementService;

            InitializeComponent();
            BuildLayout();
            RefreshData();

            // Canlı saat zamanlayıcısı
            _clockTimer = new System.Windows.Forms.Timer { Interval = 1000, Enabled = true };
            _clockTimer.Tick += (s, e) => UpdateClock();
        }

        // ── Genel Yenileme ─────────────────────────────────────────────────

        /// <summary>Ana sayfadan çağrılarak tüm istatistikleri günceller.</summary>
        public void RefreshData()
        {
            UpdateKPIs();
            LoadRecentMovements();
            LoadAlerts();
            UpdateClock();
        }

        // ── Veri Güncelleme ────────────────────────────────────────────────

        private void UpdateClock()
        {
            if (_lblClock == null) return;
            var ci = new System.Globalization.CultureInfo("tr-TR");
            _lblClock.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy   |   HH:mm:ss", ci);
        }

        private void UpdateKPIs()
        {
            var products   = _productService.GetAllProducts();
            var lowStock   = _productService.GetLowStockProducts(5);
            var categories = _categoryService.GetAllCategories();
            int todayMoves = _movementService.GetTodayMovements().Count;

            if (_lblKpiProducts   != null) _lblKpiProducts.Text   = products.Count.ToString();
            if (_lblKpiLowStock   != null) _lblKpiLowStock.Text   = lowStock.Count.ToString();
            if (_lblKpiCategories != null) _lblKpiCategories.Text = categories.Count.ToString();
            if (_lblKpiMovements  != null) _lblKpiMovements.Text  = todayMoves.ToString();
        }

        private void LoadRecentMovements()
        {
            if (_dgvRecent == null) return;
            _dgvRecent.Rows.Clear();

            var recents = _movementService.GetRecentMovements(12);
            foreach (var m in recents)
            {
                int rowIdx = _dgvRecent.Rows.Add(
                    m.ProductName,
                    m.OperationType,
                    m.Quantity,
                    m.DateTime.ToString("dd.MM.yy HH:mm"));

                var row = _dgvRecent.Rows[rowIdx];
                switch (m.OperationType)
                {
                    case "Ekleme":
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(21, 128, 61);
                        break;
                    case "Silme":
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(185, 28, 28);
                        break;
                    case "Güncelleme":
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(180, 120, 10);
                        break;
                }
            }
        }

        private void LoadAlerts()
        {
            if (_pnlAlertList == null) return;

            // Paneli temizle
            _pnlAlertList.Controls.Clear();

            var lowStock = _productService.GetLowStockProducts(10);

            if (lowStock.Count == 0)
            {
                var ok = MakeAlertRow("✅  Tüm ürünler yeterli stokta",
                    "—", Color.FromArgb(240, 253, 244), Color.FromArgb(21, 128, 61),
                    Color.FromArgb(21, 128, 61));
                _pnlAlertList.Controls.Add(ok);
            }
            else
            {
                // Listeyi tersine çevir: son eklenen üstte olmasın
                foreach (var p in lowStock)
                {
                    bool critical = p.Stock == 0;
                    var row = MakeAlertRow(
                        p.Name,
                        critical ? "STOK YOK" : $"{p.Stock} adet",
                        critical ? Color.FromArgb(255, 241, 242) : Color.FromArgb(255, 251, 235),
                        critical ? Color.FromArgb(185, 28, 28) : Color.FromArgb(180, 120, 10),
                        Color.FromArgb(30, 41, 59));
                    _pnlAlertList.Controls.Add(row);
                }
            }

            // Stok değerlerini güncelle
            if (_lblBuyValue != null)
                _lblBuyValue.Text  = $"₺ {_productService.GetTotalInventoryValue():N2}";
            if (_lblSellValue != null)
                _lblSellValue.Text = $"₺ {_productService.GetTotalSaleValue():N2}";
        }

        private Panel MakeAlertRow(string name, string value,
                                    Color bgColor, Color valueColor, Color nameColor)
        {
            var row = new Panel
            {
                BackColor = bgColor,
                Dock      = DockStyle.Top,
                Height    = 36,
                Padding   = new Padding(10, 0, 10, 0)
            };

            var lblName = new Label
            {
                Text      = name,
                Font      = new Font("Segoe UI", 9F),
                ForeColor = nameColor,
                AutoSize  = false,
                Location  = new Point(10, 0),
                Size      = new Size(145, 36),
                TextAlign = ContentAlignment.MiddleLeft
            };

            var lblVal = new Label
            {
                Text      = value,
                Font      = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = valueColor,
                AutoSize  = false,
                Anchor    = AnchorStyles.Top | AnchorStyles.Right,
                Location  = new Point(155, 0),
                Size      = new Size(100, 36),
                TextAlign = ContentAlignment.MiddleRight
            };

            row.Controls.Add(lblVal);
            row.Controls.Add(lblName);
            return row;
        }

        // ── UI İnşası ──────────────────────────────────────────────────────

        private void BuildLayout()
        {
            this.BackColor = BgColor;

            // ── HEADER ─────────────────────────────────────────────────────
            var pnlHeader = new Panel { BackColor = Color.White, Dock = DockStyle.Top, Height = 72 };
            var pnlAccent = new Panel { BackColor = Violet, Dock = DockStyle.Top, Height = 4 };
            var lblTitle  = new Label
            {
                Text      = "📊   Genel Bakış  —  Dashboard",
                Font      = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                AutoSize  = false,
                Location  = new Point(24, 14),
                Size      = new Size(500, 36),
                TextAlign = ContentAlignment.MiddleLeft
            };
            _lblClock = new Label
            {
                Font      = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(100, 116, 139),
                AutoSize  = false,
                Anchor    = AnchorStyles.Top | AnchorStyles.Right,
                Location  = new Point(420, 14),
                Size      = new Size(480, 36),
                TextAlign = ContentAlignment.MiddleRight
            };
            pnlHeader.Controls.Add(_lblClock);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(pnlAccent); // accent en üstte (son eklenen = ilk dock)

            // ── KPI SATIRI ─────────────────────────────────────────────────
            var pnlKpi = new Panel { BackColor = BgColor, Dock = DockStyle.Top, Height = 140 };
            var tlpKpi = new TableLayoutPanel
            {
                Dock        = DockStyle.Fill,
                ColumnCount = 4,
                RowCount    = 1,
                BackColor   = Color.Transparent,
                Padding     = new Padding(16, 10, 16, 8),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None
            };
            tlpKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpKpi.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            var card1 = BuildKpiCard("📦", "0", "Toplam Ürün",     Blue,   out _lblKpiProducts);
            var card2 = BuildKpiCard("⚠️", "0", "Düşük Stok (≤5)", Red,    out _lblKpiLowStock);
            var card3 = BuildKpiCard("🗂️", "0", "Kategoriler",     Amber,  out _lblKpiCategories);
            var card4 = BuildKpiCard("📋", "0", "Bugünkü İşlem",   Violet, out _lblKpiMovements);

            card1.Margin = new Padding(0, 0, 6, 0);
            card2.Margin = new Padding(0, 0, 6, 0);
            card3.Margin = new Padding(0, 0, 6, 0);
            card4.Margin = new Padding(0, 0, 0, 0);

            tlpKpi.Controls.Add(card1, 0, 0);
            tlpKpi.Controls.Add(card2, 1, 0);
            tlpKpi.Controls.Add(card3, 2, 0);
            tlpKpi.Controls.Add(card4, 3, 0);
            pnlKpi.Controls.Add(tlpKpi);

            // ── ALT ALAN ──────────────────────────────────────────────────
            var pnlBottom = new Panel { BackColor = BgColor, Dock = DockStyle.Fill };

            // Sağ kolon (uyarılar + değer)
            var pnlRight = new Panel
            {
                BackColor = Color.Transparent,
                Dock      = DockStyle.Right,
                Width     = 295,
                Padding   = new Padding(8, 0, 16, 16)
            };

            // ─ Stok Değeri Kartı
            var pnlValueCard = BuildSectionCard("💰   Stok Değeri", Green);
            pnlValueCard.Dock = DockStyle.Fill;

            var lblBuyTitle = new Label
            {
                Text = "Alış (maliyet) değeri:",
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(12, 40), AutoSize = true
            };
            _lblBuyValue = new Label
            {
                Text = "₺ 0,00",
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(12, 62), AutoSize = true
            };
            var lblSellTitle = new Label
            {
                Text = "Satış (piyasa) değeri:",
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(12, 100), AutoSize = true
            };
            _lblSellValue = new Label
            {
                Text = "₺ 0,00",
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = Green,
                Location = new Point(12, 122), AutoSize = true
            };

            var lblProfit = new Label
            {
                Text = "Kâr potansiyeli:",
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(12, 160), AutoSize = true
            };
            // Kâr potansiyeli = satış - alış (dinamik, _lblSellValue ve _lblBuyValue'dan hesap yapılmaz, ayrı alan)
            var lblProfitVal = new Label
            {
                Name      = "lblProfitValue",
                Text      = "₺ 0,00",
                Font      = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(99, 102, 241),
                Location  = new Point(12, 182),
                AutoSize  = true
            };

            pnlValueCard.Controls.Add(lblProfitVal);
            pnlValueCard.Controls.Add(lblProfit);
            pnlValueCard.Controls.Add(_lblSellValue);
            pnlValueCard.Controls.Add(lblSellTitle);
            pnlValueCard.Controls.Add(_lblBuyValue);
            pnlValueCard.Controls.Add(lblBuyTitle);

            // ─ Düşük Stok Uyarı Kartı
            var pnlAlertsCard = BuildSectionCard("⚠️   Düşük Stok Uyarısı", Red);
            pnlAlertsCard.Dock   = DockStyle.Top;
            pnlAlertsCard.Height = 240;

            _pnlAlertList = new Panel
            {
                BackColor = Color.White,
                Dock      = DockStyle.Fill,
                AutoScroll = true
            };
            pnlAlertsCard.Controls.Add(_pnlAlertList);

            // pnlRight'a ekle: son eklenen Top'ta olur, önceki Fill'i doldurur
            pnlRight.Controls.Add(pnlValueCard);    // Fill — index 0
            pnlRight.Controls.Add(pnlAlertsCard);   // Top  — index 1 (üstte görünür)

            // ─ Son Hareketler Kartı (sol, fill)
            var pnlRecentCard = BuildSectionCard("⏱️   Son Hareketler", Blue);
            pnlRecentCard.Dock    = DockStyle.Fill;
            pnlRecentCard.Padding = new Padding(16, 0, 8, 16);

            _dgvRecent = new DataGridView
            {
                BackgroundColor = Color.White,
                BorderStyle     = BorderStyle.None,
                Dock            = DockStyle.Fill,
                ReadOnly        = true,
                AllowUserToAddRows  = false,
                RowHeadersVisible   = false,
                SelectionMode       = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect         = false,
                EnableHeadersVisualStyles = false,
                GridColor           = Color.FromArgb(226, 232, 240),
                CellBorderStyle     = DataGridViewCellBorderStyle.SingleHorizontal
            };
            _dgvRecent.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(18, 22, 45);
            _dgvRecent.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            _dgvRecent.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            _dgvRecent.ColumnHeadersDefaultCellStyle.Padding   = new Padding(6, 0, 0, 0);
            _dgvRecent.ColumnHeadersHeight                     = 36;
            _dgvRecent.DefaultCellStyle.Font                   = new Font("Segoe UI", 9F);
            _dgvRecent.DefaultCellStyle.Padding                = new Padding(6, 0, 0, 0);
            _dgvRecent.DefaultCellStyle.SelectionBackColor     = Color.FromArgb(219, 234, 254);
            _dgvRecent.DefaultCellStyle.SelectionForeColor     = Color.FromArgb(15, 23, 42);
            _dgvRecent.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            _dgvRecent.RowTemplate.Height = 30;

            _dgvRecent.Columns.Add(new DataGridViewTextBoxColumn
            { HeaderText = "Ürün Adı", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            _dgvRecent.Columns.Add(new DataGridViewTextBoxColumn
            { HeaderText = "İşlem", Width = 100, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });
            _dgvRecent.Columns.Add(new DataGridViewTextBoxColumn
            { HeaderText = "Adet", Width = 55, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });
            _dgvRecent.Columns.Add(new DataGridViewTextBoxColumn
            { HeaderText = "Tarih", Width = 120, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });

            pnlRecentCard.Controls.Add(_dgvRecent);

            // pnlBottom'a ekle: Right panel önce, Fill sonra
            pnlBottom.Controls.Add(pnlRecentCard); // Fill  — index 0
            pnlBottom.Controls.Add(pnlRight);      // Right — index 1

            // UserControl'e ekle: son eklenen Top = en üstte
            this.Controls.Add(pnlBottom); // Fill  — index 0
            this.Controls.Add(pnlKpi);    // Top   — index 1
            this.Controls.Add(pnlHeader); // Top   — index 2 (en üstte)
        }

        // ── Yardımcı UI Builder'lar ────────────────────────────────────────

        private Panel BuildKpiCard(string icon, string initValue, string title,
                                    Color accent, out Label numLabel)
        {
            var card = new Panel { BackColor = Color.White, Dock = DockStyle.Fill };

            // Üst renkli şerit (4px)
            var strip = new Panel { BackColor = accent, Dock = DockStyle.Top, Height = 4 };

            // İkon arka planı
            var iconBg = new Panel
            {
                BackColor = Color.FromArgb(24, accent.R, accent.G, accent.B),
                Location  = new Point(16, 18),
                Size      = new Size(52, 52)
            };
            var iconLbl = new Label
            {
                Text      = icon,
                Font      = new Font("Segoe UI Emoji", 20F),
                ForeColor = accent,
                Dock      = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent
            };
            iconBg.Controls.Add(iconLbl);

            // Büyük sayı
            numLabel = new Label
            {
                Text      = initValue,
                Font      = new Font("Segoe UI", 26F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location  = new Point(82, 12),
                Size      = new Size(120, 40),
                AutoSize  = false,
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Başlık
            var titleLbl = new Label
            {
                Text      = title,
                Font      = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location  = new Point(82, 52),
                Size      = new Size(170, 20),
                AutoSize  = false
            };

            card.Controls.Add(titleLbl);
            card.Controls.Add(numLabel);
            card.Controls.Add(iconBg);
            card.Controls.Add(strip); // son eklenen → en üstte (DockStyle.Top)

            return card;
        }

        private Panel BuildSectionCard(string title, Color accent)
        {
            var card = new Panel { BackColor = Color.White, Padding = new Padding(0, 39, 0, 0) };

            // Başlık satırı (39px)
            var titleBar = new Panel { BackColor = Color.White, Dock = DockStyle.Top, Height = 36 };
            var titleLbl = new Label
            {
                Text      = title,
                Font      = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Dock      = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding   = new Padding(12, 0, 0, 0)
            };
            titleBar.Controls.Add(titleLbl);

            // Üst şerit (3px)
            var strip = new Panel { BackColor = accent, Dock = DockStyle.Top, Height = 3 };

            // Son eklenen ilk docklı olur, sıra: strip → titleBar
            card.Controls.Add(titleBar); // index 0
            card.Controls.Add(strip);    // index 1 → en üstte

            return card;
        }

        // ── Dispose ────────────────────────────────────────────────────────

        protected override void Dispose(bool disposing)
        {
            if (disposing) _clockTimer?.Dispose();
            base.Dispose(disposing);
        }
    }
}
