namespace PresentationLayer
{
    partial class FormThemBaoTri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThemBaoTri));
            this.btHuyBaoTri = new System.Windows.Forms.Button();
            this.btLuuBaoTri = new System.Windows.Forms.Button();
            this.dpBaoTriTiepTheo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.cbChonTB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btHuyBaoTri
            // 
            this.btHuyBaoTri.BackColor = System.Drawing.Color.Transparent;
            this.btHuyBaoTri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btHuyBaoTri.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHuyBaoTri.ForeColor = System.Drawing.Color.Red;
            this.btHuyBaoTri.Location = new System.Drawing.Point(338, 326);
            this.btHuyBaoTri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btHuyBaoTri.Name = "btHuyBaoTri";
            this.btHuyBaoTri.Size = new System.Drawing.Size(111, 34);
            this.btHuyBaoTri.TabIndex = 17;
            this.btHuyBaoTri.Text = "Hủy";
            this.btHuyBaoTri.UseVisualStyleBackColor = false;
            this.btHuyBaoTri.Click += new System.EventHandler(this.btHuyBaoTri_Click);
            // 
            // btLuuBaoTri
            // 
            this.btLuuBaoTri.BackColor = System.Drawing.Color.Transparent;
            this.btLuuBaoTri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLuuBaoTri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLuuBaoTri.ForeColor = System.Drawing.Color.Cyan;
            this.btLuuBaoTri.Location = new System.Drawing.Point(69, 325);
            this.btLuuBaoTri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btLuuBaoTri.Name = "btLuuBaoTri";
            this.btLuuBaoTri.Size = new System.Drawing.Size(111, 34);
            this.btLuuBaoTri.TabIndex = 16;
            this.btLuuBaoTri.Text = "Lưu";
            this.btLuuBaoTri.UseVisualStyleBackColor = false;
            this.btLuuBaoTri.Click += new System.EventHandler(this.btLuuBaoTri_Click);
            // 
            // dpBaoTriTiepTheo
            // 
            this.dpBaoTriTiepTheo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpBaoTriTiepTheo.Location = new System.Drawing.Point(221, 251);
            this.dpBaoTriTiepTheo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dpBaoTriTiepTheo.Name = "dpBaoTriTiepTheo";
            this.dpBaoTriTiepTheo.Size = new System.Drawing.Size(237, 30);
            this.dpBaoTriTiepTheo.TabIndex = 15;
            this.dpBaoTriTiepTheo.ValueChanged += new System.EventHandler(this.dpBaoTriTiepTheo_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(38, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Đặt lịch bảo trì";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(38, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Chọn Trạng thái";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(38, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Chọn Thiết bị";
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTrangThai.FormattingEnabled = true;
            this.cbTrangThai.Location = new System.Drawing.Point(221, 176);
            this.cbTrangThai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(237, 33);
            this.cbTrangThai.TabIndex = 11;
            // 
            // cbChonTB
            // 
            this.cbChonTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChonTB.FormattingEnabled = true;
            this.cbChonTB.Location = new System.Drawing.Point(221, 95);
            this.cbChonTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbChonTB.Name = "cbChonTB";
            this.cbChonTB.Size = new System.Drawing.Size(237, 33);
            this.cbChonTB.TabIndex = 10;
            this.cbChonTB.SelectedIndexChanged += new System.EventHandler(this.cbChonTB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(53, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(396, 38);
            this.label1.TabIndex = 9;
            this.label1.Text = "ĐẶT LỊCH BẢO TRÌ MỚI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormThemBaoTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(508, 390);
            this.Controls.Add(this.btHuyBaoTri);
            this.Controls.Add(this.btLuuBaoTri);
            this.Controls.Add(this.dpBaoTriTiepTheo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbTrangThai);
            this.Controls.Add(this.cbChonTB);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormThemBaoTri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormThemBaoTri";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btHuyBaoTri;
        private System.Windows.Forms.Button btLuuBaoTri;
        private System.Windows.Forms.DateTimePicker dpBaoTriTiepTheo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTrangThai;
        private System.Windows.Forms.ComboBox cbChonTB;
        private System.Windows.Forms.Label label1;
    }
}