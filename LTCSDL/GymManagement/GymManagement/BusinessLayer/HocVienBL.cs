using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class HocVienBL
    {
        private HocVienDL hocvienDL = new HocVienDL();
        public List<Students> XemTatCaHocVien()
        {
            return hocvienDL.XemTatCaHocVien();
        }
        public List<MembershipInfo> GetDanhSachMembership()
        {
            return hocvienDL.LayDanhSachMembership();
        }
        public bool CapNhatHocVien(Students student)
        {
            return hocvienDL.CapNhatHocVien(student);
        }

        public bool ThemHocVien(Students student)
        {
            return hocvienDL.ThemHocVien(student);
        }
        public bool XoaHocVien(int studentId)
        {
            return hocvienDL.XoaHocVien(studentId);
        }

        public bool KiemTraHocVienCoGoiTap(int userId)
        {
            return hocvienDL.KiemTraHocVienCoGoiTap(userId);
        }
        public List<Students> TimKiemHocVien(string tuKhoa, string loaiTimKiem)
        {
            return hocvienDL.TimKiemHocVien(tuKhoa, loaiTimKiem);
        }
        public bool KiemTraTrung(string fullname, string email, string phone)
        {
            return hocvienDL.KiemTraTrung(fullname, email, phone);
        }
        public bool KiemTraThongTinVaTrung(Students student, bool isUpdate, out string message)
        {
            if (string.IsNullOrWhiteSpace(student.FullName) ||
                string.IsNullOrWhiteSpace(student.Phone) ||
                string.IsNullOrWhiteSpace(student.Email))
            {
                message = "Vui lòng nhập đầy đủ họ tên, số điện thoại và email.";
                return false;
            }

            try
            {
                var mail = new System.Net.Mail.MailAddress(student.Email);
            }
            catch
            {
                message = "Email không hợp lệ.";
                return false;
            }

            var all = XemTatCaHocVien();
            foreach (Students s in all)
            {
                if (isUpdate && s.StudentId == student.StudentId) continue;

                if (s.Email.Equals(student.Email, StringComparison.OrdinalIgnoreCase))
                {
                    message = "Email đã tồn tại.";
                    return false;
                }

                if (s.Phone == student.Phone)
                {
                    message = "Số điện thoại đã tồn tại.";
                    return false;
                }

                if (s.FullName.Equals(student.FullName, StringComparison.OrdinalIgnoreCase))
                {
                    message = "Họ tên đã tồn tại.";
                    return false;
                }
            }

            message = null;
            return true;
        }
        public bool ThemGoiTap(Membership ms)
        {
            return hocvienDL.ThemGoiTap(ms);
        }

        public bool XoaGoiTap(int studentId)
        {
            return hocvienDL.XoaGoiTap(studentId);
        }

        public Membership LayGoiTapHienTai(int studentId)
        {
            return hocvienDL.LayGoiTapHienTai(studentId);
        }

        public bool Con1TuanTruocHetHan(Membership ms)
        {
            return (ms != null && (ms.Enddate - DateTime.Now).TotalDays <= 7);
        }
        public List<PackageTypeInfo> LayDanhSachGoiTap()
        {
            return hocvienDL.LayDanhSachGoiTap();
        }
    }
}
