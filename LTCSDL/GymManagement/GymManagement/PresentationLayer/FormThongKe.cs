using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using PresentationLayer.Helpers;
using TransferObject;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;

namespace PresentationLayer
{
    public partial class FormThongKe : Form
    {
        private int SelectedClassId = -1;
        public FormThongKe()
        {
            InitializeComponent();
            dgvThongKe.Columns["SelectColumn"].Visible = false;

            rdTatCaHV.CheckedChanged += rd_CheckedChanged;
            rdTheoLop.CheckedChanged += rd_CheckedChanged;
            rdMembership.CheckedChanged += rd_CheckedChanged;
            rdTatCaNhanVien.CheckedChanged += rd_CheckedChanged;
            rdAdmin.CheckedChanged += rd_CheckedChanged;
            rdLeTan.CheckedChanged += rd_CheckedChanged;
            rdHLV.CheckedChanged += rd_CheckedChanged;
            rdTatCaTT.CheckedChanged += rd_CheckedChanged;
            rdTot.CheckedChanged += rd_CheckedChanged;
            rdHuHong.CheckedChanged += rd_CheckedChanged;
            rdCanBT.CheckedChanged += rd_CheckedChanged;
            rdTatCaTT.CheckedChanged += rd_CheckedChanged;
            rdDaTT.CheckedChanged += rd_CheckedChanged;
            rdChuaTT.CheckedChanged += rd_CheckedChanged;
        }
        private void rd_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton changedRadio = sender as RadioButton;

            if (changedRadio.Checked)
            {
                // Duyệt tất cả radio button trong form
                foreach (Control ctrl in this.Controls)
                {
                    UncheckOtherRadioButtons(ctrl, changedRadio);
                }
            }
        }

