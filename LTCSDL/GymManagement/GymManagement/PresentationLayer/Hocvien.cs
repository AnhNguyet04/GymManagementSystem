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
using PresentationLayer.Helpers;

namespace PresentationLayer
{
    public partial class Hocvien : Form
    {
        private HocVienBL hocvienBL = new HocVienBL();
        private BindingSource hocVienBindingSource = new BindingSource();
        public Hocvien()
        {
            InitializeComponent();
            DataGridViewStyleHelper.ApplyCustomStyle(dgvHocVien);
            pnThemHocVien.Visible = false;
            this.Load += Hocvien_Load;
        }

        private void Hocvien_Load(object sender, EventArgs e)
        {
            LoadDanhSachHocVien();
            PhanQuyenTheoVaiTro();
            btThemHV.Visible = false;
            btCapNhat.Visible = false;
            btXoaHV.Visible = false;
            btClearHV.Visible = false;
            btXoaGoiTap.Visible = false;
        }
        private void PhanQuyenTheoVaiTro()
        {
            string role = UserSession.Role;
            if (role == "Lễ tân")
            {
                btXoaGoiTap.Visible = false;
                btCapNhat.Visible=false;
                btXoaHV.Visible=false;
            }
        }

        private void LoadDanhSachHocVien()
        {
            List<Students> data = hocvienBL.XemTatCaHocVien();
            hocVienBindingSource.DataSource = data;

            dgvHocVien.DataSource = hocVienBindingSource;
            dgvChinhSuaHV.DataSource = hocVienBindingSource;
            dgvChinhSuaHV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHocVien.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;

            //DinhDangDanhSachHocVien();

        }
        private void btnDSHV_Click(object sender, EventArgs e)
        {
            btThemGoiTap.Visible = true;
            pnThemHocVien.Visible = false;
            btThemHV.Visible = false;
            btCapNhat.Visible = false;
            btXoaHV.Visible = false;
            btClearHV.Visible = false;
            btXoaGoiTap.Visible = false;

            LoadDanhSachHocVien();
        }
        private void btnCapnhatHV_Click(object sender, EventArgs e)
        {
            LoadDanhSachHocVien();
            pnThemHocVien.Visible = true;
            btThemHV.Visible = true;
            btCapNhat.Visible = true;
            if (UserSession.Role == "Admin")
            {
                btXoaHV.Visible = true;
            }
            btClearHV.Visible = true;
            btThemGoiTap.Visible = false;
            btXoaGoiTap.Visible = false;
        }

