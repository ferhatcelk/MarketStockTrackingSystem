namespace MarketStokTakip.Forms
{
    partial class ProductListControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader         = new System.Windows.Forms.Panel();
            this.pnlAccent         = new System.Windows.Forms.Panel();
            this.lblTitle          = new System.Windows.Forms.Label();
            this.btnAddNew         = new System.Windows.Forms.Button();
            this.pnlToolbar        = new System.Windows.Forms.Panel();
            this.lblSearch         = new System.Windows.Forms.Label();
            this.txtSearch         = new System.Windows.Forms.TextBox();
            this.lblFilter         = new System.Windows.Forms.Label();
            this.cmbCategoryFilter = new System.Windows.Forms.ComboBox();
            this.btnRefresh        = new System.Windows.Forms.Button();
            this.pnlGrid           = new System.Windows.Forms.Panel();
            this.dgvProducts       = new System.Windows.Forms.DataGridView();
            this.pnlBottom         = new System.Windows.Forms.Panel();
            this.lblProductCount   = new System.Windows.Forms.Label();
            this.btnEdit           = new System.Windows.Forms.Button();
            this.btnDelete         = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader ──────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 72;
            this.pnlHeader.Controls.Add(this.btnAddNew);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.pnlAccent);

            // pnlAccent — 4px mavi şerit
            this.pnlAccent.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.pnlAccent.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlAccent.Height    = 4;

            // lblTitle
            this.lblTitle.AutoSize  = false;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location  = new System.Drawing.Point(24, 14);
            this.lblTitle.Size      = new System.Drawing.Size(350, 36);
            this.lblTitle.Text      = "📋  Ürün Listesi";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // btnAddNew
            this.btnAddNew.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnAddNew.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnAddNew.FlatAppearance.BorderSize = 0;
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddNew.ForeColor = System.Drawing.Color.White;
            this.btnAddNew.Location  = new System.Drawing.Point(780, 18);
            this.btnAddNew.Size      = new System.Drawing.Size(130, 34);
            this.btnAddNew.Text      = "➕  Ürün Ekle";
            this.btnAddNew.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnAddNew.Click    += new System.EventHandler(this.btnAddNew_Click);

            // ── pnlToolbar ─────────────────────────────────────────────────
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlToolbar.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Height    = 54;
            this.pnlToolbar.Padding   = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.pnlToolbar.Controls.Add(this.btnRefresh);
            this.pnlToolbar.Controls.Add(this.cmbCategoryFilter);
            this.pnlToolbar.Controls.Add(this.lblFilter);
            this.pnlToolbar.Controls.Add(this.txtSearch);
            this.pnlToolbar.Controls.Add(this.lblSearch);

            // lblSearch
            this.lblSearch.AutoSize  = false;
            this.lblSearch.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblSearch.Location  = new System.Drawing.Point(16, 16);
            this.lblSearch.Size      = new System.Drawing.Size(40, 22);
            this.lblSearch.Text      = "Ara:";

            // txtSearch
            this.txtSearch.BackColor   = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font        = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location    = new System.Drawing.Point(60, 14);
            this.txtSearch.Size        = new System.Drawing.Size(200, 24);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // lblFilter
            this.lblFilter.AutoSize  = false;
            this.lblFilter.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblFilter.Location  = new System.Drawing.Point(280, 16);
            this.lblFilter.Size      = new System.Drawing.Size(72, 22);
            this.lblFilter.Text      = "Kategori:";

            // cmbCategoryFilter
            this.cmbCategoryFilter.DropDownStyle         = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoryFilter.Font                  = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCategoryFilter.FlatStyle             = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategoryFilter.Location              = new System.Drawing.Point(356, 13);
            this.cmbCategoryFilter.Size                  = new System.Drawing.Size(180, 24);
            this.cmbCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.cmbCategoryFilter_SelectedIndexChanged);

            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font       = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor  = System.Drawing.Color.White;
            this.btnRefresh.Location   = new System.Drawing.Point(552, 11);
            this.btnRefresh.Size       = new System.Drawing.Size(100, 28);
            this.btnRefresh.Text       = "🔄  Yenile";
            this.btnRefresh.Cursor     = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Click     += new System.EventHandler(this.btnRefresh_Click);

            // ── pnlBottom ──────────────────────────────────────────────────
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height    = 54;
            this.pnlBottom.Padding   = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.pnlBottom.Controls.Add(this.btnDelete);
            this.pnlBottom.Controls.Add(this.btnEdit);
            this.pnlBottom.Controls.Add(this.lblProductCount);

            // lblProductCount
            this.lblProductCount.AutoSize  = false;
            this.lblProductCount.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProductCount.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblProductCount.Location  = new System.Drawing.Point(16, 16);
            this.lblProductCount.Size      = new System.Drawing.Size(200, 22);
            this.lblProductCount.Text      = "0 ürün listeleniyor";

            // btnEdit
            this.btnEdit.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location  = new System.Drawing.Point(680, 9);
            this.btnEdit.Size      = new System.Drawing.Size(120, 34);
            this.btnEdit.Text      = "✏️  Düzenle";
            this.btnEdit.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Click    += new System.EventHandler(this.btnEdit_Click);

            // btnDelete
            this.btnDelete.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location  = new System.Drawing.Point(814, 9);
            this.btnDelete.Size      = new System.Drawing.Size(100, 34);
            this.btnDelete.Text      = "🗑️  Sil";
            this.btnDelete.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Click    += new System.EventHandler(this.btnDelete_Click);

            // ── pnlGrid ────────────────────────────────────────────────────
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlGrid.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Padding   = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.pnlGrid.Controls.Add(this.dgvProducts);

            // dgvProducts
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.BorderStyle     = System.Windows.Forms.BorderStyle.None;
            this.dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvProducts.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvProducts.ColumnHeadersDefaultCellStyle.Padding   = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.dgvProducts.ColumnHeadersHeight                     = 38;
            this.dgvProducts.DefaultCellStyle.Font                   = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvProducts.DefaultCellStyle.Padding                = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.dgvProducts.DefaultCellStyle.SelectionBackColor     = System.Drawing.Color.FromArgb(219, 234, 254);
            this.dgvProducts.DefaultCellStyle.SelectionForeColor     = System.Drawing.Color.FromArgb(15, 23, 42);
            this.dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.dgvProducts.Dock                                    = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.EnableHeadersVisualStyles               = false;
            this.dgvProducts.GridColor                               = System.Drawing.Color.FromArgb(226, 232, 240);
            this.dgvProducts.RowTemplate.Height                      = 32;
            this.dgvProducts.CellBorderStyle                         = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;

            // ── UserControl ────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(241, 245, 249);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.Font                = new System.Drawing.Font("Segoe UI", 9F);
            this.Name                = "ProductListControl";
            this.Size                = new System.Drawing.Size(960, 600);

            this.pnlHeader.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel          pnlHeader;
        private System.Windows.Forms.Panel          pnlAccent;
        private System.Windows.Forms.Label          lblTitle;
        private System.Windows.Forms.Button         btnAddNew;
        private System.Windows.Forms.Panel          pnlToolbar;
        private System.Windows.Forms.Label          lblSearch;
        private System.Windows.Forms.TextBox        txtSearch;
        private System.Windows.Forms.Label          lblFilter;
        private System.Windows.Forms.ComboBox       cmbCategoryFilter;
        private System.Windows.Forms.Button         btnRefresh;
        private System.Windows.Forms.Panel          pnlGrid;
        private System.Windows.Forms.DataGridView   dgvProducts;
        private System.Windows.Forms.Panel          pnlBottom;
        private System.Windows.Forms.Label          lblProductCount;
        private System.Windows.Forms.Button         btnEdit;
        private System.Windows.Forms.Button         btnDelete;
    }
}
