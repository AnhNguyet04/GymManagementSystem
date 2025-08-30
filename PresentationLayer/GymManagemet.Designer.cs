namespace PresentationLayer
{
    partial class GymManagemet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GymManagemet));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pnMain = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbThietbi = new System.Windows.Forms.Label();
            this.lbNhanvien = new System.Windows.Forms.Label();
            this.lbHocvien = new System.Windows.Forms.Label();
            this.lbTrangchu = new System.Windows.Forms.Label();
            this.lbLop = new System.Windows.Forms.Label();
            this.lbDangXuat = new System.Windows.Forms.Label();
            this.lbBaoCao = new System.Windows.Forms.Label();
            this.lbThanhtoan = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pnMain
            // 
            this.pnMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnMain.BackgroundImage")));
            this.pnMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 49);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1474, 565);
            this.pnMain.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.lbThietbi);
            this.panel1.Controls.Add(this.lbNhanvien);
            this.panel1.Controls.Add(this.lbHocvien);
            this.panel1.Controls.Add(this.lbTrangchu);
            this.panel1.Controls.Add(this.lbLop);
            this.panel1.Controls.Add(this.lbDangXuat);
            this.panel1.Controls.Add(this.lbBaoCao);
            this.panel1.Controls.Add(this.lbThanhtoan);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1474, 49);
            this.panel1.TabIndex = 3;
            // 
            // lbThietbi
            // 
            this.lbThietbi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbThietbi.BackColor = System.Drawing.Color.Transparent;
            this.lbThietbi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThietbi.ForeColor = System.Drawing.Color.Yellow;
            this.lbThietbi.Location = new System.Drawing.Point(914, -1);
            this.lbThietbi.Name = "lbThietbi";
            this.lbThietbi.Size = new System.Drawing.Size(135, 49);
            this.lbThietbi.TabIndex = 2;
            this.lbThietbi.Text = "Thiết bị";
            this.lbThietbi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbThietbi.Click += new System.EventHandler(this.lbThietbi_Click);
            // 
            // lbNhanvien
            // 
            this.lbNhanvien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNhanvien.BackColor = System.Drawing.Color.Transparent;
            this.lbNhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNhanvien.ForeColor = System.Drawing.Color.Yellow;
            this.lbNhanvien.Location = new System.Drawing.Point(771, -1);
            this.lbNhanvien.Name = "lbNhanvien";
            this.lbNhanvien.Size = new System.Drawing.Size(135, 49);
            this.lbNhanvien.TabIndex = 2;
            this.lbNhanvien.Text = "Nhân viên";
            this.lbNhanvien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbNhanvien.Click += new System.EventHandler(this.lbNhanvien_Click);
            // 
            // lbHocvien
            // 
            this.lbHocvien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbHocvien.BackColor = System.Drawing.Color.Transparent;
            this.lbHocvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHocvien.ForeColor = System.Drawing.Color.Yellow;
            this.lbHocvien.Location = new System.Drawing.Point(628, -1);
            this.lbHocvien.Name = "lbHocvien";
            this.lbHocvien.Size = new System.Drawing.Size(135, 49);
            this.lbHocvien.TabIndex = 2;
            this.lbHocvien.Text = "Học viên";
            this.lbHocvien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbHocvien.Click += new System.EventHandler(this.lbHocvien_Click);
            // 
            // lbTrangchu
            // 
            this.lbTrangchu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTrangchu.BackColor = System.Drawing.Color.Transparent;
            this.lbTrangchu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTrangchu.ForeColor = System.Drawing.Color.Yellow;
            this.lbTrangchu.Location = new System.Drawing.Point(342, 0);
            this.lbTrangchu.Name = "lbTrangchu";
            this.lbTrangchu.Size = new System.Drawing.Size(135, 49);
            this.lbTrangchu.TabIndex = 2;
            this.lbTrangchu.Text = "Trang chủ";
            this.lbTrangchu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTrangchu.Click += new System.EventHandler(this.lbTrangchu_Click);
            // 
            // lbLop
            // 
            this.lbLop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLop.BackColor = System.Drawing.Color.Transparent;
            this.lbLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLop.ForeColor = System.Drawing.Color.Yellow;
            this.lbLop.Location = new System.Drawing.Point(485, -1);
            this.lbLop.Name = "lbLop";
            this.lbLop.Size = new System.Drawing.Size(135, 49);
            this.lbLop.TabIndex = 2;
            this.lbLop.Text = "Lớp học";
            this.lbLop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLop.Click += new System.EventHandler(this.lbLop_Click);
            // 
            // lbDangXuat
            // 
            this.lbDangXuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDangXuat.BackColor = System.Drawing.Color.Transparent;
            this.lbDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDangXuat.ForeColor = System.Drawing.Color.Red;
            this.lbDangXuat.Location = new System.Drawing.Point(1343, 0);
            this.lbDangXuat.Name = "lbDangXuat";
            this.lbDangXuat.Size = new System.Drawing.Size(135, 49);
            this.lbDangXuat.TabIndex = 2;
            this.lbDangXuat.Text = "Đăng xuất";
            this.lbDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbDangXuat.Click += new System.EventHandler(this.lbDangXuat_Click);
            // 
            // lbBaoCao
            // 
            this.lbBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBaoCao.BackColor = System.Drawing.Color.Transparent;
            this.lbBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBaoCao.ForeColor = System.Drawing.Color.Yellow;
            this.lbBaoCao.Location = new System.Drawing.Point(1200, 0);
            this.lbBaoCao.Name = "lbBaoCao";
            this.lbBaoCao.Size = new System.Drawing.Size(135, 49);
            this.lbBaoCao.TabIndex = 2;
            this.lbBaoCao.Text = "Báo cáo";
            this.lbBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbBaoCao.Click += new System.EventHandler(this.lbBaoCao_Click);
            // 
            // lbThanhtoan
            // 
            this.lbThanhtoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbThanhtoan.BackColor = System.Drawing.Color.Transparent;
            this.lbThanhtoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThanhtoan.ForeColor = System.Drawing.Color.Yellow;
            this.lbThanhtoan.Location = new System.Drawing.Point(1057, 0);
            this.lbThanhtoan.Name = "lbThanhtoan";
            this.lbThanhtoan.Size = new System.Drawing.Size(135, 49);
            this.lbThanhtoan.TabIndex = 2;
            this.lbThanhtoan.Text = "Thanh toán";
            this.lbThanhtoan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbThanhtoan.Click += new System.EventHandler(this.lbThanhtoan_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "EVOGYM";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1474, 614);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // GymManagemet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1474, 614);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "GymManagemet";
            this.Text = "EVOGYM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GymManagemet_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lbThanhtoan;
        private System.Windows.Forms.Label lbThietbi;
        private System.Windows.Forms.Label lbNhanvien;
        private System.Windows.Forms.Label lbHocvien;
        private System.Windows.Forms.Label lbLop;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Label lbTrangchu;
        private System.Windows.Forms.Label lbDangXuat;
        private System.Windows.Forms.Label lbBaoCao;
    }
}

