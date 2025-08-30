using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class PaymentDL : DataProvider
    {
        public List<Payment> GetPaymentsByStudentId(int studentId)
        {
            List<Payment> payments = new List<Payment>();
            string sql = "SELECT * FROM Payment WHERE Student_id = @Student_id";
            SqlParameter[] parameters = { new SqlParameter("@Student_id", studentId) };
            Connect();
            try
            {
                using (SqlDataReader reader = MyExecuteReader(sql, CommandType.Text, parameters))
                {
                    while (reader.Read())
                    {
                        Payment p = new Payment
                        {
                            PaymentId = Convert.ToInt32(reader["Payment_id"]),
                            StudentId = Convert.ToInt32(reader["Student_id"]),
                            Amount = Convert.ToDecimal(reader["Amount"]),
                            PaymentMethod = reader["Payment_method"].ToString(),
                            PaymentType = reader["Payment_Type"].ToString(),
                            ReferenceId = reader["Reference_id"] != DBNull.Value ? Convert.ToInt32(reader["Reference_id"]) : 0,
                            TransactionDate = Convert.ToDateTime(reader["Transaction_date"])
                        };
                        payments.Add(p);
                    }
                }
            }
            finally
            {
                DisConnect();
            }
            return payments;
        }
        public void InsertPayment(Payment payment)
        {
            string sql = "INSERT INTO Payment (Student_id, Amount, Payment_method, Payment_Type, Reference_id) VALUES (@Student_id, @Amount, @Payment_method, @Payment_Type, @Reference_id)";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Student_Id", payment.StudentId);
                cmd.Parameters.AddWithValue("@Amount", payment.Amount);
                cmd.Parameters.AddWithValue("@Payment_method", payment.PaymentMethod);
                cmd.Parameters.AddWithValue("@Payment_Type", payment.PaymentType);
                cmd.Parameters.AddWithValue("@Reference_id", payment.ReferenceId);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                DisConnect();
            }
        }
        public bool KiemTraThanhToan(int studentId, int referenceId, string paymentType)
        {
            string sql = "SELECT COUNT(*) FROM Payment WHERE Student_id = @Student_id AND Reference_id = @Reference_id AND Payment_Type = @Payment_Type";
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@Student_id", studentId);
                cmd.Parameters.AddWithValue("@Reference_id", referenceId);
                cmd.Parameters.AddWithValue("@Payment_Type", paymentType);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            finally
            { 
                DisConnect(); 
            }
        }
        public List<Payment> GetAllPayments()
        {
            var list = new List<Payment>();
            string sql = @"SELECT Payment_id, Student_id, Amount, Payment_method, Payment_Type, Reference_id, Transaction_date
                       FROM Payment";

            Connect();
            try
            {
                using (var reader = MyExecuteReader(sql, CommandType.Text))
                {
                    while (reader.Read())
                    {
                        list.Add(new Payment
                        {
                            PaymentId = Convert.ToInt32(reader["Payment_id"]),
                            StudentId = Convert.ToInt32(reader["Student_id"]),
                            Amount = Convert.ToDecimal(reader["Amount"]),
                            PaymentMethod = reader["Payment_method"].ToString(),
                            PaymentType = reader["Payment_Type"].ToString(),
                            ReferenceId = reader["Reference_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Reference_id"]),
                            TransactionDate = Convert.ToDateTime(reader["Transaction_date"])
                        });
                    }
                }
            }
            finally
            {
                DisConnect();
            }
            return list;
        }
    }
}

    
