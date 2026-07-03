using System;
using System.Windows.Forms;
using MarketStokTakip.Models;
using MarketStokTakip.Services;

namespace MarketStokTakip.Forms
{
    /// <summary>
    /// Kategori yönetim formu.
    /// Kategori ekleme, güncelleme, silme ve listeleme işlemlerini yapar.
    /// </summary>
    public partial class CategoryForm : Form
    {
        private readonly CategoryService _categoryService;
        private readonly ToolTip         _toolTip = new ToolTip();
        private readonly ErrorProvider   _errProvider = new ErrorProvider();

        public CategoryForm(CategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;

            ConfigureDataGridView();
            ConfigureToolTips();
            LoadCategories();
        }

        // ── DataGridView Yapılandırması ────────────────────────────────────

        private void ConfigureDataGridView()
        {
            dgvCategories.AutoGenerateColumns = false;
            dgvCategories.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.MultiSelect         = false;
            dgvCategories.ReadOnly            = true;
            dgvCategories.AllowUserToAddRows  = false;
            dgvCategories.RowHeadersVisible   = false;

            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID", Width = 50, AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Kategori Adı", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Mouse olayı: çift tıkla seçili kategoriyi metin kutusuna yükle
            dgvCategories.CellDoubleClick += new DataGridViewCellEventHandler(dgvCategories_CellDoubleClick);
        }

        // ── Veri Yükleme ───────────────────────────────────────────────────

        private void LoadCategories()
        {
            dgvCategories.Rows.Clear();
            var categories = _categoryService.GetAllCategories();

            foreach (var cat in categories)
                dgvCategories.Rows.Add(cat.Id, cat.Name);

            lblCount.Text = $"Toplam: {categories.Count} kategori";
        }

        private void ConfigureToolTips()
        {
            _toolTip.SetToolTip(txtCategoryName, "Kategori adını girin.");
            _toolTip.SetToolTip(btnAdd,           "Yeni kategori ekleyin.");
            _toolTip.SetToolTip(btnUpdate,        "Seçili kategoriyi güncelleyin.");
            _toolTip.SetToolTip(btnDelete,        "Seçili kategoriyi silin.");
            _toolTip.SetToolTip(btnClear,         "Formu temizleyin.");
        }

        // ── Kategori Ekle ──────────────────────────────────────────────────

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _errProvider.Clear();

            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                _errProvider.SetError(txtCategoryName, "Kategori adı boş bırakılamaz.");
                return;
            }

            try
            {
                _categoryService.AddCategory(txtCategoryName.Text.Trim());
                LoadCategories();
                txtCategoryName.Clear();
                MessageBox.Show("Kategori başarıyla eklendi.", "Başarılı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Kategori Güncelle ──────────────────────────────────────────────

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _errProvider.Clear();

            int categoryId = GetSelectedCategoryId();
            if (categoryId <= 0)
            {
                MessageBox.Show("Lütfen güncellenecek kategoriyi seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                _errProvider.SetError(txtCategoryName, "Kategori adı boş bırakılamaz.");
                return;
            }

            try
            {
                _categoryService.UpdateCategory(categoryId, txtCategoryName.Text.Trim());
                LoadCategories();
                txtCategoryName.Clear();
                MessageBox.Show("Kategori güncellendi.", "Başarılı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Kategori Sil ───────────────────────────────────────────────────

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int categoryId = GetSelectedCategoryId();
            if (categoryId <= 0)
            {
                MessageBox.Show("Lütfen silinecek kategoriyi seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "Seçili kategoriyi silmek istediğinize emin misiniz?\nBu kategoriye ait ürün varsa silme engellenir.",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _categoryService.DeleteCategory(categoryId);
                    LoadCategories();
                    txtCategoryName.Clear();
                    MessageBox.Show("Kategori silindi.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ── Temizle ────────────────────────────────────────────────────────

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCategoryName.Clear();
            _errProvider.Clear();
            dgvCategories.ClearSelection();
        }

        // ── Mouse Olayı: Çift Tıklama ──────────────────────────────────────

        private void dgvCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCategories.Rows[e.RowIndex].Cells[1].Value != null)
                txtCategoryName.Text = dgvCategories.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        // ── Yardımcı ───────────────────────────────────────────────────────

        private int GetSelectedCategoryId()
        {
            if (dgvCategories.SelectedRows.Count == 0)
                return 0;

            var idCell = dgvCategories.SelectedRows[0].Cells[0].Value;
            return idCell != null ? Convert.ToInt32(idCell) : 0;
        }
    }
}
