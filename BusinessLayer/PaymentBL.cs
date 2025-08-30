using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using DataLayer;

namespace BusinessLayer
{
    public class PaymentBL
    {
        public List<Payment> GetPaymentsByStudentId(int studentId)
        {
            return new PaymentDL().GetPaymentsByStudentId(studentId);
        }
        public void AddPayment(Payment payment)
        {
            new PaymentDL().InsertPayment(payment);
        }
        public bool KiemTraThanhToan(int studentId, int referenceId, string paymentType)
        {
            return new PaymentDL().KiemTraThanhToan(studentId, referenceId, paymentType);
        }
        public List<Payment> GetAllPayments()
        {
            return new PaymentDL().GetAllPayments();
        }
    }
}
