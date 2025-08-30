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
    public class NhanVienBL
    {
            private NhanVienDL nhanVienDL = new NhanVienDL();

            public List<User> XemTatCaNhanVien()
            {
                return nhanVienDL.XemTatCaNhanVien();
            }
            public int CapNhatNhanVien(User user)
            {
                return nhanVienDL.CapNhatNhanVien(user);
            }
            public int XoaNhanVien(int userId)
            {
                return nhanVienDL.XoaNhanVien(userId);
            }
        public bool ThemNhanVien(User user, out string message)
        {
            if (!KiemTraThongTin(user, out message))
                return false;

            if (nhanVienDL.KiemTraTrung(user.Username, user.Email))
            {
                message = "Username hoặc Email đã tồn tại!";
                return false;
            }

            int newUserId = nhanVienDL.ThemNhanVien(user);
            if (newUserId > 0)
            {
                message = "Tạo tài khoản nhân viên thành công!";
                return true;
            }

            message = "Thêm nhân viên thất bại!";
            return false;
        }

        private bool KiemTraThongTin(User user, out string message)
        {
            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
            {
                message = "Tên đăng nhập và mật khẩu không được để trống!";
                return false;
            }
            if (string.IsNullOrWhiteSpace(user.FullName) || string.IsNullOrWhiteSpace(user.Phone))
            {
                message = "Họ tên và số điện thoại không được để trống!";
                return false;
            }
            try
            {
                var mail = new System.Net.Mail.MailAddress(user.Email);
            }
            catch
            {
                message = "Email không hợp lệ!";
                return false;
            }

            message = null;
            return true;
        }
        public List<User> TimKiemNhanVien(string tuKhoa, string kieuTim)
            {
                return nhanVienDL.TimKiemNhanVien(tuKhoa, kieuTim);
            }
    }
}
