namespace PresentationLayer
{
    partial class ChonHocVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChonHocVien));
            this.dgvHocVien = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btTimKiemHVTrongLop = new System.Windows.Forms.Button();
            this.btQuaylai = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocVien)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHocVien
            // 
            this.dgvHocVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHocVien.Location = new System.Drawing.Point(-3, 62);
            this.dgvHocVien.Name = "dgvHocVien";
            this.dgvHocVien.RowHeadersWidth = 51;
            this.dgvHocVien.RowTemplate.Height = 24;
            this.dgvHocVien.Size = new System.Drawing.Size(1164, 488);
            this.dgvHocVien.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Controls.Add(this.btQuaylai);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 550);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1164, 51);
            this.panel2.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.Cyan;
            this.btnOK.Location = new System.Drawing.Point(393, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(120, 43);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "Thêm";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.Controls.Add(this.btTimKiemHVTrongLop);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtTimKiem);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1164, 63);
            this.panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 63);
            this.label1.TabIndex = 1;
            this.label1.Text = "DANH SÁCH HỌC VIÊN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(626, 19);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(483, 30);
            this.txtTimKiem.TabIndex = 0;
            // 
            // btTimKiemHVTrongLop
            // 
            this.btTimKiemHVTrongLop.BackColor = System.Drawing.SystemColors.Control;
            this.btTimKiemHVTrongLop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btTimKiemHVTrongLop.BackgroundImage")));
            this.btTimKiemHVTrongLop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btTimKiemHVTrongLop.Location = new System.Drawing.Point(1109, 12);
            this.btTimKiemHVTrongLop.Name = "btTimKiemHVTrongLop";
            this.btTimKiemHVTrongLop.Size = new System.Drawing.Size(48, 44);
            this.btTimKiemHVTrongLop.TabIndex = 3;
            this.btTimKiemHVTrongLop.UseVisualStyleBackColor = false;
            this.btTimKiemHVTrongLop.Click += new System.EventHandler(this.btTimKiemHVTrongLop_Click);
            // 
            // btQuaylai
            // 
            this.btQuaylai.BackColor = System.Drawing.Color.Transparent;
            this.btQuaylai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btQuaylai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btQuaylai.ForeColor = System.Drawing.Color.Red;
            this.btQuaylai.Location = new System.Drawing.Point(603, 5);
            this.btQuaylai.Name = "btQuaylai";
            this.btQuaylai.Size = new System.Drawing.Size(120, 43);
            this.btQuaylai.TabIndex = 0;
            this.btQuaylai.Text = "Quay lại";
            this.btQuaylai.UseVisualStyleBackColor = false;
            this.btQuaylai.Click += new System.EventHandler(this.btQuaylai_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvHocVien);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1164, 601);
            this.panel1.TabIndex = 2;
            // 
            // ChonHocVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 601);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChonHocVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm học viên";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocVien)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvHocVien;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btTimKiemHVTrongLop;
        private System.Windows.Forms.Button btQuaylai;
        private System.Windows.Forms.Panel panel1;
    }
}