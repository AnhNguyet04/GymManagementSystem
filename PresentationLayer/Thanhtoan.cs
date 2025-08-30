using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;
using PresentationLayer.Helpers;

namespace PresentationLayer
{
    public partial class Thanhtoan : Form
    {
        //biến để lưu thông tin dòng đang chọn
        private int selectedStudentId;
        private int selectedClassId;
        private decimal selectedAmount;
        private string selectedPaymentType;
        private bool isLichSuThanhToan = false;
        private bool isInReminderMode = false;

        public Thanhtoan()
        {
            InitializeComponent();
            LoadHocVien();
            dgvThanhtoan.RowPrePaint += dgvThanhtoan_RowPrePaint;
        }
        private void btnQuayve_Click(object sender, EventArgs e)
        {
            LoadHocVien();
            selectedStudentId = 0;
            selectedClassId = 0;
            selectedAmount = 0;
            selectedPaymentType = string.Empty;
        }

        private void LoadHocVien()
        {
            dgvThanhtoan.DataSource = null;
            StudentsBL studentBL = new StudentsBL();
            dgvThanhtoan.DataSource = studentBL.GetAllStudents();
            DataGridViewStyleHelper.FormatStudentDGV(dgvThanhtoan);

            isInReminderMode = false;
        }
        private void dgvThanhtoan_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dgvThanhtoan.Columns.Contains("TinhTrang"))
            {
                var row = dgvThanhtoan.Rows[e.RowIndex];
                var cellValue = row.Cells["TinhTrang"].Value?.ToString();
                if (cellValue == "Chưa thanh toán")
                {
                    row.DefaultCellStyle.BackColor = Color.LightPink;
                    row.DefaultCellStyle.Font = new Font(dgvThanhtoan.Font, FontStyle.Bold);
                }
            }
        }

        private void dgvThanhtoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isInReminderMode) return;
            if (e.RowIndex >= 0)
            {
                if (dgvThanhtoan.Columns.Contains("StudentId"))
                {
                    selectedStudentId = Convert.ToInt32(dgvThanhtoan.Rows[e.RowIndex].Cells["StudentId"].Value);
                    if (isLichSuThanhToan)
                    {
                        DanhSachDangKy(selectedStudentId, onlyPaid: true);
                        isLichSuThanhToan = false;
                    }
                    else
                    { DanhSachDangKy(selectedStudentId); }
                }    
               else
                {
                    string tinhtrang = dgvThanhtoan.Rows[e.RowIndex].Cells["TinhTrang"].Value.ToString();
                    if (tinhtrang == "Chưa thanh toán")
                    {
                        selectedClassId = Convert.ToInt32(dgvThanhtoan.Rows[e.RowIndex].Cells["ReferenceId"].Value);
                        selectedAmount = Convert.ToDecimal(dgvThanhtoan.Rows[e.RowIndex].Cells["Gia"].Value);
                        selectedPaymentType = dgvThanhtoan.Rows[e.RowIndex].Cells["PaymentType"].Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Khoản này đã được thanh toán!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        selectedClassId = 0;
                        selectedAmount = 0;
                        selectedPaymentType = string.Empty;
                    }
                }    
            }    
        }
       

        private void DanhSachDangKy(int studentId, bool onlyPaid = false)
        {
            ClassesBL classesBL = new ClassesBL();

            Students_ClassBL students_ClassBL = new Students_ClassBL();
            List<Classes> classes = students_ClassBL.GetClassesByStudent(studentId);

            MembershipBL membershipBL = new MembershipBL();
            List<Membership> memberships = membershipBL.GetMemberships(studentId);

            PaymentBL paymentBL = new PaymentBL();
            List<Payment> payments = paymentBL.GetPaymentsByStudentId(studentId);

            var list = new List<PaymentView>();
            foreach (var cls in classes)
            {
                var payment = payments.FirstOrDefault(p => p.ReferenceId == cls.ClassID && p.PaymentType == "Class");
                if (onlyPaid && payment == null) continue;
                list.Add(new PaymentView
                {
                    Loai = "Lớp học",
                    Ten = cls.ClassName,
                    Gia = cls.Price,
                    PaymentType = "Class",
                    ReferenceId = cls.ClassID,
                    TinhTrang = payment != null ? "Đã thanh toán":"Chưa thanh toán",
                    TransactionDate = payment?.TransactionDate.ToString("dd/MM/yyyy") ?? ""
                });
            } 
            foreach (var mem in memberships)
            {
                var payment = payments.FirstOrDefault(p => p.ReferenceId == mem.MembershipId && p.PaymentType == "Membership");
                if (onlyPaid && payment == null) continue;
                list.Add(new PaymentView
                {
                    Loai = "Gói thành viên",
                    Ten = mem.Packagetype + $" ({mem.Startdate:dd/MM/yyyy} - {mem.Enddate:dd/MM/yyyy})",
                    Gia = mem.Price,
                    PaymentType = "Membership",
                    ReferenceId = mem.MembershipId,
                    TinhTrang = payment != null ? "Đã thanh toán" : "Chưa thanh toán",
                    TransactionDate = payment?.TransactionDate.ToString("dd/MM/yyyy") ?? ""
                });
            }
            dgvThanhtoan.DataSource = list;
            DataGridViewStyleHelper.DinhDangThanhToan(dgvThanhtoan);

        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            if (selectedStudentId !=0 && selectedClassId !=0)
            {
                Form form = new PhuongthucTT(selectedStudentId, selectedClassId, selectedAmount, selectedPaymentType);
                form.ShowDialog();

                DanhSachDangKy(selectedStudentId);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một lớp chưa thanh toán để thực hiện thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnLichSu_Click(object sender, EventArgs e)
        {
            isInReminderMode = false;
            isLichSuThanhToan = true;
            LoadHocVien();
            if (selectedStudentId == 0)
            {
                MessageBox.Show("Vui lòng chọn học viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void GuiMail(string from, string to, string subject, string message, Attachment file = null)
        {
            MailMessage message1 = new MailMessage(from, to, subject, message); ;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("nguyetvts2004@gmail.com", "ojbv qnhf geyt inyh");
              
            client.Send(message1);
        }

        private void btnNhacNho_Click_1(object sender, EventArgs e)
        {
            isInReminderMode = true;
            var danhSach = DanhSachNhacNho();
            //Hiển thị lên DTGV
            dgvThanhtoan.DataSource = danhSach;
            
            var nhomTheoHocVien = danhSach.GroupBy(x => new { x.StudentId, x.Email, x.TenHocVien }).ToList();
            foreach (var group in nhomTheoHocVien)
            {
                if (string.IsNullOrEmpty(group.Key.Email)) continue;
                string subject = "Nhắc Nhở Thanh Toán Học Phí";
                string body = $@"Xin chào {group.Key.TenHocVien},

Chúng tôi thấy bạn đang có các khoản học phí chưa được thanh toán:

{string.Join("\n", group.Select(x => $"- {x.Loai}: {x.Ten} | Giá: {x.Gia:N0} VND | Ngày: {x.NgayDangKy}"))}

Vui lòng hoàn tất thanh toán sớm nhất có thể để không gây gián đoạn các dịch vụ trong tương lai.
Nếu có bất kỳ sự nhầm lẫn nào, vui lòng liên hệ qua hotline: 0565618783 hoặc đến quầy tại các cơ sở EVOGYM gần nhất.

Xin chân thành cảm ơn và xin lỗi nếu có bất kỳ sự bất tiện nào.

Trân trọng,
EVOGYM";
                GuiMail("nguyetvts2004@gmail.com", group.Key.Email, subject, body);
            }
            MessageBox.Show("Đã gửi email nhắc nhở đến các học viên!", "Thành công");
        }
        private List<NhacNho> DanhSachNhacNho()
        {
            StudentsBL studentsBL = new StudentsBL();
            Students_ClassBL scBL = new Students_ClassBL();
            MembershipBL membershipBL = new MembershipBL();
            PaymentBL paymentBL = new PaymentBL();
            ClassesBL classesBL = new ClassesBL();

            var danhSach = new List<NhacNho>();
            var students = studentsBL.GetAllStudents();
            foreach (var student in students)
            {
                var payments = paymentBL.GetPaymentsByStudentId(student.StudentId);
                var classes = scBL.GetClassesByStudentId(student.StudentId);

                //Lớp học
                foreach (var cls in classes)
                {
                    bool isPaid = payments.Any(p => p.ReferenceId == cls.ClassId && p.PaymentType == "Class");
                    /*if (!isPaid && (DateTime.Now - cls.RegisteredDate).TotalDays >= 1)*/
                    if (!isPaid)
                    {
                        var classDetail = classesBL.GetClassById(cls.ClassId);
                        danhSach.Add(new NhacNho
                        {
                            StudentId = student.StudentId,
                            TenHocVien = student.FullName,
                            Email = student.Email,
                            Loai = "Lớp học",
                            Ten = classDetail.ClassName,
                            Gia = classDetail.Price,
                            NgayDangKy = cls.RegisteredDate.ToString("dd/MM/yyyy")
                        });
                    }
                }

                //Membership
                var memberships = membershipBL.GetMemberships(student.StudentId);
                foreach (var mem in memberships)
                {
                    bool isPaid = payments.Any(p => p.ReferenceId == mem.MembershipId && p.PaymentType == "Membership");
                    /*if (!isPaid && (DateTime.Now - mem.Startdate).TotalDays >= 1)*/
                    if (!isPaid) 
                    {
                        danhSach.Add(new NhacNho
                        {
                            StudentId = student.StudentId,
                            TenHocVien = student.FullName,
                            Email = student.Email,
                            Loai = "Gói membership",
                            Ten = mem.Packagetype,
                            Gia = mem.Price,
                            NgayDangKy = mem.Startdate.ToString("dd/MM/yyyy")
                        });
                    }
                }
            }
            return danhSach;
        }
        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(tuKhoa))
            {

                List<Students> ketQua = new HocVienBL().TimKiemHocVien(tuKhoa, "Ten");

                dgvThanhtoan.DataSource = ketQua;
                DataGridViewStyleHelper.FormatStudentDGV(dgvThanhtoan);
            }
            else
            {
                LoadHocVien(); // Hiển thị lại toàn bộ danh sách học viên
            }
        }

    }
}
