namespace MarketStokTakip.Forms
{
    partial class MainForm
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
            this.pnlSidebar        = new System.Windows.Forms.Panel();
            this.pnlLogo           = new System.Windows.Forms.Panel();
            this.lblLogoIcon       = new System.Windows.Forms.Label();
            this.lblLogoName       = new System.Windows.Forms.Label();
            this.lblLogoSub        = new System.Windows.Forms.Label();
            this.pnlNavDivider     = new System.Windows.Forms.Panel();
            this.pnlNavArea        = new System.Windows.Forms.Panel();
            this.btnNavDashboard   = new System.Windows.Forms.Button();
            this.btnNavProducts    = new System.Windows.Forms.Button();
            this.btnNavAddProduct  = new System.Windows.Forms.Button();
            this.btnNavCategories  = new System.Windows.Forms.Button();
            this.btnNavMovements   = new System.Windows.Forms.Button();
            this.pnlSidebarBottom  = new System.Windows.Forms.Panel();
            this.btnExit           = new System.Windows.Forms.Button();
            this.lblVersion        = new System.Windows.Forms.Label();
            this.pnlContent        = new System.Windows.Forms.Panel();

            this.pnlSidebar.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlNavArea.SuspendLayout();
            this.pnlSidebarBottom.SuspendLayout();
            this.SuspendLayout();

            // ── pnlSidebar ─────────────────────────────────────────────────
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(18, 22, 45);
            this.pnlSidebar.Dock      = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Width     = 240;
            this.pnlSidebar.Controls.Add(this.pnlNavArea);
            this.pnlSidebar.Controls.Add(this.pnlNavDivider);
            this.pnlSidebar.Controls.Add(this.pnlSidebarBottom);
            this.pnlSidebar.Controls.Add(this.pnlLogo);

            // ── pnlLogo ────────────────────────────────────────────────────
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(11, 14, 28);
            this.pnlLogo.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Height    = 100;
            this.pnlLogo.Padding   = new System.Windows.Forms.Padding(16, 14, 16, 12);
            this.pnlLogo.Controls.Add(this.lblLogoSub);
            this.pnlLogo.Controls.Add(this.lblLogoName);
            this.pnlLogo.Controls.Add(this.lblLogoIcon);

            this.lblLogoIcon.AutoSize  = false;
            this.lblLogoIcon.Font      = new System.Drawing.Font("Segoe UI Emoji", 28F);
            this.lblLogoIcon.ForeColor = System.Drawing.Color.White;
            this.lblLogoIcon.Location  = new System.Drawing.Point(12, 12);
            this.lblLogoIcon.Size      = new System.Drawing.Size(52, 52);
            this.lblLogoIcon.Text      = "🛒";
            this.lblLogoIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblLogoName.AutoSize  = false;
            this.lblLogoName.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblLogoName.ForeColor = System.Drawing.Color.White;
            this.lblLogoName.Location  = new System.Drawing.Point(68, 20);
            this.lblLogoName.Size      = new System.Drawing.Size(158, 24);
            this.lblLogoName.Text      = "Stok Takip";

            this.lblLogoSub.AutoSize  = false;
            this.lblLogoSub.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.lblLogoSub.ForeColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.lblLogoSub.Location  = new System.Drawing.Point(68, 46);
            this.lblLogoSub.Size      = new System.Drawing.Size(158, 18);
            this.lblLogoSub.Text      = "Market Yönetim Sistemi";

            // ── pnlNavDivider ──────────────────────────────────────────────
            this.pnlNavDivider.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlNavDivider.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlNavDivider.Height    = 1;

            // ── pnlNavArea ─────────────────────────────────────────────────
            this.pnlNavArea.BackColor = System.Drawing.Color.FromArgb(18, 22, 45);
            this.pnlNavArea.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlNavArea.Padding   = new System.Windows.Forms.Padding(0, 10, 0, 10);

            int bH = 50, bG = 2, bY = 10;

            SetupNavBtn(this.btnNavDashboard,  "   🏠   Dashboard",          bY + (bH + bG) * 0);
            SetupNavBtn(this.btnNavProducts,   "   📋   Ürün Listesi",       bY + (bH + bG) * 1);
            SetupNavBtn(this.btnNavCategories, "   🗂️   Kategoriler",         bY + (bH + bG) * 3);
            SetupNavBtn(this.btnNavMovements,  "   📦   Stok Hareketleri",   bY + (bH + bG) * 4);

