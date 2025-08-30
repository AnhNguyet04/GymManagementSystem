using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class LoginDL: DataProvider
    {
        public Account Login(Account acc)
        {
            string sql = "SELECT User_id, Username, Role FROM Users WHERE Username = @username AND Password = @password";
            try
            {
                Connect(); // Mở kết nối

                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@username", acc.Username);
                    cmd.Parameters.AddWithValue("@password", acc.Password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Nếu tìm thấy tài khoản
                        {
                            int userId = Convert.ToInt32(reader["User_id"]);
                            string role = reader["Role"].ToString();

                            return new Account(reader["Username"].ToString(),acc.Password,role,userId);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect(); // Đóng kết nối
            }

            return null;
        }
    }
}
