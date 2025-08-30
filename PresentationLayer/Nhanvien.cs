using BusinessLayer;
using PresentationLayer.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace PresentationLayer
{
    public partial class Nhanvien : Form
    {
        private NhanVienBL nhanvienBL = new NhanVienBL();
        private BindingSource NhanVienBindingSource = new BindingSource();
        public Nhanvien()
        {
            InitializeComponent();
            DataGridViewStyleHelper.ApplyCustomStyle(dgvNhanVien);
            DataGridViewStyleHelper.ApplyCustomStyle(dgvChinhSuaNV);
            pnThemNV.Visible = false;
            this.Load += Nhanvien_Load;
        }

        private void Nhanvien_Load(object sender, EventArgs e)
        {
            LoadDanhSachNhanVien();
            cboRole.Items.Clear(); // Xóa dữ liệu cũ (nếu có)

            // Thêm vai trò vào ComboBox
            cboRole.Items.AddRange(new[] { "Admin", "Huấn luyện viên", "Lễ tân" });

            cboRole.SelectedIndex = 0;

            btThemNV.Visible = false;
            btCapNhatNV.Visible = false;
            btXoaNV.Visible = false;
            btClearNV.Visible = false;
        }

        private void DinhDangDanhSachNhanVien()
        {
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChinhSuaNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvNhanVien.Columns.Count > 0)
            {
                dgvNhanVien.Columns[nameof(User.UserId)].HeaderText = "Mã nhân viên";
                dgvNhanVien.Columns[nameof(User.Username)].HeaderText = "Tên đăng nhập";
                dgvNhanVien.Columns[nameof(User.FullName)].HeaderText = "Họ tên";
                dgvNhanVien.Columns[nameof(User.DOB)].HeaderText = "Ngày sinh";
                dgvNhanVien.Columns[nameof(User.Phone)].HeaderText = "Số điện thoại";
                dgvNhanVien.Columns[nameof(User.Email)].HeaderText = "Email";
                dgvNhanVien.Columns[nameof(User.Address)].HeaderText = "Địa chỉ";
                dgvNhanVien.Columns[nameof(User.Role)].HeaderText = "Vị trí";
            }
        }

        private void LoadDanhSachNhanVien()
        {
            List<User> data = nhanvienBL.XemTatCaNhanVien();
            NhanVienBindingSource.DataSource = data;

            dgvNhanVien.DataSource = NhanVienBindingSource;
            dgvChinhSuaNV.DataSource = NhanVienBindingSource;
            if (dgvNhanVien.Columns.Contains("Password"))
                dgvNhanVien.Columns["Password"].Visible = false;

            if (dgvChinhSuaNV.Columns.Contains("Password"))
                dgvChinhSuaNV.Columns["Password"].Visible = false;
            DinhDangDanhSachNhanVien();

        }

        private void btThemNV_Click(object sender, EventArgs e)
        {
            User newUser = new User
            {
                Username = txtTenNV.Text.Trim(),
                Password = txtMatKhauNV.Text.Trim(),
                FullName = txtHoVaTenNV.Text.Trim(),
                DOB = dpNgaySinhNV.Value,
                Phone = txtSDTNV.Text.Trim(),
                Email = txtEmailNV.Text.Trim(),
                Address = txtDiaChiNV.Text.Trim(),
                Role = cboRole.Text.Trim() // "Admin", "Lễ tân", "Huấn luyện viên"
            };

            bool success = nhanvienBL.ThemNhanVien(newUser, out string message);

            if (success)
            {
                MessageBox.Show(message, "Thành công");
                LoadDanhSachNhanVien();
            }
            else
            {
                MessageBox.Show(message, "Lỗi: " + message);
            }
        }

        private void btnDanhSachNV_Click(object sender, EventArgs e)
        {
            pnThemNV.Visible = false;
            LoadDanhSachNhanVien();
            btThemNV.Visible = false;
            btCapNhatNV.Visible = false;
            btXoaNV.Visible = false;
            btClearNV.Visible = false;
        }

        private void btnChinhSuaNV_Click(object sender, EventArgs e)
        {
            pnThemNV.Visible = true;
            LoadDanhSachNhanVien();
            btThemNV.Visible = true;
            btCapNhatNV.Visible = true;
            btXoaNV.Visible = true;
            btClearNV.Visible = true;
        }

        private void btCapNhatNV_Click(object sender, EventArgs e)
        {
            if (btCapNhatNV.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để cập nhật!", "Thông báo");
                return;
            }

            int userId = Convert.ToInt32(btCapNhatNV.Tag);

            User user = new User
            {
                UserId = userId,
                Username = txtTenNV.Text.Trim(),
                FullName = txtHoVaTenNV.Text,
                DOB = dpNgaySinhNV.Value,
                Phone = txtSDTNV.Text,
                Email = txtEmailNV.Text,
                Address = txtDiaChiNV.Text,
                Role = cboRole.Text.Trim()
            };

            int success = nhanvienBL.CapNhatNhanVien(user);

            if (success >0)
            {
                MessageBox.Show("Cập nhật nhân viên thành công.");
                LoadDanhSachNhanVien();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.");
            }
        }

        private void btXoaNV_Click(object sender, EventArgs e)
        {
            if (btXoaNV.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa!", "Thông báo");
                return;
            }

            if (UserSession.Role != "Admin")
            {
                MessageBox.Show("Chỉ Admin mới có quyền xóa nhân viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Convert.ToInt32(btXoaNV.Tag);
            string hoTen = txtHoVaTenNV.Text;

            DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa nhân viên \"{hoTen}\" không?", "Xác nhận", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int success = nhanvienBL.XoaNhanVien(userId);
                    if (success > 0)
                    {
                        MessageBox.Show("Xóa nhân viên thành công.");
                        LoadDanhSachNhanVien();
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhân viên thất bại.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btClearNV_Click(object sender, EventArgs e)
        {
            txtTenNV.Clear();
            txtMatKhauNV.Clear();
            txtHoVaTenNV.Clear();
            dpNgaySinhNV.Value = DateTime.Now;
            txtSDTNV.Clear();
            txtEmailNV.Clear();
            txtDiaChiNV.Clear();
        }

        private void dgvChinhSuaNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvChinhSuaNV.Rows[e.RowIndex].DataBoundItem is User selectedUser)
                {
                    txtTenNV.Text = selectedUser.Username;
                    txtMatKhauNV.Text = "";
                    txtHoVaTenNV.Text = selectedUser.FullName;
                    txtEmailNV.Text = selectedUser.Email;
                    txtDiaChiNV.Text = selectedUser.Address;
                    txtSDTNV.Text = selectedUser.Phone;
                    cboRole.Text = selectedUser.Role;
                    dpNgaySinhNV.Value = selectedUser.DOB;
                    btCapNhatNV.Tag = selectedUser.UserId;
                    btXoaNV.Tag = selectedUser.UserId;
                }
            }
        }

        private void btnSearchNV_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemNV.Text.Trim();
            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
                return;
            }

            string loaiTimKiem = rdoSDTNV.Checked ? "sdt" : "ten";

            List<User> result = nhanvienBL.TimKiemNhanVien(tuKhoa, loaiTimKiem);
            NhanVienBindingSource.DataSource = result;
            dgvNhanVien.DataSource = NhanVienBindingSource;
            dgvChinhSuaNV.DataSource = NhanVienBindingSource;
        }

    }
}
