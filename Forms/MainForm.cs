using System;
using System.Drawing;
using System.Windows.Forms;
using MarketStokTakip.Services;

namespace MarketStokTakip.Forms
{
    /// <summary>
    /// Uygulama kabuğu (shell). Koyu indigo sidebar + içerik paneli.
    /// Her sayfa birer UserControl olarak içerik panelinde yüklenir.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly ProductService       _productService;
        private readonly CategoryService      _categoryService;
        private readonly StockMovementService _movementService;

        // Sayfa örnekleri (ömür boyu canlı)
        private readonly DashboardControl      _pageDashboard;
        private readonly ProductListControl    _pageProducts;
        private readonly CategoryControl       _pageCategories;
        private readonly StockMovementControl  _pageMovements;

        private Button _activeNavBtn;
        private readonly ToolTip _toolTip = new ToolTip();

        // ── Renk Paleti (vibrant indigo) ───────────────────────────────────
        private static readonly Color SidebarBg     = Color.FromArgb(18, 22, 45);
        private static readonly Color LogoBg         = Color.FromArgb(11, 14, 28);
        private static readonly Color NavActive      = Color.FromArgb(99, 102, 241);  // vivid indigo
        private static readonly Color NavHover       = Color.FromArgb(30, 36, 80);
        private static readonly Color NavTextDim     = Color.FromArgb(165, 180, 252);
        private static readonly Color NavTextBright  = Color.White;

        public MainForm()
        {
            InitializeComponent();

            _movementService = new StockMovementService();
            _productService  = new ProductService(_movementService);
            _categoryService = new CategoryService();

            // Sayfa örnekleri
            _pageDashboard  = new DashboardControl(_productService, _categoryService, _movementService);
            _pageProducts   = new ProductListControl(_productService, _categoryService, _movementService);
            _pageCategories = new CategoryControl(_categoryService);
            _pageMovements  = new StockMovementControl(_movementService);

            HookHoverEffects();
            SetupToolTips();

            // Başlangıç sayfası: Dashboard
            NavigateTo(_pageDashboard, btnNavDashboard);
        }

        // ── Navigasyon ─────────────────────────────────────────────────────

        private void NavigateTo(UserControl page, Button navBtn)
        {
            pnlContent.SuspendLayout();
            pnlContent.Controls.Clear();
            page.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(page);
            pnlContent.ResumeLayout();

            if (_activeNavBtn != null && _activeNavBtn != navBtn)
                SetNavStyle(_activeNavBtn, false);

            _activeNavBtn = navBtn;
            SetNavStyle(navBtn, true);
        }

        private void SetNavStyle(Button btn, bool active)
        {
            btn.BackColor = active ? NavActive : SidebarBg;
            btn.ForeColor = active ? NavTextBright : NavTextDim;
        }

        // ── Hover Efektleri ────────────────────────────────────────────────

        private void HookHoverEffects()
        {
            Button[] navPages = { btnNavDashboard, btnNavProducts, btnNavCategories, btnNavMovements };
            foreach (var btn in navPages)
            {
                btn.MouseEnter += (s, e) =>
                {
                    if ((Button)s != _activeNavBtn)
                    { ((Button)s).BackColor = NavHover; ((Button)s).ForeColor = NavTextBright; }
                };
                btn.MouseLeave += (s, e) =>
                {
                    if ((Button)s != _activeNavBtn)
                    { ((Button)s).BackColor = SidebarBg; ((Button)s).ForeColor = NavTextDim; }
                };
            }

            btnNavAddProduct.MouseEnter += (s, e) => ((Button)s).BackColor = Color.FromArgb(5, 150, 105);
            btnNavAddProduct.MouseLeave += (s, e) => ((Button)s).BackColor = Color.FromArgb(16, 185, 129);
            btnExit.MouseEnter          += (s, e) => ((Button)s).BackColor = Color.FromArgb(153, 27, 27);
            btnExit.MouseLeave          += (s, e) => ((Button)s).BackColor = Color.FromArgb(185, 28, 28);
        }

        private void SetupToolTips()
        {
            _toolTip.SetToolTip(btnNavDashboard,  "Genel bakış ve istatistikler.");
            _toolTip.SetToolTip(btnNavProducts,   "Ürün listesini görüntüleyin.");
            _toolTip.SetToolTip(btnNavAddProduct, "Yeni ürün ekleyin.");
            _toolTip.SetToolTip(btnNavCategories, "Kategorileri yönetin.");
            _toolTip.SetToolTip(btnNavMovements,  "Stok hareketi geçmişi.");
            _toolTip.SetToolTip(btnExit,          "Uygulamayı kapatın.");
        }

        // ── Buton Olayları ─────────────────────────────────────────────────

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            _pageDashboard.RefreshData();
            NavigateTo(_pageDashboard, btnNavDashboard);
        }

        private void btnNavProducts_Click(object sender, EventArgs e)
        {
            _pageProducts.RefreshData();
            NavigateTo(_pageProducts, btnNavProducts);
        }

        private void btnNavAddProduct_Click(object sender, EventArgs e)
        {
            using (var dlg = new ProductAddForm(_productService, _categoryService, _movementService))
                dlg.ShowDialog(this);

            // Dashboard veya ürün listesi aktifse yenile
            if (_activeNavBtn == btnNavDashboard) _pageDashboard.RefreshData();
            if (_activeNavBtn == btnNavProducts)  _pageProducts.RefreshData();
        }

        private void btnNavCategories_Click(object sender, EventArgs e)
        {
            _pageCategories.RefreshData();
            NavigateTo(_pageCategories, btnNavCategories);
        }

        private void btnNavMovements_Click(object sender, EventArgs e)
        {
            _pageMovements.RefreshData();
            NavigateTo(_pageMovements, btnNavMovements);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Uygulamadan çıkmak istediğinize emin misiniz?",
                    "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }
    }
}
