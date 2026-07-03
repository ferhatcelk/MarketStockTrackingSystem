namespace MarketStokTakip.Forms
{
    partial class StockMovementControl
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
            this.pnlHeader    = new System.Windows.Forms.Panel();
            this.pnlAccent    = new System.Windows.Forms.Panel();
            this.lblTitle     = new System.Windows.Forms.Label();
            this.btnRefresh   = new System.Windows.Forms.Button();
            this.pnlGrid      = new System.Windows.Forms.Panel();
            this.dgvMovements = new System.Windows.Forms.DataGridView();
            this.pnlBottom    = new System.Windows.Forms.Panel();
            this.lblCount     = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovements)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader ──────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height    = 72;
            this.pnlHeader.Controls.Add(this.btnRefresh);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.pnlAccent);

            this.pnlAccent.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.pnlAccent.Dock      = System.Windows.Forms.DockStyle.Top;
            this.pnlAccent.Height    = 4;

            this.lblTitle.AutoSize  = false;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location  = new System.Drawing.Point(24, 14);
            this.lblTitle.Size      = new System.Drawing.Size(400, 36);
            this.lblTitle.Text      = "📦  Stok Hareketleri";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.btnRefresh.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location  = new System.Drawing.Point(820, 19);
            this.btnRefresh.Size      = new System.Drawing.Size(110, 32);
            this.btnRefresh.Text      = "🔄  Yenile";
            this.btnRefresh.Cursor    = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Click    += new System.EventHandler(this.btnRefresh_Click);

            // ── pnlBottom ──────────────────────────────────────────────────
            this.pnlBottom.BackColor = System.Drawing.Color.White;
            this.pnlBottom.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height    = 42;
            this.pnlBottom.Padding   = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.pnlBottom.Controls.Add(this.lblCount);

            this.lblCount.AutoSize  = false;
            this.lblCount.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblCount.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCount.Text      = "0 hareket kaydı";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── pnlGrid ────────────────────────────────────────────────────
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlGrid.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Padding   = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.pnlGrid.Controls.Add(this.dgvMovements);

            // dgvMovements
            this.dgvMovements.BackgroundColor = System.Drawing.Color.White;
            this.dgvMovements.BorderStyle     = System.Windows.Forms.BorderStyle.None;
            this.dgvMovements.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.dgvMovements.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMovements.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvMovements.ColumnHeadersDefaultCellStyle.Padding   = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.dgvMovements.ColumnHeadersHeight                     = 38;
            this.dgvMovements.DefaultCellStyle.Font                   = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvMovements.DefaultCellStyle.Padding                = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.dgvMovements.DefaultCellStyle.SelectionBackColor     = System.Drawing.Color.FromArgb(219, 234, 254);
            this.dgvMovements.DefaultCellStyle.SelectionForeColor     = System.Drawing.Color.FromArgb(15, 23, 42);
            this.dgvMovements.Dock                                    = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovements.EnableHeadersVisualStyles               = false;
            this.dgvMovements.GridColor                               = System.Drawing.Color.FromArgb(226, 232, 240);
            this.dgvMovements.RowTemplate.Height                      = 32;
            this.dgvMovements.CellBorderStyle                         = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;

            // ── UserControl ────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(241, 245, 249);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);
            this.Font                = new System.Drawing.Font("Segoe UI", 9F);
            this.Name                = "StockMovementControl";
            this.Size                = new System.Drawing.Size(960, 600);

            this.pnlHeader.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovements)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel          pnlHeader;
        private System.Windows.Forms.Panel          pnlAccent;
        private System.Windows.Forms.Label          lblTitle;
        private System.Windows.Forms.Button         btnRefresh;
        private System.Windows.Forms.Panel          pnlGrid;
        private System.Windows.Forms.DataGridView   dgvMovements;
        private System.Windows.Forms.Panel          pnlBottom;
        private System.Windows.Forms.Label          lblCount;
    }
}
