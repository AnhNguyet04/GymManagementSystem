namespace PresentationLayer
{
    partial class Thanhtoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Thanhtoan));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnQuayve = new System.Windows.Forms.Button();
            this.btnNhacNho = new System.Windows.Forms.Button();
            this.btnLichSu = new System.Windows.Forms.Button();
            this.btnThanhtoan = new System.Windows.Forms.Button();
            this.dgvThanhtoan = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThanhtoan)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dgvThanhtoan);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 79);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1260, 616);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.btnQuayve);
            this.panel3.Controls.Add(this.btnNhacNho);
            this.panel3.Controls.Add(this.btnLichSu);
            this.panel3.Controls.Add(this.btnThanhtoan);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(239, 616);
            this.panel3.TabIndex = 1;
            // 
            // btnQuayve
            // 
            this.btnQuayve.BackColor = System.Drawing.Color.Transparent;
            this.btnQuayve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuayve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuayve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuayve.ForeColor = System.Drawing.Color.Cyan;
            this.btnQuayve.Location = new System.Drawing.Point(11, 18);
            this.btnQuayve.Name = "btnQuayve";
            this.btnQuayve.Size = new System.Drawing.Size(218, 45);
            this.btnQuayve.TabIndex = 1;
            this.btnQuayve.Text = "Danh sách học viên";
            this.btnQuayve.UseVisualStyleBackColor = false;
            this.btnQuayve.Click += new System.EventHandler(this.btnQuayve_Click);
            // 
            // btnNhacNho
            // 
            this.btnNhacNho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNhacNho.BackColor = System.Drawing.Color.Transparent;
            this.btnNhacNho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhacNho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhacNho.ForeColor = System.Drawing.Color.Cyan;
            this.btnNhacNho.Location = new System.Drawing.Point(11, 225);
            this.btnNhacNho.Name = "btnNhacNho";
            this.btnNhacNho.Size = new System.Drawing.Size(221, 45);
            this.btnNhacNho.TabIndex = 0;
            this.btnNhacNho.Text = "Gửi nhắc nhở";
            this.btnNhacNho.UseVisualStyleBackColor = false;
            this.btnNhacNho.Click += new System.EventHandler(this.btnNhacNho_Click_1);
            // 
            // btnLichSu
            // 
            this.btnLichSu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLichSu.BackColor = System.Drawing.Color.Transparent;
            this.btnLichSu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLichSu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLichSu.ForeColor = System.Drawing.Color.Cyan;
            this.btnLichSu.Location = new System.Drawing.Point(11, 156);
            this.btnLichSu.Name = "btnLichSu";
            this.btnLichSu.Size = new System.Drawing.Size(221, 45);
            this.btnLichSu.TabIndex = 0;
            this.btnLichSu.Text = "Lịch sử thanh toán";
            this.btnLichSu.UseVisualStyleBackColor = false;
            this.btnLichSu.Click += new System.EventHandler(this.btnLichSu_Click);
            // 
            // btnThanhtoan
            // 
            this.btnThanhtoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThanhtoan.BackColor = System.Drawing.Color.Transparent;
            this.btnThanhtoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhtoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhtoan.ForeColor = System.Drawing.Color.Cyan;
            this.btnThanhtoan.Location = new System.Drawing.Point(11, 87);
            this.btnThanhtoan.Name = "btnThanhtoan";
            this.btnThanhtoan.Size = new System.Drawing.Size(218, 45);
            this.btnThanhtoan.TabIndex = 0;
            this.btnThanhtoan.Text = "Thanh Toán";
            this.btnThanhtoan.UseVisualStyleBackColor = false;
            this.btnThanhtoan.Click += new System.EventHandler(this.btnThanhtoan_Click);
            // 
            // dgvThanhtoan
            // 
            this.dgvThanhtoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThanhtoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThanhtoan.Location = new System.Drawing.Point(0, 0);
            this.dgvThanhtoan.Name = "dgvThanhtoan";
            this.dgvThanhtoan.RowHeadersWidth = 51;
            this.dgvThanhtoan.RowTemplate.Height = 24;
            this.dgvThanhtoan.Size = new System.Drawing.Size(1260, 616);
            this.dgvThanhtoan.TabIndex = 0;
            this.dgvThanhtoan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThanhtoan_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.btTimKiem);
            this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1260, 79);
            this.panel1.TabIndex = 0;
            // 
            // btTimKiem
            // 
            this.btTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btTimKiem.BackColor = System.Drawing.SystemColors.Control;
            this.btTimKiem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btTimKiem.BackgroundImage")));
            this.btTimKiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btTimKiem.Location = new System.Drawing.Point(1209, 16);
            this.btTimKiem.Name = "btTimKiem";
            this.btTimKiem.Size = new System.Drawing.Size(48, 44);
            this.btTimKiem.TabIndex = 3;
            this.btTimKiem.UseVisualStyleBackColor = false;
            this.btTimKiem.Click += new System.EventHandler(this.btTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(829, 24);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(380, 30);
            this.txtTimKiem.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(37, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thanh toán";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Thanhtoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 695);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Thanhtoan";
            this.Text = "Thanhtoan";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThanhtoan)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvThanhtoan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThanhtoan;
        private System.Windows.Forms.Button btnQuayve;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btTimKiem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnLichSu;
        private System.Windows.Forms.Button btnNhacNho;
    }
}