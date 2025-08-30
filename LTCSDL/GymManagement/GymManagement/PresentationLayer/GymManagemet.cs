using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class GymManagemet: Form
    {
        public bool isDangXuat = false;
        public GymManagemet()
        {
            InitializeComponent();
        }
        private void GymManagemet_Load(object sender, EventArgs e)
        {
           /*this.Hide();

            Login login = new Login();
            DialogResult result = login.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.Show();
            }
            else
                Application.Exit();*/
            string role = UserSession.Role;
            if (role == "Lễ tân")
            {
                lbNhanvien.Enabled = false;
            }    
            else if (role == "Huấn luyện viên")
            {
                lbHocvien.Enabled = false;
                lbNhanvien.Enabled = false;
                lbThanhtoan.Enabled = false;
                lbThietbi.Enabled = false;
                lbBaoCao.Enabled = false;
            }    
        }

        private void OpenForm(Form form)
        {
            pnMain.Controls.Clear();        //xóa form con cũ nếu có
            //cấu hình form con
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            //thêm vào panel
            pnMain.Controls.Add(form);
            pnMain.Tag = form;
            form.BringToFront();
            form.Show();
        }
        private void lbLop_Click(object sender, EventArgs e)
        {
            Form lophoc = new Lophoc();
            OpenForm(lophoc);
        }

        private void lbHocvien_Click(object sender, EventArgs e)
        {
            Form hocvien = new Hocvien();
            OpenForm(hocvien);
        }

        private void lbNhanvien_Click(object sender, EventArgs e)
        {
            Form nhanvien = new Nhanvien();
            OpenForm(nhanvien);
        }

        private void lbThietbi_Click(object sender, EventArgs e)
        {
            Form thietbi = new Thietbi();
            OpenForm(thietbi);
        }

        private void lbTrangchu_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
        }

        private void lbThanhtoan_Click(object sender, EventArgs e)
        {
            Form thanhtoan = new Thanhtoan();
            OpenForm(thanhtoan);
        }

        private void lbDangXuat_Click(object sender, EventArgs e)
        {
            isDangXuat = true;
            this.Close();
        }
        

        private void lbBaoCao_Click(object sender, EventArgs e)
        {
            Form baocao = new BaoCaoThongKe();
            OpenForm(baocao);
        }
    }
}
