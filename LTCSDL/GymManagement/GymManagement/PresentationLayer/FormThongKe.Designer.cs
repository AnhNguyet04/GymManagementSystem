namespace PresentationLayer
{
    partial class FormThongKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThongKe));
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.SelectColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btTimKiem = new System.Windows.Forms.Button();
            this.grbDSNV = new System.Windows.Forms.GroupBox();
            this.rdHLV = new System.Windows.Forms.RadioButton();
            this.rdAdmin = new System.Windows.Forms.RadioButton();
            this.rdLeTan = new System.Windows.Forms.RadioButton();
            this.rdTatCaNhanVien = new System.Windows.Forms.RadioButton();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.grbDSTB = new System.Windows.Forms.GroupBox();
            this.rdHuHong = new System.Windows.Forms.RadioButton();
            this.rdCanBT = new System.Windows.Forms.RadioButton();
            this.rdTot = new System.Windows.Forms.RadioButton();
            this.rdTatCaTB = new System.Windows.Forms.RadioButton();
            this.grbLSTT = new System.Windows.Forms.GroupBox();
            this.rdDaTT = new System.Windows.Forms.RadioButton();
            this.rdChuaTT = new System.Windows.Forms.RadioButton();
            this.rdTatCaTT = new System.Windows.Forms.RadioButton();
            this.grbDSHV = new System.Windows.Forms.GroupBox();
            this.rdMembership = new System.Windows.Forms.RadioButton();
            this.rdTheoLop = new System.Windows.Forms.RadioButton();
            this.rdTatCaHV = new System.Windows.Forms.RadioButton();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.panel1.SuspendLayout();
            this.grbDSNV.SuspendLayout();
            this.grbDSTB.SuspendLayout();
            this.grbLSTT.SuspendLayout();
            this.grbDSHV.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvThongKe);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 216);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1489, 498);
            this.panel2.TabIndex = 1;
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectColumn});
            this.dgvThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThongKe.Location = new System.Drawing.Point(0, 0);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.RowHeadersWidth = 51;
            this.dgvThongKe.RowTemplate.Height = 24;
            this.dgvThongKe.Size = new System.Drawing.Size(1489, 498);
            this.dgvThongKe.TabIndex = 0;
            this.dgvThongKe.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThongKe_CellClick);
            // 
            // SelectColumn
            // 
            this.SelectColumn.HeaderText = "Chọn";
            this.SelectColumn.MinimumWidth = 6;
            this.SelectColumn.Name = "SelectColumn";
            this.SelectColumn.Width = 125;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnThongKe);
            this.panel1.Controls.Add(this.btnXuatExcel);
            this.panel1.Controls.Add(this.btTimKiem);
            this.panel1.Controls.Add(this.grbDSNV);
            this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Controls.Add(this.grbDSTB);
            this.panel1.Controls.Add(this.grbLSTT);
            this.panel1.Controls.Add(this.grbDSHV);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1489, 216);
            this.panel1.TabIndex = 0;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThongKe.BackColor = System.Drawing.Color.Transparent;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.ForeColor = System.Drawing.Color.Cyan;
            this.btnThongKe.Location = new System.Drawing.Point(1060, 151);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(181, 44);
            this.btnThongKe.TabIndex = 4;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXuatExcel.BackColor = System.Drawing.Color.Transparent;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.ForeColor = System.Drawing.Color.Cyan;
            this.btnXuatExcel.Location = new System.Drawing.Point(1296, 151);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(181, 44);
            this.btnXuatExcel.TabIndex = 4;
            this.btnXuatExcel.Text = "Xuất file Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btTimKiem
            // 
            this.btTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btTimKiem.BackColor = System.Drawing.SystemColors.Control;
            this.btTimKiem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btTimKiem.BackgroundImage")));
            this.btTimKiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btTimKiem.Location = new System.Drawing.Point(990, 151);
            this.btTimKiem.Name = "btTimKiem";
            this.btTimKiem.Size = new System.Drawing.Size(45, 45);
            this.btTimKiem.TabIndex = 3;
            this.btTimKiem.UseVisualStyleBackColor = false;
            this.btTimKiem.Click += new System.EventHandler(this.btTimKiem_Click);
            // 
            // grbDSNV
            // 
            this.grbDSNV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grbDSNV.BackColor = System.Drawing.Color.Transparent;
            this.grbDSNV.Controls.Add(this.rdHLV);
            this.grbDSNV.Controls.Add(this.rdAdmin);
            this.grbDSNV.Controls.Add(this.rdLeTan);
            this.grbDSNV.Controls.Add(this.rdTatCaNhanVien);
            this.grbDSNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDSNV.ForeColor = System.Drawing.Color.Cyan;
            this.grbDSNV.Location = new System.Drawing.Point(307, 3);
            this.grbDSNV.Name = "grbDSNV";
            this.grbDSNV.Size = new System.Drawing.Size(323, 136);
            this.grbDSNV.TabIndex = 0;
            this.grbDSNV.TabStop = false;
            this.grbDSNV.Text = "Danh sách nhân viên";
            // 
            // rdHLV
            // 
            this.rdHLV.AutoSize = true;
            this.rdHLV.ForeColor = System.Drawing.Color.Yellow;
            this.rdHLV.Location = new System.Drawing.Point(141, 39);
            this.rdHLV.Name = "rdHLV";
            this.rdHLV.Size = new System.Drawing.Size(173, 29);
            this.rdHLV.TabIndex = 0;
            this.rdHLV.TabStop = true;
            this.rdHLV.Text = "Huấn luyện viên";
            this.rdHLV.UseVisualStyleBackColor = true;
            // 
            // rdAdmin
            // 
            this.rdAdmin.AutoSize = true;
            this.rdAdmin.ForeColor = System.Drawing.Color.Yellow;
            this.rdAdmin.Location = new System.Drawing.Point(141, 89);
            this.rdAdmin.Name = "rdAdmin";
            this.rdAdmin.Size = new System.Drawing.Size(89, 29);
            this.rdAdmin.TabIndex = 0;
            this.rdAdmin.TabStop = true;
            this.rdAdmin.Text = "Admin";
            this.rdAdmin.UseVisualStyleBackColor = true;
            // 
            // rdLeTan
            // 
            this.rdLeTan.AutoSize = true;
            this.rdLeTan.ForeColor = System.Drawing.Color.Yellow;
            this.rdLeTan.Location = new System.Drawing.Point(22, 89);
            this.rdLeTan.Name = "rdLeTan";
            this.rdLeTan.Size = new System.Drawing.Size(87, 29);
            this.rdLeTan.TabIndex = 0;
            this.rdLeTan.TabStop = true;
            this.rdLeTan.Text = "Lễ tân";
            this.rdLeTan.UseVisualStyleBackColor = true;
            // 
            // rdTatCaNhanVien
            // 
            this.rdTatCaNhanVien.AutoSize = true;
            this.rdTatCaNhanVien.ForeColor = System.Drawing.Color.Yellow;
            this.rdTatCaNhanVien.Location = new System.Drawing.Point(22, 39);
            this.rdTatCaNhanVien.Name = "rdTatCaNhanVien";
            this.rdTatCaNhanVien.Size = new System.Drawing.Size(88, 29);
            this.rdTatCaNhanVien.TabIndex = 0;
            this.rdTatCaNhanVien.TabStop = true;
            this.rdTatCaNhanVien.Text = "Tất cả";
            this.rdTatCaNhanVien.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(570, 158);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(420, 30);
            this.txtTimKiem.TabIndex = 1;
            // 
            // grbDSTB
            // 
            this.grbDSTB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grbDSTB.BackColor = System.Drawing.Color.Transparent;
            this.grbDSTB.Controls.Add(this.rdHuHong);
            this.grbDSTB.Controls.Add(this.rdCanBT);
            this.grbDSTB.Controls.Add(this.rdTot);
            this.grbDSTB.Controls.Add(this.rdTatCaTB);
            this.grbDSTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDSTB.ForeColor = System.Drawing.Color.Cyan;
            this.grbDSTB.Location = new System.Drawing.Point(843, 3);
            this.grbDSTB.Name = "grbDSTB";
            this.grbDSTB.Size = new System.Drawing.Size(314, 136);
            this.grbDSTB.TabIndex = 0;
            this.grbDSTB.TabStop = false;
            this.grbDSTB.Text = "Danh sách thiết bị";
            // 
            // rdHuHong
            // 
            this.rdHuHong.AutoSize = true;
            this.rdHuHong.ForeColor = System.Drawing.Color.Yellow;
            this.rdHuHong.Location = new System.Drawing.Point(163, 89);
            this.rdHuHong.Name = "rdHuHong";
            this.rdHuHong.Size = new System.Drawing.Size(107, 29);
            this.rdHuHong.TabIndex = 0;
            this.rdHuHong.TabStop = true;
            this.rdHuHong.Text = "Hư hỏng";
            this.rdHuHong.UseVisualStyleBackColor = true;
            // 
            // rdCanBT
            // 
            this.rdCanBT.AutoSize = true;
            this.rdCanBT.ForeColor = System.Drawing.Color.Yellow;
            this.rdCanBT.Location = new System.Drawing.Point(163, 39);
            this.rdCanBT.Name = "rdCanBT";
            this.rdCanBT.Size = new System.Drawing.Size(128, 29);
            this.rdCanBT.TabIndex = 0;
            this.rdCanBT.TabStop = true;
            this.rdCanBT.Text = "Cần bảo trì";
            this.rdCanBT.UseVisualStyleBackColor = true;
            // 
            // rdTot
            // 
            this.rdTot.AutoSize = true;
            this.rdTot.ForeColor = System.Drawing.Color.Yellow;
            this.rdTot.Location = new System.Drawing.Point(19, 89);
            this.rdTot.Name = "rdTot";
            this.rdTot.Size = new System.Drawing.Size(62, 29);
            this.rdTot.TabIndex = 0;
            this.rdTot.TabStop = true;
            this.rdTot.Text = "Tốt";
            this.rdTot.UseVisualStyleBackColor = true;
            // 
            // rdTatCaTB
            // 
            this.rdTatCaTB.AutoSize = true;
            this.rdTatCaTB.ForeColor = System.Drawing.Color.Yellow;
            this.rdTatCaTB.Location = new System.Drawing.Point(19, 39);
            this.rdTatCaTB.Name = "rdTatCaTB";
            this.rdTatCaTB.Size = new System.Drawing.Size(88, 29);
            this.rdTatCaTB.TabIndex = 0;
            this.rdTatCaTB.TabStop = true;
            this.rdTatCaTB.Text = "Tất cả";
            this.rdTatCaTB.UseVisualStyleBackColor = true;
            // 
            // grbLSTT
            // 
            this.grbLSTT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grbLSTT.BackColor = System.Drawing.Color.Transparent;
            this.grbLSTT.Controls.Add(this.rdDaTT);
            this.grbLSTT.Controls.Add(this.rdChuaTT);
            this.grbLSTT.Controls.Add(this.rdTatCaTT);
            this.grbLSTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbLSTT.ForeColor = System.Drawing.Color.Cyan;
            this.grbLSTT.Location = new System.Drawing.Point(1153, 3);
            this.grbLSTT.Name = "grbLSTT";
            this.grbLSTT.Size = new System.Drawing.Size(324, 136);
            this.grbLSTT.TabIndex = 0;
            this.grbLSTT.TabStop = false;
            this.grbLSTT.Text = "Hóa đơn học viên";
            // 
            // rdDaTT
            // 
            this.rdDaTT.AutoSize = true;
            this.rdDaTT.ForeColor = System.Drawing.Color.Yellow;
            this.rdDaTT.Location = new System.Drawing.Point(26, 89);
            this.rdDaTT.Name = "rdDaTT";
            this.rdDaTT.Size = new System.Drawing.Size(155, 29);
            this.rdDaTT.TabIndex = 0;
            this.rdDaTT.TabStop = true;
            this.rdDaTT.Text = "Đã thanh toán";
            this.rdDaTT.UseVisualStyleBackColor = true;
            // 
            // rdChuaTT
            // 
            this.rdChuaTT.AutoSize = true;
            this.rdChuaTT.ForeColor = System.Drawing.Color.Yellow;
            this.rdChuaTT.Location = new System.Drawing.Point(26, 39);
            this.rdChuaTT.Name = "rdChuaTT";
            this.rdChuaTT.Size = new System.Drawing.Size(178, 29);
            this.rdChuaTT.TabIndex = 0;
            this.rdChuaTT.TabStop = true;
            this.rdChuaTT.Text = "Chưa thanh toán";
            this.rdChuaTT.UseVisualStyleBackColor = true;
            // 
            // rdTatCaTT
            // 
            this.rdTatCaTT.AutoSize = true;
            this.rdTatCaTT.ForeColor = System.Drawing.Color.Yellow;
            this.rdTatCaTT.Location = new System.Drawing.Point(219, 39);
            this.rdTatCaTT.Name = "rdTatCaTT";
            this.rdTatCaTT.Size = new System.Drawing.Size(88, 29);
            this.rdTatCaTT.TabIndex = 0;
            this.rdTatCaTT.TabStop = true;
            this.rdTatCaTT.Text = "Tất cả";
            this.rdTatCaTT.UseVisualStyleBackColor = true;
            // 
            // grbDSHV
            // 
            this.grbDSHV.BackColor = System.Drawing.Color.Transparent;
            this.grbDSHV.Controls.Add(this.rdMembership);
            this.grbDSHV.Controls.Add(this.rdTheoLop);
            this.grbDSHV.Controls.Add(this.rdTatCaHV);
            this.grbDSHV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDSHV.ForeColor = System.Drawing.Color.Cyan;
            this.grbDSHV.Location = new System.Drawing.Point(3, 3);
            this.grbDSHV.Name = "grbDSHV";
            this.grbDSHV.Size = new System.Drawing.Size(314, 136);
            this.grbDSHV.TabIndex = 0;
            this.grbDSHV.TabStop = false;
            this.grbDSHV.Text = "Danh sách học viên";
            // 
            // rdMembership
            // 
            this.rdMembership.AutoSize = true;
            this.rdMembership.ForeColor = System.Drawing.Color.Yellow;
            this.rdMembership.Location = new System.Drawing.Point(157, 39);
            this.rdMembership.Name = "rdMembership";
            this.rdMembership.Size = new System.Drawing.Size(141, 29);
            this.rdMembership.TabIndex = 0;
            this.rdMembership.TabStop = true;
            this.rdMembership.Text = "Membership";
            this.rdMembership.UseVisualStyleBackColor = true;
            // 
            // rdTheoLop
            // 
            this.rdTheoLop.AutoSize = true;
            this.rdTheoLop.ForeColor = System.Drawing.Color.Yellow;
            this.rdTheoLop.Location = new System.Drawing.Point(19, 89);
            this.rdTheoLop.Name = "rdTheoLop";
            this.rdTheoLop.Size = new System.Drawing.Size(110, 29);
            this.rdTheoLop.TabIndex = 0;
            this.rdTheoLop.TabStop = true;
            this.rdTheoLop.Text = "Theo lớp";
            this.rdTheoLop.UseVisualStyleBackColor = true;
            // 
            // rdTatCaHV
            // 
            this.rdTatCaHV.AutoSize = true;
            this.rdTatCaHV.ForeColor = System.Drawing.Color.Yellow;
            this.rdTatCaHV.Location = new System.Drawing.Point(19, 39);
            this.rdTatCaHV.Name = "rdTatCaHV";
            this.rdTatCaHV.Size = new System.Drawing.Size(88, 29);
            this.rdTatCaHV.TabIndex = 0;
            this.rdTatCaHV.TabStop = true;
            this.rdTatCaHV.Text = "Tất cả";
            this.rdTatCaHV.UseVisualStyleBackColor = true;
            // 
            // FormThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1489, 714);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormThongKe";
            this.Text = "FormThongKe";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbDSNV.ResumeLayout(false);
            this.grbDSNV.PerformLayout();
            this.grbDSTB.ResumeLayout(false);
            this.grbDSTB.PerformLayout();
            this.grbLSTT.ResumeLayout(false);
            this.grbLSTT.PerformLayout();
            this.grbDSHV.ResumeLayout(false);
            this.grbDSHV.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.GroupBox grbDSTB;
        private System.Windows.Forms.GroupBox grbLSTT;
        private System.Windows.Forms.GroupBox grbDSNV;
        private System.Windows.Forms.GroupBox grbDSHV;
        private System.Windows.Forms.RadioButton rdHuHong;
        private System.Windows.Forms.RadioButton rdCanBT;
        private System.Windows.Forms.RadioButton rdTot;
        private System.Windows.Forms.RadioButton rdTatCaTB;
        private System.Windows.Forms.RadioButton rdDaTT;
        private System.Windows.Forms.RadioButton rdChuaTT;
        private System.Windows.Forms.RadioButton rdTatCaTT;
        private System.Windows.Forms.RadioButton rdHLV;
        private System.Windows.Forms.RadioButton rdLeTan;
        private System.Windows.Forms.RadioButton rdTatCaNhanVien;
        private System.Windows.Forms.RadioButton rdMembership;
        private System.Windows.Forms.RadioButton rdTheoLop;
        private System.Windows.Forms.RadioButton rdTatCaHV;
        private System.Windows.Forms.RadioButton rdAdmin;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btTimKiem;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectColumn;
    }
}