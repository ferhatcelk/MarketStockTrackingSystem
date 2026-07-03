namespace MarketStokTakip.Forms
{
    partial class StockMovementForm
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
            this.pnlHeader    = new System.Windows.Forms.Panel();
            this.lblTitle     = new System.Windows.Forms.Label();
            this.pnlToolbar   = new System.Windows.Forms.Panel();
            this.btnRefresh   = new System.Windows.Forms.Button();
            this.pnlGrid      = new System.Windows.Forms.Panel();
            this.dgvMovements = new System.Windows.Forms.DataGridView();
            this.pnlBottom    = new System.Windows.Forms.Panel();
            this.lblCount     = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovements)).BeginInit();
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
            this.lblTitle.Text      = "📦 Stok Hareketleri";

            // ── pnlToolbar ─────────────────────────────────────────────────
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(227, 242, 253);
            this.pnlToolbar.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Height    = 50;
            this.pnlToolbar.Padding   = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.pnlToolbar.Controls.Add(this.btnRefresh);

            this.btnRefresh.BackColor  = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font       = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor  = System.Drawing.Color.White;
            this.btnRefresh.Location   = new System.Drawing.Point(10, 8);
            this.btnRefresh.Size       = new System.Drawing.Size(100, 30);
            this.btnRefresh.Text       = "🔄 Yenile";
            this.btnRefresh.Cursor     = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Click     += new System.EventHandler(this.btnRefresh_Click);

            // ── pnlGrid ────────────────────────────────────────────────────
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Padding   = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnlGrid.Controls.Add(this.dgvMovements);

            this.dgvMovements.BackgroundColor     = System.Drawing.Color.White;
            this.dgvMovements.BorderStyle         = System.Windows.Forms.BorderStyle.None;
            this.dgvMovements.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.dgvMovements.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMovements.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvMovements.ColumnHeadersHeight                     = 35;
            this.dgvMovements.DefaultCellStyle.Font                   = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvMovements.DefaultCellStyle.SelectionBackColor     = System.Drawing.Color.FromArgb(187, 222, 251);
            this.dgvMovements.DefaultCellStyle.SelectionForeColor     = System.Drawing.Color.Black;
            this.dgvMovements.Dock                                    = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovements.EnableHeadersVisualStyles               = false;
            this.dgvMovements.GridColor                               = System.Drawing.Color.FromArgb(207, 226, 255);
            this.dgvMovements.RowTemplate.Height                      = 28;

            // ── pnlBottom ──────────────────────────────────────────────────
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(240, 245, 255);
            this.pnlBottom.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height    = 40;
            this.pnlBottom.Padding   = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlBottom.Controls.Add(this.lblCount);

            this.lblCount.AutoSize  = true;
            this.lblCount.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.lblCount.Location  = new System.Drawing.Point(12, 10);
            this.lblCount.Text      = "Toplam 0 hareket kayıtlı";

            // ── Form ───────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.White;
            this.ClientSize          = new System.Drawing.Size(720, 500);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.Font                = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize         = new System.Drawing.Size(720, 500);
            this.Name                = "StockMovementForm";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text                = "Stok Hareketleri";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovements)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel          pnlHeader;
        private System.Windows.Forms.Label          lblTitle;
        private System.Windows.Forms.Panel          pnlToolbar;
        private System.Windows.Forms.Button         btnRefresh;
        private System.Windows.Forms.Panel          pnlGrid;
        private System.Windows.Forms.DataGridView   dgvMovements;
        private System.Windows.Forms.Panel          pnlBottom;
        private System.Windows.Forms.Label          lblCount;
    }
}
