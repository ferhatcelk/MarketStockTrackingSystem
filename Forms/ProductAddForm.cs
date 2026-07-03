using System;
using System.Windows.Forms;
using MarketStokTakip.Models;
using MarketStokTakip.Services;

namespace MarketStokTakip.Forms
{
    /// <summary>
    /// Ürün ekleme / güncelleme diyalog formu.
    /// Hem yeni ürün eklemek hem de mevcut ürünü düzenlemek için kullanılır.
    /// </summary>
    public partial class ProductAddForm : Form
    {
        private readonly ProductService       _productService;
        private readonly CategoryService      _categoryService;
        private readonly StockMovementService _movementService;

        private readonly Product _editingProduct;
        private readonly bool    _isEditMode;

        private readonly ToolTip     _toolTip     = new ToolTip();
        private readonly ErrorProvider _errProvider = new ErrorProvider();

        // ── Yapıcılar ──────────────────────────────────────────────────────

        /// <summary>Yeni ürün ekleme modu.</summary>
        public ProductAddForm(ProductService productService,
                              CategoryService categoryService,
                              StockMovementService movementService)
        {
            InitializeComponent();
            _productService  = productService;
            _categoryService = categoryService;
            _movementService = movementService;
            _isEditMode      = false;

            LoadCategories();
            SetupToolTips();
        }

        /// <summary>Mevcut ürün düzenleme modu.</summary>
        public ProductAddForm(ProductService productService,
                              CategoryService categoryService,
                              StockMovementService movementService,
                              Product productToEdit)
            : this(productService, categoryService, movementService)
        {
            _editingProduct     = productToEdit;
            _isEditMode         = true;
            lblFormTitle.Text   = "✏️   Ürün Güncelle";
            btnSave.Text        = "💾   Güncelle";
            this.Text           = "Ürün Güncelle";

            FillForm(productToEdit);
        }

        // ── Yükleme ────────────────────────────────────────────────────────

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            foreach (var cat in _categoryService.GetAllCategories())
                cmbCategory.Items.Add(cat);

            if (cmbCategory.Items.Count > 0)
                cmbCategory.SelectedIndex = 0;
        }

        private void FillForm(Product p)
        {
            txtBarcode.Text    = p.Barcode;
            txtName.Text       = p.Name;
            nudBuyPrice.Value  = p.BuyPrice;
            nudSellPrice.Value = p.SellPrice;
            nudStock.Value     = p.Stock;

            for (int i = 0; i < cmbCategory.Items.Count; i++)
            {
                if (cmbCategory.Items[i] is Category cat && cat.Id == p.Category?.Id)
                {
                    cmbCategory.SelectedIndex = i;
                    break;
                }
            }
        }

        private void SetupToolTips()
        {
            _toolTip.SetToolTip(txtBarcode,   "Ürün barkod numarasını girin.");
            _toolTip.SetToolTip(txtName,      "Ürün adını girin.");
            _toolTip.SetToolTip(cmbCategory,  "Ürünün kategorisini seçin.");
            _toolTip.SetToolTip(nudBuyPrice,  "Alış fiyatını girin (₺).");
            _toolTip.SetToolTip(nudSellPrice, "Satış fiyatını girin (₺).");
            _toolTip.SetToolTip(nudStock,     "Mevcut stok miktarını girin.");
            _toolTip.SetToolTip(btnSave,      "Ürünü kaydedin.");
            _toolTip.SetToolTip(btnClear,     "Formu temizleyin.");
        }

        // ── Kaydet ─────────────────────────────────────────────────────────

        private void btnSave_Click(object sender, EventArgs e)
        {
            _errProvider.Clear();
            if (!ValidateInputs()) return;

            var  category = cmbCategory.SelectedItem as Category;
            string barcode = txtBarcode.Text.Trim();
            string name    = txtName.Text.Trim();
            decimal buy    = nudBuyPrice.Value;
            decimal sell   = nudSellPrice.Value;
            int stock      = (int)nudStock.Value;

            try
            {
                if (_isEditMode)
                {
                    _productService.UpdateProduct(_editingProduct.Id, barcode, name,
                                                  category, buy, sell, stock);
                    MessageBox.Show("Ürün başarıyla güncellendi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _productService.AddProduct(barcode, name, category, buy, sell, stock);
                    MessageBox.Show("Ürün başarıyla eklendi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Temizle ────────────────────────────────────────────────────────

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        private void ClearForm()
        {
            txtBarcode.Clear();
            txtName.Clear();
            nudBuyPrice.Value  = 0;
            nudSellPrice.Value = 0;
            nudStock.Value     = 0;
            _errProvider.Clear();
            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;
            txtBarcode.Focus();
        }

        // ── Validasyon ─────────────────────────────────────────────────────

        private bool ValidateInputs()
        {
            bool ok = true;

            if (string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                _errProvider.SetError(txtBarcode, "Barkod boş bırakılamaz.");
                ok = false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                _errProvider.SetError(txtName, "Ürün adı boş bırakılamaz.");
                ok = false;
            }

            if (cmbCategory.SelectedItem == null)
            {
                _errProvider.SetError(cmbCategory, "Lütfen bir kategori seçin.");
                ok = false;
            }

            return ok;
        }
    }
}
