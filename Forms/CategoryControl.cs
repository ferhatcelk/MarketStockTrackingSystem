using System;
using System.Windows.Forms;
using MarketStokTakip.Models;
using MarketStokTakip.Services;

namespace MarketStokTakip.Forms
{
    /// <summary>
    /// Kategori yönetim sayfası (UserControl).
    /// Sol tarafta form, sağ tarafta DataGridView bulunur.
    /// </summary>
    public partial class CategoryControl : UserControl
    {
        private readonly CategoryService _categoryService;
        private readonly ToolTip         _toolTip    = new ToolTip();
        private readonly ErrorProvider   _errProvider = new ErrorProvider();

        public CategoryControl(CategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;

            ConfigureDataGridView();
            ConfigureToolTips();
            LoadCategories();
        }

        /// <summary>Ana sayfadan çağrılarak veriyi yeniler.</summary>
        public void RefreshData() => LoadCategories();

        // ── DataGridView ───────────────────────────────────────────────────

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
                HeaderText = "ID",
                Width      = 60,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            });
            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText   = "Kategori Adı",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Mouse olayı: çift tıklayınca metin kutusuna yükle
            dgvCategories.CellDoubleClick +=
                new DataGridViewCellEventHandler(dgvCategories_CellDoubleClick);
        }

        // ── Veri Yükleme ───────────────────────────────────────────────────

        private void LoadCategories()
        {
            dgvCategories.Rows.Clear();
            var list = _categoryService.GetAllCategories();
            foreach (var cat in list)
                dgvCategories.Rows.Add(cat.Id, cat.Name);

            lblCount.Text = $"{list.Count} kategori";
        }

        private void ConfigureToolTips()
        {
            _toolTip.SetToolTip(txtCategoryName, "Kategori adını girin.");
            _toolTip.SetToolTip(btnAdd,    "Yeni kategori ekleyin.");
            _toolTip.SetToolTip(btnUpdate, "Seçili kategoriyi güncelleyin.");
            _toolTip.SetToolTip(btnDelete, "Seçili kategoriyi silin.");
            _toolTip.SetToolTip(btnClear,  "Formu temizleyin.");
        }

        // ── Ekle ───────────────────────────────────────────────────────────

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
                MessageBox.Show("Kategori eklendi.", "Başarılı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Güncelle ───────────────────────────────────────────────────────

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _errProvider.Clear();
            int id = GetSelectedId();
            if (id <= 0)
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
                _categoryService.UpdateCategory(id, txtCategoryName.Text.Trim());
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

        // ── Sil ────────────────────────────────────────────────────────────

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = GetSelectedId();
            if (id <= 0)
            {
                MessageBox.Show("Lütfen silinecek kategoriyi seçin.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var confirm = MessageBox.Show(
                "Seçili kategoriyi silmek istediğinize emin misiniz?\n" +
                "Bu kategoriye bağlı ürün varsa silme engellenir.",
                "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                _categoryService.DeleteCategory(id);
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

        // ── Temizle ────────────────────────────────────────────────────────

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCategoryName.Clear();
            _errProvider.Clear();
            dgvCategories.ClearSelection();
        }

        // ── Mouse Olayı ────────────────────────────────────────────────────

        private void dgvCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCategories.Rows[e.RowIndex].Cells[1].Value != null)
                txtCategoryName.Text = dgvCategories.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        // ── Yardımcı ───────────────────────────────────────────────────────

        private int GetSelectedId()
        {
            if (dgvCategories.SelectedRows.Count == 0) return 0;
            var cell = dgvCategories.SelectedRows[0].Cells[0].Value;
            return cell != null ? Convert.ToInt32(cell) : 0;
        }
    }
}