            // Ürün Ekle — özel yeşil renk
            this.btnNavAddProduct.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnNavAddProduct.FlatAppearance.BorderSize = 0;
            this.btnNavAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavAddProduct.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavAddProduct.ForeColor = System.Drawing.Color.White;
            this.btnNavAddProduct.Location  = new System.Drawing.Point(12, bY + (bH + bG) * 2);
            this.btnNavAddProduct.Size      = new System.Drawing.Size(216, 46);
            this.btnNavAddProduct.Text      = "   ➕   Ürün Ekle";
            this.btnNavAddProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavAddProduct.Cursor    = System.Windows.Forms.Cursors.Hand;

            this.pnlNavArea.Controls.Add(this.btnNavMovements);
            this.pnlNavArea.Controls.Add(this.btnNavCategories);
            this.pnlNavArea.Controls.Add(this.btnNavAddProduct);
            this.pnlNavArea.Controls.Add(this.btnNavProducts);
            this.pnlNavArea.Controls.Add(this.btnNavDashboard);

            this.btnNavDashboard.Click   += new System.EventHandler(this.btnNavDashboard_Click);
            this.btnNavProducts.Click    += new System.EventHandler(this.btnNavProducts_Click);
            this.btnNavAddProduct.Click  += new System.EventHandler(this.btnNavAddProduct_Click);
            this.btnNavCategories.Click  += new System.EventHandler(this.btnNavCategories_Click);
            this.btnNavMovements.Click   += new System.EventHandler(this.btnNavMovements_Click);

            // ── pnlSidebarBottom ───────────────────────────────────────────
            this.pnlSidebarBottom.BackColor = System.Drawing.Color.FromArgb(11, 14, 28);
            this.pnlSidebarBottom.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSidebarBottom.Height    = 90;
            this.pnlSidebarBottom.Padding   = new System.Windows.Forms.Padding(12, 10, 12, 6);
            this.pnlSidebarBottom.Controls.Add(this.lblVersion);
            this.pnlSidebarBottom.Controls.Add(this.btnExit);

            this.btnExit.BackColor  = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font       = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor  = System.Drawing.Color.White;
            this.btnExit.Location   = new System.Drawing.Point(12, 10);
            this.btnExit.Size       = new System.Drawing.Size(216, 42);
            this.btnExit.Text       = "🚪   Çıkış";
            this.btnExit.TextAlign  = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Cursor     = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Click     += new System.EventHandler(this.btnExit_Click);

            this.lblVersion.AutoSize  = false;
            this.lblVersion.Font      = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(60, 70, 110);
            this.lblVersion.Location  = new System.Drawing.Point(12, 58);
            this.lblVersion.Size      = new System.Drawing.Size(216, 18);
            this.lblVersion.Text      = "v2.0  —  Üniversite Ödevi 2026";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ── pnlContent ─────────────────────────────────────────────────
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlContent.Dock      = System.Windows.Forms.DockStyle.Fill;

            // ── Form ───────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize          = new System.Drawing.Size(1280, 780);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Font                = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize         = new System.Drawing.Size(960, 620);
            this.Name                = "MainForm";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "Market Stok Takip Sistemi";
            this.WindowState         = System.Windows.Forms.FormWindowState.Maximized;
            this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.Sizable;

            this.pnlSidebar.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlNavArea.ResumeLayout(false);
            this.pnlSidebarBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void SetupNavBtn(System.Windows.Forms.Button btn, string text, int y)
        {
            btn.BackColor  = System.Drawing.Color.FromArgb(18, 22, 45);
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            btn.Font       = new System.Drawing.Font("Segoe UI", 10F);
            btn.ForeColor  = System.Drawing.Color.FromArgb(165, 180, 252);
            btn.Location   = new System.Drawing.Point(0, y);
            btn.Size       = new System.Drawing.Size(240, 50);
            btn.Text       = text;
            btn.TextAlign  = System.Drawing.ContentAlignment.MiddleLeft;
            btn.Cursor     = System.Windows.Forms.Cursors.Hand;
        }

        #endregion

        private System.Windows.Forms.Panel  pnlSidebar;
        private System.Windows.Forms.Panel  pnlLogo;
        private System.Windows.Forms.Label  lblLogoIcon;
        private System.Windows.Forms.Label  lblLogoName;
        private System.Windows.Forms.Label  lblLogoSub;
        private System.Windows.Forms.Panel  pnlNavDivider;
        private System.Windows.Forms.Panel  pnlNavArea;
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Button btnNavProducts;
        private System.Windows.Forms.Button btnNavAddProduct;
        private System.Windows.Forms.Button btnNavCategories;
        private System.Windows.Forms.Button btnNavMovements;
        private System.Windows.Forms.Panel  pnlSidebarBottom;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label  lblVersion;
        private System.Windows.Forms.Panel  pnlContent;
    }
}