        private void UncheckOtherRadioButtons(Control parent, RadioButton except)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is RadioButton rb && rb != except)
                {
                    rb.Checked = false;
                }
                else if (ctrl.HasChildren)
                {
                    UncheckOtherRadioButtons(ctrl, except);
                }
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (rdTatCaHV.Checked || rdTheoLop.Checked || rdMembership.Checked)
            { 
                DanhSachHocVien(); 
            }
            else if (rdTatCaNhanVien.Checked || rdAdmin.Checked || rdLeTan.Checked || rdHLV.Checked)
            { 
                DanhSachNhanVien(); 
            }
            else if (rdTatCaTB.Checked || rdTot.Checked || rdCanBT.Checked || rdHuHong.Checked)
            { 
                DanhSachThietBi(); 
            }
            else if (rdTatCaTT.Checked || rdChuaTT.Checked || rdDaTT.Checked)
            { 
                DanhSachThanhToan(); 
            }
        }
        private void DanhSachHocVien()
        {
            if (rdTatCaHV.Checked)
            {
                dgvThongKe.DataSource = new StudentsBL().GetAllStudents();
                dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
                if (rdMembership.Checked)
            {
                try
                {
                    dgvThongKe.DataSource = new HocVienBL().GetDanhSachMembership();
                    DataGridViewStyleHelper.FormatMembershipDGV(dgvThongKe);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            else if (rdTheoLop.Checked)
            {

                ClassesBL classBL = new ClassesBL();
                var classes = classBL.GetAllClasses();

                dgvThongKe.DataSource = classes;
                DataGridViewStyleHelper.FormatClassDGV(dgvThongKe);
                dgvThongKe.Columns["SelectColumn"].Visible = false;
            }
        }
        private void LoadStudents(int classId)
        {
            StudentsBL studentBL = new StudentsBL();
            var students = studentBL.GetStudentsByClassId(classId);
            dgvThongKe.DataSource = students;
            DataGridViewStyleHelper.FormatStudentDGV(dgvThongKe);
        }
        private void DanhSachNhanVien()
        {
            if (rdTatCaNhanVien.Checked)
            {
                List<User> data = new NhanVienBL().XemTatCaNhanVien();
                dgvThongKe.DataSource = data;
                if (dgvThongKe.Columns.Contains("Password"))
                    dgvThongKe.Columns["Password"].Visible = false;

                if (dgvThongKe.Columns.Contains("Password"))
                    dgvThongKe.Columns["Password"].Visible = false;
                DataGridViewStyleHelper.DinhDangDanhSachNhanVien(dgvThongKe);
            }
            else
            {
                string role = "";
                if (rdLeTan.Checked)
                    role = "Lễ tân";
                else if (rdHLV.Checked)
                    role = "Huấn luyện viên";
                else if (rdAdmin.Checked)
                    role = "Admin";
                var nhanvien = new NhanVienBL().XemTatCaNhanVien();
                var loc = nhanvien.Where(nv => nv.Role == role).ToList();
                dgvThongKe.DataSource = loc;
                DataGridViewStyleHelper.DinhDangDanhSachNhanVien(dgvThongKe);
            }
        }
        private void DanhSachThietBi()
        {
            if (rdTatCaTB.Checked)
            {
                List<Equipment> data = new ThietBiBL().XemTatCaThietBi();
                dgvThongKe.DataSource = data;

                dgvThongKe.DataBindingComplete += (object s, DataGridViewBindingCompleteEventArgs e) =>
                {
                    if (dgvThongKe.Columns.Contains("GymId"))
                        dgvThongKe.Columns["GymId"].Visible = false;
                };
                DataGridViewStyleHelper.DinhDangDanhSachThietBi(dgvThongKe);
            } 
            else
            {
                string tinhtrang = "";
                if (rdTot.Checked)
                    tinhtrang = "Tốt";
                else if (rdCanBT.Checked)
                    tinhtrang = "Cần bảo trì";
                else if (rdHuHong.Checked)
                    tinhtrang = "Hư hỏng";
                var thietbi = new ThietBiBL().XemTatCaThietBi();
                var loc = thietbi.Where(tb => tb.Status == tinhtrang).ToList();
                dgvThongKe.DataSource = loc;
                DataGridViewStyleHelper.DinhDangDanhSachThietBi(dgvThongKe);
            } 
        }
        private void DanhSachThanhToan()
        {
            if (rdTatCaTT.Checked)
            {
                dgvThongKe.DataSource = GetAllDangKyVaThanhToan();
                DataGridViewStyleHelper.DinhDangThanhToan(dgvThongKe);
                dgvThongKe.Columns["FullName"].HeaderText = "Học viên";
            }
            else
            {
                string tinhtrang = "";
                if (rdChuaTT.Checked)
                    tinhtrang = "Chưa thanh toán";
                else if (rdDaTT.Checked)
                    tinhtrang = "Đã thanh toán";
                var thanhtoan = GetAllDangKyVaThanhToan();
                var loc = thanhtoan.Where(tt =>tt.TinhTrang == tinhtrang).ToList();
                dgvThongKe.DataSource = loc;
                DataGridViewStyleHelper.DinhDangThanhToan(dgvThongKe);
                dgvThongKe.Columns["FullName"].HeaderText = "Học viên";
            } 
                
        }
        public List<PaymentView> GetAllDangKyVaThanhToan(bool onlyPaid = false)
        {
            var studentBL = new StudentsBL();
            var students = studentBL.GetAllStudents(); // Lấy tất cả học viên

            var paymentBL = new PaymentBL();
            var allPayments = paymentBL.GetAllPayments(); // Lấy tất cả thanh toán

            var classBL = new ClassesBL();
            var studentClassBL = new Students_ClassBL();
            var membershipBL = new MembershipBL();

            var result = new List<PaymentView>();

            foreach (var student in students)
            {
                var classes = studentClassBL.GetClassesByStudent(student.StudentId);
                var memberships = membershipBL.GetMemberships(student.StudentId);
                var payments = allPayments.Where(p => p.StudentId == student.StudentId).ToList();

                foreach (var cls in classes)
                {
                    var payment = payments.FirstOrDefault(p => p.ReferenceId == cls.ClassID && p.PaymentType == "Class");
                    if (onlyPaid && payment == null) continue;

                    result.Add(new PaymentView
                    {
                        FullName = student.FullName,
                        Loai = "Lớp học",
                        Ten = cls.ClassName,
                        Gia = cls.Price,
                        PaymentType = "Class",
                        ReferenceId = cls.ClassID,
                        TinhTrang = payment != null ? "Đã thanh toán" : "Chưa thanh toán",
                        TransactionDate = payment?.TransactionDate.ToString("dd/MM/yyyy") ?? ""
                    });
                }

                foreach (var mem in memberships)
                {
                    var payment = payments.FirstOrDefault(p => p.ReferenceId == mem.MembershipId && p.PaymentType == "Membership");
                    if (onlyPaid && payment == null) continue;

                    result.Add(new PaymentView
                    {
                        FullName = student.FullName,
                        Loai = "Gói thành viên",
                        Ten = mem.Packagetype + $" ({mem.Startdate:dd/MM/yyyy} - {mem.Enddate:dd/MM/yyyy})",
                        Gia = mem.Price,
                        PaymentType = "Membership",
                        ReferenceId = mem.MembershipId,
                        TinhTrang = payment != null ? "Đã thanh toán" : "Chưa thanh toán",
                        TransactionDate = payment?.TransactionDate.ToString("dd/MM/yyyy") ?? ""
                    });
                }
            }

            return result;
        }
        private void dgvThongKe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (rdTheoLop.Checked)
            {
                if (e.RowIndex >= 0)
                {
                    SelectedClassId = Convert.ToInt32(dgvThongKe.Rows[e.RowIndex].Cells["ClassID"].Value);
                    LoadStudents(SelectedClassId);
                }
            }
        }

        private void XuatExcel(string path)
        { 
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);
            for (int i = 1; i < dgvThongKe.Columns.Count; i++)
            {
                application.Cells[1, i] = dgvThongKe.Columns[i].HeaderText;
            }
            for (int i = 0; i < dgvThongKe.Rows.Count; i++)
            {
                for (int j = 1; j < dgvThongKe.Columns.Count; j++)
                {
                    application.Cells[i + 2, j] = dgvThongKe.Rows[i].Cells[j].Value;
                }
            }
            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "DANH SÁCH THỐNG KÊ";
            saveFileDialog.Filter = "Excel(*.xlsx)|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XuatExcel(saveFileDialog.FileName);
                    MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xuất file thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void TimKiem()
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            if (rdTatCaHV.Checked || rdTheoLop.Checked || rdMembership.Checked)
            {
                var students = new StudentsBL().GetAllStudents();
                var filtered = students.Where(hv => hv.FullName != null && hv.FullName.ToLower().Contains(keyword)).ToList();
                dgvThongKe.DataSource = filtered;
                if (rdTatCaHV.Checked)
                {
                    dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else if (rdTheoLop.Checked)
                {
                    DataGridViewStyleHelper.FormatClassDGV(dgvThongKe);
                }   
                else if (rdMembership.Checked)
                {
                    DataGridViewStyleHelper.FormatClassDGV(dgvThongKe);
                }    
            }
            else if (rdTatCaNhanVien.Checked || rdAdmin.Checked || rdLeTan.Checked || rdHLV.Checked)
            {
                var nhanvien = new NhanVienBL().XemTatCaNhanVien();
                var filtered = nhanvien.Where(nv => nv.FullName!=null && nv.FullName.ToLower().Contains(keyword)).ToList();
                dgvThongKe.DataSource = filtered;
                DataGridViewStyleHelper.DinhDangDanhSachNhanVien(dgvThongKe);
            }
            else if (rdTatCaTB.Checked || rdTot.Checked || rdHuHong.Checked || rdCanBT.Checked)
            {
                var thietbi = new ThietBiBL().XemTatCaThietBi();
                var filtered = thietbi.Where(tb => tb.Name!= null && tb.Name.ToLower().Contains(keyword)).ToList();
                dgvThongKe.DataSource = filtered;
                DataGridViewStyleHelper.DinhDangDanhSachThietBi(dgvThongKe);
            }  
            else if (rdTatCaTT.Checked || rdDaTT.Checked || rdChuaTT.Checked)
            {
                var thanhtoan = GetAllDangKyVaThanhToan();
                var filtered = thanhtoan.Where(tt => tt.FullName != null && tt.FullName.ToLower().Contains(keyword)).ToList();
                dgvThongKe.DataSource = filtered;
                DataGridViewStyleHelper.DinhDangThanhToan(dgvThongKe);
                dgvThongKe.Columns["FullName"].HeaderText = "Học viên";
            } 
        }
        private void btTimKiem_Click(object sender, EventArgs e)
        {
            TimKiem();
        }
    }
}
