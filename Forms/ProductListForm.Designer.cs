namespace MarketStokTakip.Forms
{
    partial class ProductListForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader         = new System.Windows.Forms.Panel();
            this.lblTitle          = new System.Windows.Forms.Label();
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
            this.btnAddNew         = new System.Windows.Forms.Button();
            this.btnEdit           = new System.Windows.Forms.Button();
            this.btnDelete         = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader ──────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 60;
            this.pnlHeader.Controls.Add(this.lblTitle);

            this.lblTitle.AutoSize  = true;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location  = new System.Drawing.Point(16, 14);
            this.lblTitle.Text      = "📋 Ürün Listesi";

            // ── pnlToolbar ─────────────────────────────────────────────────
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(227, 242, 253);
            this.pnlToolbar.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Height    = 60;
            this.pnlToolbar.Padding   = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.pnlToolbar.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblSearch, this.txtSearch,
                this.lblFilter, this.cmbCategoryFilter,
                this.btnRefresh
            });

            // Arama
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(14, 18);
            this.lblSearch.Text     = "Ara:";

            this.txtSearch.Font        = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location    = new System.Drawing.Point(50, 14);
            this.txtSearch.Size        = new System.Drawing.Size(180, 25);
            this.txtSearch.BackColor   = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // Filtre
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFilter.Location = new System.Drawing.Point(244, 18);
            this.lblFilter.Text     = "Kategori:";

            this.cmbCategoryFilter.DropDownStyle         = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoryFilter.Font                  = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCategoryFilter.Location              = new System.Drawing.Point(308, 14);
            this.cmbCategoryFilter.Size                  = new System.Drawing.Size(170, 25);
            this.cmbCategoryFilter.FlatStyle             = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategoryFilter.SelectedIndexChanged += new System.EventHandler(this.cmbCategoryFilter_SelectedIndexChanged);

            // Yenile butonu
            this.btnRefresh.BackColor  = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font       = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor  = System.Drawing.Color.White;
            this.btnRefresh.Location   = new System.Drawing.Point(490, 12);
            this.btnRefresh.Size       = new System.Drawing.Size(90, 30);
            this.btnRefresh.Text       = "🔄 Yenile";
            this.btnRefresh.Cursor     = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Click     += new System.EventHandler(this.btnRefresh_Click);

            // ── pnlGrid ────────────────────────────────────────────────────
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Padding   = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnlGrid.Controls.Add(this.dgvProducts);

            // DataGridView
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.BorderStyle     = System.Windows.Forms.BorderStyle.None;
            this.dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvProducts.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvProducts.ColumnHeadersHeight                     = 35;
            this.dgvProducts.DefaultCellStyle.Font                   = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvProducts.DefaultCellStyle.SelectionBackColor     = System.Drawing.Color.FromArgb(187, 222, 251);
            this.dgvProducts.DefaultCellStyle.SelectionForeColor     = System.Drawing.Color.Black;
            this.dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 247, 255);
            this.dgvProducts.Dock                                    = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.EnableHeadersVisualStyles               = false;
            this.dgvProducts.GridColor                               = System.Drawing.Color.FromArgb(207, 226, 255);
            this.dgvProducts.RowTemplate.Height                      = 28;

            // ── pnlBottom ──────────────────────────────────────────────────
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(240, 245, 255);
            this.pnlBottom.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height    = 55;
            this.pnlBottom.Padding   = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.pnlBottom.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblProductCount, this.btnDelete, this.btnEdit, this.btnAddNew
            });

            this.lblProductCount.AutoSize  = true;
            this.lblProductCount.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProductCount.ForeColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.lblProductCount.Location  = new System.Drawing.Point(14, 17);
            this.lblProductCount.Text      = "Toplam: 0 ürün";

            // btnAddNew
            SetupBottomButton(this.btnAddNew,  "➕ Yeni Ürün", 590, System.Drawing.Color.FromArgb(56, 142, 60));
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);

            // btnEdit
            SetupBottomButton(this.btnEdit,    "✏️ Düzenle",    460, System.Drawing.Color.FromArgb(25, 118, 210));
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnDelete
            SetupBottomButton(this.btnDelete,  "🗑️ Sil",        330, System.Drawing.Color.FromArgb(211, 47, 47));
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // ── Form ───────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.White;
            this.ClientSize          = new System.Drawing.Size(820, 560);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.Font                = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize         = new System.Drawing.Size(820, 560);
            this.Name                = "ProductListForm";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text                = "Ürün Listesi";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        private void SetupBottomButton(System.Windows.Forms.Button btn, string text,
                                        int x, System.Drawing.Color color)
        {
            btn.BackColor  = color;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            btn.Font       = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btn.ForeColor  = System.Drawing.Color.White;
            btn.Location   = new System.Drawing.Point(x, 8);
            btn.Size       = new System.Drawing.Size(120, 36);
            btn.Text       = text;
            btn.Cursor     = System.Windows.Forms.Cursors.Hand;
        }

        #endregion

        private System.Windows.Forms.Panel           pnlHeader;
        private System.Windows.Forms.Label           lblTitle;
        private System.Windows.Forms.Panel           pnlToolbar;
        private System.Windows.Forms.Label           lblSearch;
        private System.Windows.Forms.TextBox         txtSearch;
        private System.Windows.Forms.Label           lblFilter;
        private System.Windows.Forms.ComboBox        cmbCategoryFilter;
        private System.Windows.Forms.Button          btnRefresh;
        private System.Windows.Forms.Panel           pnlGrid;
        private System.Windows.Forms.DataGridView    dgvProducts;
        private System.Windows.Forms.Panel           pnlBottom;
        private System.Windows.Forms.Label           lblProductCount;
        private System.Windows.Forms.Button          btnAddNew;
        private System.Windows.Forms.Button          btnEdit;
        private System.Windows.Forms.Button          btnDelete;
    }
}
