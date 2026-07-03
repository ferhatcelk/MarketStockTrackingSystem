using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MarketStokTakip.Models;
using MarketStokTakip.Services;

namespace MarketStokTakip.Forms
{
    /// <summary>
    /// Ürün listesi formu.
    /// Tüm ürünleri DataGridView'de gösterir; arama, filtreleme, güncelleme ve silme işlemleri yapar.
    /// Çift tıklama (Mouse olayı) ile düzenleme ekranı açılır.
    /// </summary>
    public partial class ProductListForm : Form
    {
        private readonly ProductService       _productService;
        private readonly CategoryService      _categoryService;
        private readonly StockMovementService _movementService;

        private readonly ToolTip _toolTip = new ToolTip();

        // Şu an görüntülenen ürün listesi (arama / filtreleme sonrası)
        private List<Product> _currentProducts;

        public ProductListForm(ProductService productService,
                               CategoryService categoryService,
                               StockMovementService movementService)
        {
            InitializeComponent();
            _productService  = productService;
            _categoryService = categoryService;
            _movementService = movementService;

            ConfigureDataGridView();
            LoadCategoryFilter();
            ConfigureToolTips();
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

            // Sütunlar
            dgvProducts.Columns.Add(CreateColumn("Id",       "ID",           40,  false));
            dgvProducts.Columns.Add(CreateColumn("Barcode",  "Barkod",       130, true));
            dgvProducts.Columns.Add(CreateColumn("Name",     "Ürün Adı",     160, true));
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Kategori",
                Width      = 110,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });
            dgvProducts.Columns.Add(CreateColumn("BuyPrice",  "Alış (₺)",    80,  false));
            dgvProducts.Columns.Add(CreateColumn("SellPrice", "Satış (₺)",   80,  false));
            dgvProducts.Columns.Add(CreateColumn("Stock",     "Stok",         60,  false));

            // Çift tıklama olayı (Mouse olayı şartı)
            dgvProducts.CellDoubleClick += new DataGridViewCellEventHandler(dgvProducts_CellDoubleClick);
        }

        private DataGridViewTextBoxColumn CreateColumn(string dataProp, string header,
                                                       int width, bool fill)
        {
            var col = new DataGridViewTextBoxColumn
            {
                DataPropertyName = dataProp,
                HeaderText       = header,
                Width            = width,
                AutoSizeMode     = fill
                    ? DataGridViewAutoSizeColumnMode.Fill
                    : DataGridViewAutoSizeColumnMode.None
            };
            return col;
        }

        // ── Veri Yükleme ───────────────────────────────────────────────────

        private void LoadProducts()
        {
            string keyword    = txtSearch.Text.Trim();
            int categoryId    = 0;

            if (cmbCategoryFilter.SelectedItem is Category selectedCat)
                categoryId = selectedCat.Id;

            // Önce arama, sonra filtreleme
            var searched  = _productService.SearchProducts(keyword);
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
                    p.Category?.Name ?? "-",
                    p.BuyPrice.ToString("N2"),
                    p.SellPrice.ToString("N2"),
                    p.Stock
                );
            }

            lblProductCount.Text = $"Toplam: {_currentProducts.Count} ürün";
        }

        private void LoadCategoryFilter()
        {
            cmbCategoryFilter.Items.Clear();
            cmbCategoryFilter.Items.Add(new Category(0, "— Tüm Kategoriler —"));

            foreach (var cat in _categoryService.GetAllCategories())
                cmbCategoryFilter.Items.Add(cat);

            cmbCategoryFilter.SelectedIndex = 0;
        }

        private void ConfigureToolTips()
        {
            _toolTip.SetToolTip(txtSearch,         "Ürün adı veya barkod ile arayın.");
            _toolTip.SetToolTip(cmbCategoryFilter, "Kategoriye göre filtreleyin.");
            _toolTip.SetToolTip(btnRefresh,        "Listeyi yenileyin.");
            _toolTip.SetToolTip(btnEdit,           "Seçili ürünü düzenleyin.");
            _toolTip.SetToolTip(btnDelete,         "Seçili ürünü silin.");
            _toolTip.SetToolTip(btnAddNew,         "Yeni ürün ekleyin.");
        }

        // ── Arama & Filtreleme ─────────────────────────────────────────────

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbCategoryFilter.SelectedIndex = 0;
            LoadProducts();
        }

        // ── Ürün Düzenleme ─────────────────────────────────────────────────

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenEditForm();
        }

        /// <summary>
        /// Mouse olayı: DataGridView'de bir satıra çift tıklandığında düzenleme formu açılır.
        /// </summary>
        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                OpenEditForm();
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

            using (var editForm = new ProductAddForm(
                _productService, _categoryService, _movementService, product))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                    LoadProducts();
            }
        }

        // ── Ürün Silme ─────────────────────────────────────────────────────

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
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

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

        // ── Yeni Ürün Ekle ─────────────────────────────────────────────────

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            using (var addForm = new ProductAddForm(_productService, _categoryService, _movementService))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                    LoadProducts();
            }
        }

        // ── Yardımcı ───────────────────────────────────────────────────────

        /// <summary>DataGridView'de seçili satırın Product nesnesini döndürür.</summary>
        private Product GetSelectedProduct()
        {
            if (dgvProducts.SelectedRows.Count == 0)
                return null;

            // İlk sütun Id'yi taşır
            var idCell = dgvProducts.SelectedRows[0].Cells[0].Value;
            if (idCell == null) return null;

            int id = Convert.ToInt32(idCell);
            return _productService.GetProductById(id);
        }
    }
}
