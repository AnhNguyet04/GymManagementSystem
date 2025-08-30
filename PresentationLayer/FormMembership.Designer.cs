namespace PresentationLayer
{
    partial class FormMembership
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMembership));
            this.txtGia = new System.Windows.Forms.TextBox();
            this.btLuuGoiTap = new System.Windows.Forms.Button();
            this.cbGoiTap = new System.Windows.Forms.ComboBox();
            this.dpKetThucGoiTap = new System.Windows.Forms.DateTimePicker();
            this.dpBatDauGoiTap = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuaylai = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtGia
            // 
            this.txtGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGia.Location = new System.Drawing.Point(99, 70);
            this.txtGia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(184, 30);
            this.txtGia.TabIndex = 13;
            // 
            // btLuuGoiTap
            // 
            this.btLuuGoiTap.BackColor = System.Drawing.Color.Transparent;
            this.btLuuGoiTap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLuuGoiTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLuuGoiTap.ForeColor = System.Drawing.Color.Cyan;
            this.btLuuGoiTap.Location = new System.Drawing.Point(163, 117);
            this.btLuuGoiTap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btLuuGoiTap.Name = "btLuuGoiTap";
            this.btLuuGoiTap.Size = new System.Drawing.Size(120, 36);
            this.btLuuGoiTap.TabIndex = 12;
            this.btLuuGoiTap.Text = "Lưu";
            this.btLuuGoiTap.UseVisualStyleBackColor = false;
            this.btLuuGoiTap.Click += new System.EventHandler(this.btLuuGoiTap_Click);
            // 
            // cbGoiTap
            // 
            this.cbGoiTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGoiTap.FormattingEnabled = true;
            this.cbGoiTap.Items.AddRange(new object[] {
            "Tháng",
            "Quý",
            "Năm"});
            this.cbGoiTap.Location = new System.Drawing.Point(99, 20);
            this.cbGoiTap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbGoiTap.Name = "cbGoiTap";
            this.cbGoiTap.Size = new System.Drawing.Size(184, 33);
            this.cbGoiTap.TabIndex = 11;
            this.cbGoiTap.SelectedIndexChanged += new System.EventHandler(this.cbGoiTap_SelectedIndexChanged);
            // 
            // dpKetThucGoiTap
            // 
            this.dpKetThucGoiTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpKetThucGoiTap.Location = new System.Drawing.Point(434, 71);
            this.dpKetThucGoiTap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dpKetThucGoiTap.Name = "dpKetThucGoiTap";
            this.dpKetThucGoiTap.Size = new System.Drawing.Size(252, 30);
            this.dpKetThucGoiTap.TabIndex = 9;
            // 
            // dpBatDauGoiTap
            // 
            this.dpBatDauGoiTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpBatDauGoiTap.Location = new System.Drawing.Point(434, 20);
            this.dpBatDauGoiTap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dpBatDauGoiTap.Name = "dpBatDauGoiTap";
            this.dpBatDauGoiTap.Size = new System.Drawing.Size(252, 30);
            this.dpBatDauGoiTap.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(302, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Ngày kết thúc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(302, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ngày bắt đầu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Giá";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Gói tập";
            // 
            // btnQuaylai
            // 
            this.btnQuaylai.BackColor = System.Drawing.Color.Transparent;
            this.btnQuaylai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuaylai.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuaylai.ForeColor = System.Drawing.Color.Red;
            this.btnQuaylai.Location = new System.Drawing.Point(434, 117);
            this.btnQuaylai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuaylai.Name = "btnQuaylai";
            this.btnQuaylai.Size = new System.Drawing.Size(120, 36);
            this.btnQuaylai.TabIndex = 12;
            this.btnQuaylai.Text = "Hủy";
            this.btnQuaylai.UseVisualStyleBackColor = false;
            this.btnQuaylai.Click += new System.EventHandler(this.btnQuaylai_Click);
            // 
            // FormMembership
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(698, 164);
            this.Controls.Add(this.txtGia);
            this.Controls.Add(this.btnQuaylai);
            this.Controls.Add(this.btLuuGoiTap);
            this.Controls.Add(this.cbGoiTap);
            this.Controls.Add(this.dpKetThucGoiTap);
            this.Controls.Add(this.dpBatDauGoiTap);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMembership";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMembership";
            this.Load += new System.EventHandler(this.FormMembership_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.Button btLuuGoiTap;
        private System.Windows.Forms.ComboBox cbGoiTap;
        private System.Windows.Forms.DateTimePicker dpKetThucGoiTap;
        private System.Windows.Forms.DateTimePicker dpBatDauGoiTap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuaylai;
    }
}