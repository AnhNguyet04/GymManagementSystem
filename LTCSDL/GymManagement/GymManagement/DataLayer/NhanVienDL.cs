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
    public class NhanVienDL: DataProvider
    {
        public List<User> XemTatCaNhanVien()
        {
            List<User> list = new List<User>();
            string sql = @"
        SELECT e.User_id, u.Username, u.Full_name,u.DOB, u.Phone, u.Email, u.Address, e.Role
        FROM Users u INNER JOIN Employees e ON u.User_id = e.User_id";

            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new User
                    {
                        UserId = Convert.ToInt32(reader["User_id"]),
                        Username = reader["Username"].ToString(),
                        FullName = reader["Full_name"].ToString(),
                        DOB = reader["DOB"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DOB"]),
                        Phone = reader["Phone"].ToString(),
                        Email = reader["Email"].ToString(),
                        Address = reader["Address"].ToString(),
                        Role = reader["Role"].ToString()
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhân viên: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }
        private int ExecuteUserProc(string procedureName, User user, bool isInsert)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (procedureName.Equals("uspUpdateNhanVien", StringComparison.OrdinalIgnoreCase))
            {
                parameters.Add(new SqlParameter("@UserId", user.UserId));
            }
            else if (procedureName.Equals("uspAddNhanVien", StringComparison.OrdinalIgnoreCase))
            {
                parameters.Add(new SqlParameter("@Password", user.Password ?? string.Empty));
                
                var outputParam = new SqlParameter("@NewUserId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                parameters.Add(outputParam);
            }    
            parameters.Add(new SqlParameter("@Username", user.Username ?? string.Empty));
            parameters.Add(new SqlParameter("@FullName", user.FullName ?? string.Empty));
            parameters.Add(new SqlParameter("@DOB", user.DOB == DateTime.MinValue ? (object)DBNull.Value : user.DOB));
            parameters.Add(new SqlParameter("@Phone", user.Phone ?? string.Empty));
            parameters.Add(new SqlParameter("@Email", user.Email ?? string.Empty));
            parameters.Add(new SqlParameter("@Address", user.Address ?? string.Empty));
            parameters.Add(new SqlParameter("@Role", user.Role ?? string.Empty)); // đảm bảo thêm Role


            try
            {
                int result = MyExecuteNonQuery(procedureName, CommandType.StoredProcedure, parameters);
                // Nếu là thêm thì trả về ID vừa tạo
                if (procedureName.Equals("uspAddNhanVien", StringComparison.OrdinalIgnoreCase))
                {
                    var param = parameters.Find(p => p.ParameterName == "@NewUserId");
                    return param?.Value != DBNull.Value ? Convert.ToInt32(param.Value) : 0;
                }

                return result;
            }
            catch (SqlException ex)
            {
                throw new Exception("Lỗi khi thực thi stored procedure nhân viên: " + ex.Message + "\n" + ex.StackTrace);
            }
        }
        public int ThemNhanVien(User user)
        {
            return ExecuteUserProc("uspAddNhanVien", user, true);
        }
        public int CapNhatNhanVien(User user)
        {
            return ExecuteUserProc("uspUpdateNhanVien", user, false);
        }

        public int XoaNhanVien(int userId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@UserId", userId)
            };

            try
            {
                return MyExecuteNonQuery("uspDeleteNhanVien", CommandType.StoredProcedure, parameters);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50000) // RAISERROR mặc định sử dụng số 50000
                {
                    throw new Exception(ex.Message); // thông báo lỗi tùy chỉnh từ SQL
                }
                throw new Exception("Lỗi khi xóa nhân viên: " + ex.Message);
            }
        }
        public bool KiemTraTrung(string username, string email)
        {

            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand("uspKiemTraTrung", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Email", email);

                SqlParameter outParam = new SqlParameter("@Count", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outParam);

                cmd.ExecuteNonQuery();

                int count = (int)outParam.Value;
                return count > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception("Lỗi kiểm tra trùng: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }

        public bool ThemVaoEmployees(int userId, string role)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand("uspThemVaoEmployees", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Role", role);

                int rows = cmd.ExecuteNonQuery();

                return rows > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception("Lỗi SQL khi thêm vào Employees: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm vào Employees: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }
        public List<User> TimKiemNhanVien(string tuKhoa, string kieuTim)
        {
            string procName = "";
            switch (kieuTim.ToLower())
            {
                case "ten": procName = "uspSearchNhanVienByName"; break;
                case "sdt": procName = "uspSearchNhanVienByPhone"; break;
                default: throw new ArgumentException("Kiểu tìm kiếm không hợp lệ.");
            }

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@TuKhoa", tuKhoa)
            };

            List<User> list = new List<User>();

            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(procName, CommandType.StoredProcedure, parameters.ToArray());
                while (reader.Read())
                {
                    list.Add(new User
                    {
                        UserId = Convert.ToInt32(reader["User_id"]),
                        Username = reader["Username"].ToString(),
                        FullName = reader["Full_name"].ToString(),
                        DOB = reader["DOB"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["DOB"]),
                        Phone = reader["Phone"].ToString(),
                        Email = reader["Email"].ToString(),
                        Address = reader["Address"].ToString(),
                        Role = reader["Role"].ToString()
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm nhân viên: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }
    }
}
