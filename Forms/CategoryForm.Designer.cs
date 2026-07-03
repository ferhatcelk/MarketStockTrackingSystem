namespace MarketStokTakip.Forms
{
    partial class CategoryForm
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
            this.pnlHeader       = new System.Windows.Forms.Panel();
            this.lblTitle        = new System.Windows.Forms.Label();
            this.pnlLeft         = new System.Windows.Forms.Panel();
            this.lblInputTitle   = new System.Windows.Forms.Label();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.btnAdd          = new System.Windows.Forms.Button();
            this.btnUpdate       = new System.Windows.Forms.Button();
            this.btnDelete       = new System.Windows.Forms.Button();
            this.btnClear        = new System.Windows.Forms.Button();
            this.lblHint         = new System.Windows.Forms.Label();
            this.pnlRight        = new System.Windows.Forms.Panel();
            this.lblListTitle    = new System.Windows.Forms.Label();
            this.dgvCategories   = new System.Windows.Forms.DataGridView();
            this.lblCount        = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
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
            this.lblTitle.Text      = "🗂️ Kategori Yönetimi";

            // ── pnlLeft (form paneli) ──────────────────────────────────────
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Dock      = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Width     = 260;
            this.pnlLeft.Padding   = new System.Windows.Forms.Padding(16, 16, 16, 16);
            this.pnlLeft.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblInputTitle,
                this.lblCategoryName, this.txtCategoryName,
                this.btnAdd, this.btnUpdate, this.btnDelete, this.btnClear,
                this.lblHint
            });

            this.lblInputTitle.AutoSize = true;
            this.lblInputTitle.Font     = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblInputTitle.Location = new System.Drawing.Point(0, 10);
            this.lblInputTitle.Text     = "Kategori İşlemleri";

            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCategoryName.Location = new System.Drawing.Point(0, 48);
            this.lblCategoryName.Text     = "Kategori Adı:";

            this.txtCategoryName.BackColor   = System.Drawing.Color.FromArgb(240, 245, 255);
            this.txtCategoryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategoryName.Font        = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCategoryName.Location    = new System.Drawing.Point(0, 68);
            this.txtCategoryName.Size        = new System.Drawing.Size(220, 28);

            int btnY = 110;
            int btnGap = 48;
            SetupActionButton(this.btnAdd,    "➕ Ekle",        btnY + btnGap * 0, System.Drawing.Color.FromArgb(56, 142, 60));
            SetupActionButton(this.btnUpdate, "✏️ Güncelle",    btnY + btnGap * 1, System.Drawing.Color.FromArgb(25, 118, 210));
            SetupActionButton(this.btnDelete, "🗑️ Sil",         btnY + btnGap * 2, System.Drawing.Color.FromArgb(211, 47, 47));
            SetupActionButton(this.btnClear,  "🗑 Temizle",     btnY + btnGap * 3, System.Drawing.Color.FromArgb(158, 158, 158));

            this.btnAdd.Click    += new System.EventHandler(this.btnAdd_Click);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnClear.Click  += new System.EventHandler(this.btnClear_Click);

            this.lblHint.AutoSize  = true;
            this.lblHint.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblHint.ForeColor = System.Drawing.Color.Gray;
            this.lblHint.Location  = new System.Drawing.Point(0, btnY + btnGap * 4 + 8);
            this.lblHint.Text      = "💡 Çift tıklayarak kategoriyi seçin.";

            // ── pnlRight (liste paneli) ────────────────────────────────────
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Padding   = new System.Windows.Forms.Padding(10, 16, 16, 10);
            this.pnlRight.Controls.Add(this.lblCount);
            this.pnlRight.Controls.Add(this.dgvCategories);
            this.pnlRight.Controls.Add(this.lblListTitle);

            this.lblListTitle.AutoSize = true;
            this.lblListTitle.Font     = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblListTitle.Location = new System.Drawing.Point(10, 10);
            this.lblListTitle.Text     = "Kategori Listesi";

            this.dgvCategories.BackgroundColor     = System.Drawing.Color.White;
            this.dgvCategories.BorderStyle         = System.Windows.Forms.BorderStyle.None;
            this.dgvCategories.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.dgvCategories.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCategories.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvCategories.ColumnHeadersHeight                     = 32;
            this.dgvCategories.DefaultCellStyle.Font                   = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvCategories.DefaultCellStyle.SelectionBackColor     = System.Drawing.Color.FromArgb(187, 222, 251);
            this.dgvCategories.DefaultCellStyle.SelectionForeColor     = System.Drawing.Color.Black;
            this.dgvCategories.EnableHeadersVisualStyles               = false;
            this.dgvCategories.GridColor                               = System.Drawing.Color.FromArgb(207, 226, 255);
            this.dgvCategories.Location                                = new System.Drawing.Point(10, 38);
            this.dgvCategories.Size                                    = new System.Drawing.Size(340, 340);
            this.dgvCategories.RowTemplate.Height                      = 28;

            this.lblCount.AutoSize  = true;
            this.lblCount.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.lblCount.Location  = new System.Drawing.Point(10, 385);
            this.lblCount.Text      = "Toplam: 0 kategori";

            // ── Form ───────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.White;
            this.ClientSize          = new System.Drawing.Size(640, 460);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlHeader);
            this.Font                = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox         = false;
            this.MinimizeBox         = false;
            this.Name                = "CategoryForm";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text                = "Kategori Yönetimi";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.ResumeLayout(false);
        }

        private void SetupActionButton(System.Windows.Forms.Button btn, string text,
                                        int y, System.Drawing.Color color)
        {
            btn.BackColor  = color;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            btn.Font       = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btn.ForeColor  = System.Drawing.Color.White;
            btn.Location   = new System.Drawing.Point(0, y);
            btn.Size       = new System.Drawing.Size(220, 36);
            btn.Text       = text;
            btn.Cursor     = System.Windows.Forms.Cursors.Hand;
        }

        #endregion

        private System.Windows.Forms.Panel          pnlHeader;
        private System.Windows.Forms.Label          lblTitle;
        private System.Windows.Forms.Panel          pnlLeft;
        private System.Windows.Forms.Label          lblInputTitle;
        private System.Windows.Forms.Label          lblCategoryName;
        private System.Windows.Forms.TextBox        txtCategoryName;
        private System.Windows.Forms.Button         btnAdd;
        private System.Windows.Forms.Button         btnUpdate;
        private System.Windows.Forms.Button         btnDelete;
        private System.Windows.Forms.Button         btnClear;
        private System.Windows.Forms.Label          lblHint;
        private System.Windows.Forms.Panel          pnlRight;
        private System.Windows.Forms.Label          lblListTitle;
        private System.Windows.Forms.DataGridView   dgvCategories;
        private System.Windows.Forms.Label          lblCount;
    }
}
