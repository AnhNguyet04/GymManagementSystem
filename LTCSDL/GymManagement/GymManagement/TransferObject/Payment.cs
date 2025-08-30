using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int StudentId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentType { get; set; }
        public int ReferenceId { get; set; }
        public DateTime TransactionDate { get; set; }
    }
    public class PaymentView
    {
        public string FullName { get; set; }
        public string Loai { get; set; }
        public string Ten { get; set; }
        public decimal Gia { get; set; }
        public string TinhTrang { get; set; }
        public int ReferenceId { get; set; }
        public string PaymentType { get; set; }
        public string TransactionDate { get; set; }
    }
    public class NhacNho
    {
        public int StudentId { get; set; }
        public string TenHocVien { get; set; }
        public string Email { get; set; }
        public string Loai { get; set; }    //Lớp học hoặc Membership
        public string Ten { get; set; }         //Tên lớp học hoặc gói
        public decimal Gia { get; set; }
        public string NgayDangKy {  get; set; }     //Ngày bắt đầu cho gói
    }

}