        private void btnMembership_Click(object sender, EventArgs e)
        {
            btThemHV.Visible = false;
            btCapNhat.Visible = false;
            btXoaHV.Visible = false;
            btClearHV.Visible = false;
            pnThemHocVien.Visible = false;
            btThemGoiTap.Visible = false;
            if (UserSession.Role == "Admin")
            {
                btXoaGoiTap.Visible = true;
            }
            try
            {
                List<MembershipInfo> danhSach = hocvienBL.GetDanhSachMembership();
                hocVienBindingSource.DataSource = danhSach;
                dgvHocVien.DataSource = hocVienBindingSource;

                DataGridViewStyleHelper.FormatMembershipDGV(dgvHocVien);
                dgvHocVien.Columns["ClassNames"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private Students LayThongTinTuForm()
        {
            return new Students
            {
                FullName = txtHoVaTen.Text.Trim(),
                DOB = dpNgaySinhHV.Value,
                Gender = rdoNam.Checked ? "Nam" : "Nữ",
                Phone = txtSDTHV.Text.Trim(),
                Email = txtEmailHV.Text.Trim(),
                Address = txtDiaChiHV.Text.Trim(),
                RegisteredDate = dpNgayDK.Value
            };
        }
        private void btThemHV_Click_1(object sender, EventArgs e)
        {
            Students newStudent = LayThongTinTuForm();

            if (hocvienBL.KiemTraThongTinVaTrung(newStudent, false, out string message))
            {
                if (hocvienBL.ThemHocVien(newStudent))
                {
                    MessageBox.Show("Thêm học viên thành công.");
                    LoadDanhSachHocVien();
                }
                else
                {
                    MessageBox.Show("Thêm học viên thất bại.");
                }
            }
            else
            {
                MessageBox.Show(message); // => Thông báo lỗi như: "Email đã tồn tại."
            }
        }

        private void btCapNhat_Click_1(object sender, EventArgs e)
        {
            if (btCapNhat.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn học viên để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int studentId = Convert.ToInt32(btCapNhat.Tag);

            Students student = LayThongTinTuForm();
            student.StudentId = studentId;

            if (hocvienBL.KiemTraThongTinVaTrung(student, true, out string message))
            {
                bool success = hocvienBL.CapNhatHocVien(student);
                if (success)
                {
                    MessageBox.Show("Cập nhật học viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachHocVien();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btClearHV_Click(object sender, EventArgs e)
        {
            txtHoVaTen.Clear();
            txtEmailHV.Clear();
            txtDiaChiHV.Clear();
            txtSDTHV.Clear();
            dpNgaySinhHV.Value = DateTime.Now;
        }

        private void btXoaHV_Click(object sender, EventArgs e)
        {
            if (dgvChinhSuaHV.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn học viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Students selectedStudent = dgvChinhSuaHV.CurrentRow.DataBoundItem as Students;
            if (selectedStudent == null) return;

            if (hocvienBL.KiemTraHocVienCoGoiTap(selectedStudent.StudentId))
            {
                MessageBox.Show("Không thể xóa! Học viên vẫn đang có gói tập còn hiệu lực.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa học viên \"{selectedStudent.FullName}\" không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (hocvienBL.XoaHocVien(selectedStudent.StudentId))
                {
                    MessageBox.Show("Xóa học viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachHocVien();
                }
                else
                {
                    MessageBox.Show("Xóa học viên thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {

            string tuKhoa = txtTimKiem.Text.Trim();
            
            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.");
                return;
            }

            string loaiTimKiem = "Ten";
            if (rdoLop.Checked)
                loaiTimKiem = "Lop";
            else if (rdoSDT.Checked)
                loaiTimKiem = "SDT";

            try
            {
                List<Students> result = hocvienBL.TimKiemHocVien(tuKhoa, loaiTimKiem);
                hocVienBindingSource.DataSource = result;
                dgvHocVien.DataSource = hocVienBindingSource;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void dgvChinhSuaHV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selected = dgvChinhSuaHV.Rows[e.RowIndex].DataBoundItem as Students;
                if (selected == null) return;

                txtHoVaTen.Text = selected.FullName;
                txtEmailHV.Text = selected.Email;
                txtDiaChiHV.Text = selected.Address;
                txtSDTHV.Text = selected.Phone;
                dpNgaySinhHV.Value = selected.DOB ?? DateTime.Now;

                rdoNam.Checked = selected.Gender == "Nam";
                rdoNu.Checked = selected.Gender == "Nữ";

                btCapNhat.Tag = selected.StudentId;
            }
        }

        private void btThemGoiTap_Click(object sender, EventArgs e)
        {
            if (dgvHocVien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn học viên để thêm gói tập.");
                return;
            }
            if (!(dgvHocVien.CurrentRow.DataBoundItem is Students selectedStudent))
            {
                MessageBox.Show("Hiện không ở chế độ danh sách học viên. Vui lòng chuyển về danh sách học viên để thêm gói tập.");
                return;
            }

            int studentId = selectedStudent.StudentId;

            Membership goiTap = hocvienBL.LayGoiTapHienTai(studentId);
            if (goiTap != null && goiTap.Enddate >= DateTime.Now)
            {
                if (hocvienBL.Con1TuanTruocHetHan(goiTap))
                {
                    MessageBox.Show("Cảnh báo: Gói tập của học viên này sắp hết hạn trong vòng 1 tuần.");
                }
                else
                {
                    MessageBox.Show("Học viên này đang có gói tập còn hiệu lực.");
                    return;
                }
            }

            FormMembership form = new FormMembership(studentId);
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (hocvienBL.ThemGoiTap(form.MembershipMoi))
                {
                    MessageBox.Show("Thêm gói tập thành công.");
                    LoadDanhSachHocVien();  // Làm mới danh sách học viên
                }
                else
                {
                    MessageBox.Show("Thêm gói tập thất bại.");
                }
            }
        }

        private void btXoaGoiTap_Click(object sender, EventArgs e)
        {
            if (dgvHocVien.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn học viên để xóa gói tập.");
                return;
            }

            // Lấy thông tin từ hàng đang chọn, kiểu MembershipInfo
            var selectedMembership = dgvHocVien.CurrentRow.DataBoundItem as MembershipInfo;
            if (selectedMembership == null)
            {
                MessageBox.Show("Không lấy được thông tin học viên.");
                return;
            }

            int studentId = selectedMembership.UserId;

            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa gói tập của học viên này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (hocvienBL.XoaGoiTap(studentId))
                {
                    MessageBox.Show("Xóa gói tập thành công.");
                    LoadDanhSachHocVien(); // Cập nhật lại danh sách
                }
                else
                {
                    MessageBox.Show("Xóa gói tập thất bại hoặc không tồn tại.");
                }
            }
        }
    }
}
