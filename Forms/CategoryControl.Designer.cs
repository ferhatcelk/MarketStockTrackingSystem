namespace MarketStokTakip.Forms
{
    partial class CategoryControl
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
            this.pnlHeader       = new System.Windows.Forms.Panel();
            this.pnlAccent       = new System.Windows.Forms.Panel();
            this.lblTitle        = new System.Windows.Forms.Label();
            this.pnlBody         = new System.Windows.Forms.Panel();
            this.pnlFormCard     = new System.Windows.Forms.Panel();
            this.lblFormTitle    = new System.Windows.Forms.Label();
            this.lblCatName      = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.btnAdd          = new System.Windows.Forms.Button();
            this.btnUpdate       = new System.Windows.Forms.Button();
            this.btnDelete       = new System.Windows.Forms.Button();
            this.btnClear        = new System.Windows.Forms.Button();
            this.lblHint         = new System.Windows.Forms.Label();
            this.pnlListCard     = new System.Windows.Forms.Panel();
            this.lblCount        = new System.Windows.Forms.Label();
            this.dgvCategories   = new System.Windows.Forms.DataGridView();

            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlFormCard.SuspendLayout();
            this.pnlListCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.SuspendLayout();

            // ── pnlHeader ──────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 72;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.pnlAccent);

            this.pnlAccent.BackColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.pnlAccent.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlAccent.Height    = 4;

            this.lblTitle.AutoSize  = false;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location  = new System.Drawing.Point(24, 14);
            this.lblTitle.Size      = new System.Drawing.Size(400, 36);
            this.lblTitle.Text      = "🗂️  Kategori Yönetimi";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── pnlBody (Fill) ─────────────────────────────────────────────
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlBody.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding   = new System.Windows.Forms.Padding(20);
            this.pnlBody.Controls.Add(this.pnlListCard);
            this.pnlBody.Controls.Add(this.pnlFormCard);

            // ── pnlFormCard (Left) ─────────────────────────────────────────
            this.pnlFormCard.BackColor = System.Drawing.Color.White;
            this.pnlFormCard.Dock      = System.Windows.Forms.DockStyle.Left;
            this.pnlFormCard.Width     = 280;
            this.pnlFormCard.Padding   = new System.Windows.Forms.Padding(20, 20, 20, 16);
            this.pnlFormCard.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblFormTitle, this.lblCatName, this.txtCategoryName,
                this.btnAdd, this.btnUpdate, this.btnDelete, this.btnClear, this.lblHint
            });

            this.lblFormTitle.AutoSize = false;
            this.lblFormTitle.Font     = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblFormTitle.Location = new System.Drawing.Point(20, 20);
            this.lblFormTitle.Size     = new System.Drawing.Size(240, 26);
            this.lblFormTitle.Text     = "Kategori İşlemleri";

            this.lblCatName.AutoSize  = false;
            this.lblCatName.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCatName.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblCatName.Location  = new System.Drawing.Point(20, 60);
            this.lblCatName.Size      = new System.Drawing.Size(240, 20);
            this.lblCatName.Text      = "Kategori Adı";

            this.txtCategoryName.BackColor   = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtCategoryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategoryName.Font        = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCategoryName.Location    = new System.Drawing.Point(20, 82);
            this.txtCategoryName.Size        = new System.Drawing.Size(240, 28);

            int btnY = 124;
            int btnH = 38;
            int btnG = 10;
            SetupFormButton(this.btnAdd,    "➕  Ekle",        btnY + (btnH + btnG) * 0,
                System.Drawing.Color.FromArgb(22, 163, 74));
            SetupFormButton(this.btnUpdate, "✏️  Güncelle",    btnY + (btnH + btnG) * 1,
                System.Drawing.Color.FromArgb(37, 99, 235));
            SetupFormButton(this.btnDelete, "🗑️  Sil",         btnY + (btnH + btnG) * 2,
                System.Drawing.Color.FromArgb(220, 38, 38));
            SetupFormButton(this.btnClear,  "✖  Temizle",     btnY + (btnH + btnG) * 3,
                System.Drawing.Color.FromArgb(107, 114, 128));

            this.btnAdd.Click    += new System.EventHandler(this.btnAdd_Click);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnClear.Click  += new System.EventHandler(this.btnClear_Click);

            this.lblHint.AutoSize  = false;
            this.lblHint.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblHint.Location  = new System.Drawing.Point(20, btnY + (btnH + btnG) * 4 + 6);
            this.lblHint.Size      = new System.Drawing.Size(240, 32);
            this.lblHint.Text      = "💡 Listedeki kategoriye çift tıklayarak\n   düzenleme kutusuna yükleyebilirsiniz.";

            // ── pnlListCard (Fill) ─────────────────────────────────────────
            this.pnlListCard.BackColor = System.Drawing.Color.White;
            this.pnlListCard.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlListCard.Margin    = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.pnlListCard.Padding   = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.pnlListCard.Controls.Add(this.dgvCategories);
            this.pnlListCard.Controls.Add(this.lblCount);

            this.lblCount.AutoSize  = false;
            this.lblCount.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.lblCount.Height    = 30;
            this.lblCount.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCount.Padding   = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblCount.Text      = "0 kategori";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // dgvCategories
            this.dgvCategories.BackgroundColor = System.Drawing.Color.White;
            this.dgvCategories.BorderStyle     = System.Windows.Forms.BorderStyle.None;
            this.dgvCategories.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.dgvCategories.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCategories.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvCategories.ColumnHeadersDefaultCellStyle.Padding   = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.dgvCategories.ColumnHeadersHeight                     = 38;
            this.dgvCategories.DefaultCellStyle.Font                   = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvCategories.DefaultCellStyle.Padding                = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.dgvCategories.DefaultCellStyle.SelectionBackColor     = System.Drawing.Color.FromArgb(219, 234, 254);
            this.dgvCategories.DefaultCellStyle.SelectionForeColor     = System.Drawing.Color.FromArgb(15, 23, 42);
            this.dgvCategories.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.dgvCategories.Dock                                    = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategories.EnableHeadersVisualStyles               = false;
            this.dgvCategories.GridColor                               = System.Drawing.Color.FromArgb(226, 232, 240);
            this.dgvCategories.RowTemplate.Height                      = 32;
            this.dgvCategories.CellBorderStyle                         = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;

            // ── UserControl ────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(241, 245, 249);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font                = new System.Drawing.Font("Segoe UI", 9F);
            this.Name                = "CategoryControl";
            this.Size                = new System.Drawing.Size(960, 600);

            this.pnlHeader.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlFormCard.ResumeLayout(false);
            this.pnlListCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.ResumeLayout(false);
        }

        private void SetupFormButton(System.Windows.Forms.Button btn, string text,
                                      int y, System.Drawing.Color color)
        {
            btn.BackColor  = color;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            btn.Font       = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btn.ForeColor  = System.Drawing.Color.White;
            btn.Location   = new System.Drawing.Point(20, y);
            btn.Size       = new System.Drawing.Size(240, 38);
            btn.Text       = text;
            btn.Cursor     = System.Windows.Forms.Cursors.Hand;
        }

        #endregion

        private System.Windows.Forms.Panel          pnlHeader;
        private System.Windows.Forms.Panel          pnlAccent;
        private System.Windows.Forms.Label          lblTitle;
        private System.Windows.Forms.Panel          pnlBody;
        private System.Windows.Forms.Panel          pnlFormCard;
        private System.Windows.Forms.Label          lblFormTitle;
        private System.Windows.Forms.Label          lblCatName;
        private System.Windows.Forms.TextBox        txtCategoryName;
        private System.Windows.Forms.Button         btnAdd;
        private System.Windows.Forms.Button         btnUpdate;
        private System.Windows.Forms.Button         btnDelete;
        private System.Windows.Forms.Button         btnClear;
        private System.Windows.Forms.Label          lblHint;
        private System.Windows.Forms.Panel          pnlListCard;
        private System.Windows.Forms.Label          lblCount;
        private System.Windows.Forms.DataGridView   dgvCategories;
    }
}
