using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MarketStokTakip.Models;
using MarketStokTakip.Services;

namespace MarketStokTakip.Forms
{
    /// <summary>
    /// Ürün listesi sayfası (UserControl).
    /// MainForm içindeki içerik paneline yüklenir.
    /// DataGridView'de listeleme, arama, filtreleme, düzenleme ve silme işlemleri yapılır.
    /// </summary>
    public partial class ProductListControl : UserControl
    {
        private readonly ProductService       _productService;
        private readonly CategoryService      _categoryService;
        private readonly StockMovementService _movementService;

        private List<Product> _currentProducts;
        private readonly ToolTip _toolTip = new ToolTip();

        public ProductListControl(ProductService productService,
                                  CategoryService categoryService,
                                  StockMovementService movementService)
        {
            InitializeComponent();
            _productService  = productService;
            _categoryService = categoryService;
            _movementService = movementService;

            ConfigureDataGridView();
            ConfigureToolTips();
            LoadCategoryFilter();
            LoadProducts();
        }

        /// <summary>Ana sayfadan çağrılarak veriyi yeniler.</summary>
        public void RefreshData()
        {
            LoadCategoryFilter();
            LoadProducts();
        }

        // ── DataGridView Yapılandırması ────────────────────────────────────

        private void ConfigureDataGridView()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect         = false;
            dgvProducts.ReadOnly            = true;
            dgvProducts.AllowUserToAddRows  = false;
            dgvProducts.RowHeadersVisible   = false;

            dgvProducts.Columns.Add(CreateColumn("Id",        "ID",          50,  false));
            dgvProducts.Columns.Add(CreateColumn("Barcode",   "Barkod",      140, false));
            dgvProducts.Columns.Add(CreateColumn("Name",      "Ürün Adı",    200, true));
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText   = "Kategori",
                Width        = 120,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });
            dgvProducts.Columns.Add(CreateColumn("BuyPrice",  "Alış (₺)",    90,  false));
            dgvProducts.Columns.Add(CreateColumn("SellPrice", "Satış (₺)",   90,  false));
            dgvProducts.Columns.Add(CreateColumn("Stock",     "Stok",         70,  false));

            // Mouse olayı: çift tıkla düzenleme ekranı açılır
            dgvProducts.CellDoubleClick += new DataGridViewCellEventHandler(dgvProducts_CellDoubleClick);
        }

        private DataGridViewTextBoxColumn CreateColumn(string dataProp, string header, int width, bool fill)
        {
            return new DataGridViewTextBoxColumn
            {
                DataPropertyName = dataProp,
                HeaderText       = header,
                Width            = width,
                AutoSizeMode     = fill
                    ? DataGridViewAutoSizeColumnMode.Fill
                    : DataGridViewAutoSizeColumnMode.None
            };
        }

        // ── Veri Yükleme ───────────────────────────────────────────────────

        private void LoadProducts()
        {
            string keyword   = txtSearch.Text.Trim();
            int    categoryId = 0;

            if (cmbCategoryFilter.SelectedItem is Category selectedCat && selectedCat.Id > 0)
                categoryId = selectedCat.Id;

            var searched     = _productService.SearchProducts(keyword);
            _currentProducts = categoryId > 0
                ? searched.FindAll(p => p.Category != null && p.Category.Id == categoryId)
                : searched;

            dgvProducts.Rows.Clear();

            foreach (var p in _currentProducts)
            {
                dgvProducts.Rows.Add(
                    p.Id,
                    p.Barcode,
                    p.Name,
                    p.Category?.Name ?? "—",
                    p.BuyPrice.ToString("N2"),
                    p.SellPrice.ToString("N2"),
                    p.Stock);
            }

            lblProductCount.Text = $"{_currentProducts.Count} ürün listeleniyor";
        }

        private void LoadCategoryFilter()
        {
            // Seçili kategoriyi hatırla
            int previousId = 0;
            if (cmbCategoryFilter.SelectedItem is Category prev)
                previousId = prev.Id;

            cmbCategoryFilter.Items.Clear();
            cmbCategoryFilter.Items.Add(new Category(0, "Tüm Kategoriler"));

            foreach (var cat in _categoryService.GetAllCategories())
                cmbCategoryFilter.Items.Add(cat);

            // Önceki seçimi geri yükle
            cmbCategoryFilter.SelectedIndex = 0;
            for (int i = 0; i < cmbCategoryFilter.Items.Count; i++)
            {
                if (cmbCategoryFilter.Items[i] is Category c && c.Id == previousId)
                {
                    cmbCategoryFilter.SelectedIndex = i;
                    break;
                }
            }
        }

        private void ConfigureToolTips()
        {
            _toolTip.SetToolTip(txtSearch,         "Ürün adı veya barkod ile arayın.");
            _toolTip.SetToolTip(cmbCategoryFilter, "Kategoriye göre filtreleyin.");
            _toolTip.SetToolTip(btnRefresh,        "Listeyi yenileyin.");
            _toolTip.SetToolTip(btnEdit,           "Seçili ürünü düzenleyin (veya çift tıklayın).");
            _toolTip.SetToolTip(btnDelete,         "Seçili ürünü silin.");
            _toolTip.SetToolTip(btnAddNew,         "Yeni ürün ekleyin.");
        }

        // ── Arama & Filtreleme ─────────────────────────────────────────────

        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadProducts();

        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e) => LoadProducts();

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbCategoryFilter.SelectedIndex = 0;
            LoadProducts();
        }

        // ── Düzenleme ──────────────────────────────────────────────────────

        private void btnEdit_Click(object sender, EventArgs e) => OpenEditForm();

        /// <summary>Mouse olayı: satıra çift tıklandığında düzenleme ekranı açılır.</summary>
        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) OpenEditForm();
        }

        private void OpenEditForm()
        {
            var product = GetSelectedProduct();
            if (product == null)
            {
                MessageBox.Show("Lütfen düzenlemek istediğiniz ürünü seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var form = new ProductAddForm(_productService, _categoryService, _movementService, product))
            {
                if (form.ShowDialog(this.ParentForm) == DialogResult.OK)
                    LoadProducts();
            }
        }

        // ── Silme ──────────────────────────────────────────────────────────

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var product = GetSelectedProduct();
            if (product == null)
            {
                MessageBox.Show("Lütfen silmek istediğiniz ürünü seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"'{product.Name}' ürününü silmek istediğinize emin misiniz?",
                "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _productService.DeleteProduct(product.Id);
                    LoadProducts();
                    MessageBox.Show("Ürün başarıyla silindi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ── Yeni Ürün ──────────────────────────────────────────────────────

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            using (var form = new ProductAddForm(_productService, _categoryService, _movementService))
            {
                if (form.ShowDialog(this.ParentForm) == DialogResult.OK)
                    LoadProducts();
            }
        }

        // ── Yardımcı ───────────────────────────────────────────────────────

        private Product GetSelectedProduct()
        {
            if (dgvProducts.SelectedRows.Count == 0) return null;

            var idCell = dgvProducts.SelectedRows[0].Cells[0].Value;
            if (idCell == null) return null;

            return _productService.GetProductById(Convert.ToInt32(idCell));
        }
    }
}
