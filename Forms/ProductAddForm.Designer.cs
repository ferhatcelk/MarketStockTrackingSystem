namespace MarketStokTakip.Forms
{
    partial class ProductAddForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader    = new System.Windows.Forms.Panel();
            this.pnlAccent    = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlBody      = new System.Windows.Forms.Panel();
            this.lblBarcode   = new System.Windows.Forms.Label();
            this.txtBarcode   = new System.Windows.Forms.TextBox();
            this.lblName      = new System.Windows.Forms.Label();
            this.txtName      = new System.Windows.Forms.TextBox();
            this.lblCategory  = new System.Windows.Forms.Label();
            this.cmbCategory  = new System.Windows.Forms.ComboBox();
            this.lblBuyPrice  = new System.Windows.Forms.Label();
            this.nudBuyPrice  = new System.Windows.Forms.NumericUpDown();
            this.lblSellPrice = new System.Windows.Forms.Label();
            this.nudSellPrice = new System.Windows.Forms.NumericUpDown();
            this.lblStock     = new System.Windows.Forms.Label();
            this.nudStock     = new System.Windows.Forms.NumericUpDown();
            this.pnlButtons   = new System.Windows.Forms.Panel();
            this.btnSave      = new System.Windows.Forms.Button();
            this.btnClear     = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBuyPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSellPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader ──────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 68;
            this.pnlHeader.Controls.Add(this.lblFormTitle);
            this.pnlHeader.Controls.Add(this.pnlAccent);

            this.pnlAccent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.pnlAccent.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlAccent.Height    = 4;

            this.lblFormTitle.AutoSize  = false;
            this.lblFormTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location  = new System.Drawing.Point(20, 16);
            this.lblFormTitle.Size      = new System.Drawing.Size(360, 30);
            this.lblFormTitle.Text      = "➕   Ürün Ekle";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── pnlBody ────────────────────────────────────────────────────
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding   = new System.Windows.Forms.Padding(28, 20, 28, 16);
            this.pnlBody.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblBarcode,  this.txtBarcode,
                this.lblName,     this.txtName,
                this.lblCategory, this.cmbCategory,
                this.lblBuyPrice, this.nudBuyPrice,
                this.lblSellPrice,this.nudSellPrice,
                this.lblStock,    this.nudStock,
                this.pnlButtons
            });

            // Satır düzeni
            int lblX  = 28,  ctrlX = 180, ctrlW = 210;
            int rowH  = 52,  startY = 20;
            var lblF  = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            var ctrlF = new System.Drawing.Font("Segoe UI", 10F);
            var ctrlC = System.Drawing.Color.FromArgb(248, 250, 252);

            MakeLabel(this.lblBarcode,   "Barkod",           lblX, startY + rowH * 0, lblF);
            MakeTextBox(this.txtBarcode, ctrlX, startY + rowH * 0 - 2, ctrlW, ctrlF, ctrlC);

            MakeLabel(this.lblName,   "Ürün Adı",            lblX, startY + rowH * 1, lblF);
            MakeTextBox(this.txtName, ctrlX, startY + rowH * 1 - 2, ctrlW, ctrlF, ctrlC);

            MakeLabel(this.lblCategory, "Kategori",           lblX, startY + rowH * 2, lblF);
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font          = ctrlF;
            this.cmbCategory.BackColor     = ctrlC;
            this.cmbCategory.FlatStyle     = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategory.Location      = new System.Drawing.Point(ctrlX, startY + rowH * 2 - 2);
            this.cmbCategory.Size          = new System.Drawing.Size(ctrlW, 28);

            MakeLabel(this.lblBuyPrice, "Alış Fiyatı (₺)",   lblX, startY + rowH * 3, lblF);
            MakeNumeric(this.nudBuyPrice, ctrlX, startY + rowH * 3 - 2, ctrlW, ctrlF, ctrlC, 2, 999999M);

            MakeLabel(this.lblSellPrice, "Satış Fiyatı (₺)", lblX, startY + rowH * 4, lblF);
            MakeNumeric(this.nudSellPrice, ctrlX, startY + rowH * 4 - 2, ctrlW, ctrlF, ctrlC, 2, 999999M);

            MakeLabel(this.lblStock, "Stok Miktarı",          lblX, startY + rowH * 5, lblF);
            MakeNumeric(this.nudStock, ctrlX, startY + rowH * 5 - 2, ctrlW, ctrlF, ctrlC, 0, 99999M);

            // ── pnlButtons ─────────────────────────────────────────────────
            this.pnlButtons.BackColor = System.Drawing.Color.White;
            this.pnlButtons.Location  = new System.Drawing.Point(28, startY + rowH * 6 + 8);
            this.pnlButtons.Size      = new System.Drawing.Size(362, 48);
            this.pnlButtons.Controls.Add(this.btnClear);
            this.pnlButtons.Controls.Add(this.btnSave);

            this.btnSave.BackColor  = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font       = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor  = System.Drawing.Color.White;
            this.btnSave.Location   = new System.Drawing.Point(0, 0);
            this.btnSave.Size       = new System.Drawing.Size(174, 44);
            this.btnSave.Text       = "💾   Kaydet";
            this.btnSave.Cursor     = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Click     += new System.EventHandler(this.btnSave_Click);

            this.btnClear.BackColor  = System.Drawing.Color.FromArgb(107, 114, 128);
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font       = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor  = System.Drawing.Color.White;
            this.btnClear.Location   = new System.Drawing.Point(184, 0);
            this.btnClear.Size       = new System.Drawing.Size(174, 44);
            this.btnClear.Text       = "✖   Temizle";
            this.btnClear.Cursor     = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Click     += new System.EventHandler(this.btnClear_Click);

            // ── Form ───────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.White;
            this.ClientSize          = new System.Drawing.Size(450, 460);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font                = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox         = false;
            this.MinimizeBox         = false;
            this.Name                = "ProductAddForm";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text                = "Ürün Ekle";

            this.pnlHeader.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBuyPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSellPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void MakeLabel(System.Windows.Forms.Label lbl, string text,
                                int x, int y, System.Drawing.Font font)
        {
            lbl.AutoSize  = false;
            lbl.Font      = font;
            lbl.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lbl.Location  = new System.Drawing.Point(x, y + 6);
            lbl.Size      = new System.Drawing.Size(148, 22);
            lbl.Text      = text;
        }

        private void MakeTextBox(System.Windows.Forms.TextBox txt, int x, int y,
                                  int w, System.Drawing.Font font, System.Drawing.Color bg)
        {
            txt.BackColor   = bg;
            txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txt.Font        = font;
            txt.Location    = new System.Drawing.Point(x, y);
            txt.Size        = new System.Drawing.Size(w, 28);
        }

        private void MakeNumeric(System.Windows.Forms.NumericUpDown nud, int x, int y,
                                  int w, System.Drawing.Font font, System.Drawing.Color bg,
                                  int decimals, decimal max)
        {
            nud.BackColor      = bg;
            nud.BorderStyle    = System.Windows.Forms.BorderStyle.FixedSingle;
            nud.Font           = font;
            nud.Location       = new System.Drawing.Point(x, y);
            nud.Size           = new System.Drawing.Size(w, 28);
            nud.Minimum        = 0;
            nud.Maximum        = max;
            nud.DecimalPlaces  = decimals;
        }

        #endregion

        private System.Windows.Forms.Panel          pnlHeader;
        private System.Windows.Forms.Panel          pnlAccent;
        private System.Windows.Forms.Label          lblFormTitle;
        private System.Windows.Forms.Panel          pnlBody;
        private System.Windows.Forms.Label          lblBarcode;
        private System.Windows.Forms.TextBox        txtBarcode;
        private System.Windows.Forms.Label          lblName;
        private System.Windows.Forms.TextBox        txtName;
        private System.Windows.Forms.Label          lblCategory;
        private System.Windows.Forms.ComboBox       cmbCategory;
        private System.Windows.Forms.Label          lblBuyPrice;
        private System.Windows.Forms.NumericUpDown  nudBuyPrice;
        private System.Windows.Forms.Label          lblSellPrice;
        private System.Windows.Forms.NumericUpDown  nudSellPrice;
        private System.Windows.Forms.Label          lblStock;
        private System.Windows.Forms.NumericUpDown  nudStock;
        private System.Windows.Forms.Panel          pnlButtons;
        private System.Windows.Forms.Button         btnSave;
        private System.Windows.Forms.Button         btnClear;
    }
}
