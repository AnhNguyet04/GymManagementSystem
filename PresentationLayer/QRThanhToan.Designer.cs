namespace PresentationLayer
{
    partial class QRThanhToan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QRThanhToan));
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateQR = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSTK = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTemplate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTenTaiKhoan = new System.Windows.Forms.TextBox();
            this.btnHoanTat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(237, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "THANH TOÁN";
            // 
            // btnCreateQR
            // 
            this.btnCreateQR.BackColor = System.Drawing.Color.Black;
            this.btnCreateQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateQR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateQR.ForeColor = System.Drawing.Color.Cyan;
            this.btnCreateQR.Location = new System.Drawing.Point(278, 332);
            this.btnCreateQR.Name = "btnCreateQR";
            this.btnCreateQR.Size = new System.Drawing.Size(160, 40);
            this.btnCreateQR.TabIndex = 1;
            this.btnCreateQR.Text = "Tạo mã QR";
            this.btnCreateQR.UseVisualStyleBackColor = false;
            this.btnCreateQR.Click += new System.EventHandler(this.btnCreateQR_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(2, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngân hàng:";
            // 
            // txtBank
            // 
            this.txtBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBank.Location = new System.Drawing.Point(7, 118);
            this.txtBank.Name = "txtBank";
            this.txtBank.ReadOnly = true;
            this.txtBank.Size = new System.Drawing.Size(431, 30);
            this.txtBank.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(2, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số tài khoản:";
            // 
            // txtSTK
            // 
            this.txtSTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTK.Location = new System.Drawing.Point(7, 203);
            this.txtSTK.Name = "txtSTK";
            this.txtSTK.Size = new System.Drawing.Size(431, 30);
            this.txtSTK.TabIndex = 3;
            this.txtSTK.Text = "1031699947";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(472, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Template:";
            // 
            // cbTemplate
            // 
            this.cbTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTemplate.FormattingEnabled = true;
            this.cbTemplate.Items.AddRange(new object[] {
            "compact",
            "compact2",
            "qr_only",
            "print"});
            this.cbTemplate.Location = new System.Drawing.Point(477, 118);
            this.cbTemplate.Name = "cbTemplate";
            this.cbTemplate.Size = new System.Drawing.Size(227, 30);
            this.cbTemplate.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(2, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "Số tiền";
            // 
            // txtSoTien
            // 
            this.txtSoTien.Enabled = false;
            this.txtSoTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoTien.Location = new System.Drawing.Point(7, 284);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.ReadOnly = true;
            this.txtSoTien.Size = new System.Drawing.Size(227, 30);
            this.txtSoTien.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(472, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "Tên tài khoản:";
            // 
            // txtTenTaiKhoan
            // 
            this.txtTenTaiKhoan.Enabled = false;
            this.txtTenTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenTaiKhoan.Location = new System.Drawing.Point(477, 203);
            this.txtTenTaiKhoan.Name = "txtTenTaiKhoan";
            this.txtTenTaiKhoan.ReadOnly = true;
            this.txtTenTaiKhoan.Size = new System.Drawing.Size(227, 30);
            this.txtTenTaiKhoan.TabIndex = 3;
            this.txtTenTaiKhoan.Text = "EVOGYM";
            // 
            // btnHoanTat
            // 
            this.btnHoanTat.BackColor = System.Drawing.Color.Black;
            this.btnHoanTat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoanTat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoanTat.ForeColor = System.Drawing.Color.Red;
            this.btnHoanTat.Location = new System.Drawing.Point(278, 388);
            this.btnHoanTat.Name = "btnHoanTat";
            this.btnHoanTat.Size = new System.Drawing.Size(160, 41);
            this.btnHoanTat.TabIndex = 1;
            this.btnHoanTat.Text = "Hoàn tất";
            this.btnHoanTat.UseVisualStyleBackColor = false;
            this.btnHoanTat.Click += new System.EventHandler(this.btnHoanTat_Click);
            // 
            // QRThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(731, 444);
            this.Controls.Add(this.cbTemplate);
            this.Controls.Add(this.txtSTK);
            this.Controls.Add(this.txtSoTien);
            this.Controls.Add(this.txtTenTaiKhoan);
            this.Controls.Add(this.txtBank);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnHoanTat);
            this.Controls.Add(this.btnCreateQR);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "QRThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateQR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBank;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSTK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTemplate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTenTaiKhoan;
        private System.Windows.Forms.Button btnHoanTat;
    }
}