using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Diagnostics;

namespace DataLayer
{
    public class HocVienDL : DataProvider
    {

        public List<Students> XemTatCaHocVien()
        {
            string sql = "SELECT * FROM Students";
            List<Students> list = new List<Students>();
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Students student = new Students
                    {
                        StudentId = Convert.ToInt32(reader["Student_id"]),
                        FullName = reader["Full_name"].ToString(),
                        DOB = reader["DOB"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["DOB"]),
                        Gender = reader["Gender"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Email = reader["Email"].ToString(),
                        Address = reader["Address"].ToString(),
                        RegisteredDate = Convert.ToDateTime(reader["RegisteredDate"])
                    };
                    list.Add(student);
                }
                return list;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
        private int ExecuteStudentProc(string procName, Students student)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (procName.Equals("uspUpdateStudent", StringComparison.OrdinalIgnoreCase))
            {
                parameters.Add(new SqlParameter("@StudentId", student.StudentId));
            }

            parameters.Add(new SqlParameter("@FullName", student.FullName));
            parameters.Add(new SqlParameter("@DOB", (object)student.DOB ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Gender", student.Gender));
            parameters.Add(new SqlParameter("@Phone", student.Phone));
            parameters.Add(new SqlParameter("@Email", student.Email));
            parameters.Add(new SqlParameter("@Address", student.Address));
            try
            {
                return MyExecuteNonQuery(procName, CommandType.StoredProcedure, parameters);
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }
        public bool ThemHocVien(Students student)
        {
            try
            {
                return ExecuteStudentProc("uspAddStudent", student) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm học viên: " + ex.Message);
            }
        }
        public bool CapNhatHocVien(Students student)
        {
            try
            {
                return ExecuteStudentProc("uspUpdateStudent", student) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật học viên: " + ex.Message);
            }
        }

        public bool XoaHocVien(int studentId)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@StudentId", studentId)
                };

                return MyExecuteNonQuery("uspDeleteStudent", CommandType.StoredProcedure, parameters) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa học viên: " + ex.Message);
            }
        }

        public List<Students> TimKiemHocVien(string tuKhoa, string loaiTimKiem)
        {
            string procName = "";
            switch (loaiTimKiem)
            {
                case "Ten": procName = "uspSearchStudentsByName"; break;
                case "SDT": procName = "uspSearchStudentsByPhone"; break;
                case "Lop": procName = "uspSearchStudentsByClassName"; break;
                default: throw new ArgumentException("Loại tìm kiếm không hợp lệ.");
            }
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                 new SqlParameter("@TuKhoa", tuKhoa)
            };

            List<Students> result = new List<Students>();
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(procName, CommandType.StoredProcedure, parameters.ToArray());
                while (reader.Read())
                {
                    result.Add(new Students
                    {
                        StudentId = Convert.ToInt32(reader["Student_id"]),
                        FullName = reader["Full_name"].ToString(),
                        DOB = reader["DOB"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["DOB"]),
                        Gender = reader["Gender"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Email = reader["Email"].ToString(),
                        Address = reader["Address"].ToString(),
                        RegisteredDate = Convert.ToDateTime(reader["RegisteredDate"])
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }

        public bool KiemTraTrung(string fullname, string email, string phone)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@FullName", fullname),
                new SqlParameter("@Email", email),
                new SqlParameter("@Phone", phone)
            };
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader("uspCheckStudentExists", CommandType.StoredProcedure, parameters.ToArray());
                if (reader.Read())
                {
                    int count = Convert.ToInt32(reader["SoLuong"]);
                    return count > 0;
                }
                return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }

        public bool KiemTraHocVienCoGoiTap(int studentId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                 new SqlParameter("@StudentId", studentId)
            };

            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader("uspHasValidMembership", CommandType.StoredProcedure, parameters.ToArray());
                if (reader.Read())
                {
                    int count = Convert.ToInt32(reader["SoLuong"]);
                    return count > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra gói tập: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }

        public List<MembershipInfo> LayDanhSachMembership()
        {
            List<MembershipInfo> list = new List<MembershipInfo>();
            string query = @"
                            SELECT s.Student_id, s.Full_name, m.Package_type, m.Price, m.Start_date, m.End_date,
                            STRING_AGG(c.Class_name, ', ') AS ClassNames
                            FROM Memberships m
                            INNER JOIN Students s ON m.Student_id = s.Student_id
                            LEFT JOIN Student_Classes sc ON sc.Student_id = s.Student_id AND sc.Status = N'Đang hoạt động'
                            LEFT JOIN Classes c ON sc.Class_id = c.Class_id
                            WHERE s.Student_id IN (
                            SELECT DISTINCT Student_id FROM Student_Classes WHERE Status = N'Đang hoạt động'
                            )
                            GROUP BY s.Student_id, s.Full_name, m.Package_type, m.Price, m.Start_date, m.End_date";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new MembershipInfo
                    {
                        UserId = Convert.ToInt32(reader["Student_id"]),
                        FullName = reader["Full_name"].ToString(),
                        PackageType = reader["Package_type"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"]),
                        StartDate = Convert.ToDateTime(reader["Start_date"]),
                        EndDate = Convert.ToDateTime(reader["End_date"]),
                        ClassNames = reader["ClassNames"].ToString()
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách membership: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }
        public bool ThemGoiTap(Membership ms)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@StudentId", ms.StudentId),
                new SqlParameter("@PackageType", ms.Packagetype),
                new SqlParameter("@StartDate", ms.Startdate),
                new SqlParameter("@EndDate", ms.Enddate),
                new SqlParameter("@Price", ms.Price)
            };

            return MyExecuteNonQuery("uspAddMembership", CommandType.StoredProcedure, parameters) > 0;
        }
        public bool XoaGoiTap(int studentId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@StudentId", studentId)
            };

            return MyExecuteNonQuery("uspDeleteMembershipByStudent", CommandType.StoredProcedure, parameters) > 0;
        }
        public Membership LayGoiTapHienTai(int studentId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@StudentId", studentId)
            };

            Connect();
            try
            {
                SqlDataReader reader = MyExecuteReader("uspGetLatestMembershipByStudent", CommandType.StoredProcedure, parameters.ToArray());
                if (reader.Read())
                {
                    return new Membership
                    {
                        MembershipId = Convert.ToInt32(reader["Membership_id"]),
                        StudentId = Convert.ToInt32(reader["Student_id"]),
                        Packagetype = reader["Package_type"].ToString(),
                        Startdate = Convert.ToDateTime(reader["Start_date"]),
                        Enddate = Convert.ToDateTime(reader["End_date"]),
                        Price = Convert.ToDecimal(reader["Price"])
                    };
                }
                return null;
            }
            finally { DisConnect(); }
        }
        public List<PackageTypeInfo> LayDanhSachGoiTap()
        {
            /*List<PackageTypeInfo> list = new List<PackageTypeInfo>();
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader("uspGetPackageTypeList", CommandType.StoredProcedure);
                while (reader.Read())
                {
                    string type = reader["Package_type"].ToString();
                    int duration = 1;
                    if (type == "Tháng") duration = 1;
                    else if (type == "Quý") duration = 3;
                    else if (type == "Năm") duration = 12;

                    list.Add(new PackageTypeInfo
                    {
                        PackageType = type,
                        DurationInMonths = duration,
                        Price = Convert.ToDecimal(reader["Price"])
                    });
                }
                return list;
            }
            finally { DisConnect(); }*/
            return new List<PackageTypeInfo>
            {
                new PackageTypeInfo
                {
                    PackageType = "Tháng",
                    DurationInMonths = 1,
                    Price = 500_000m
                },
                new PackageTypeInfo
                {
                    PackageType = "Quý",
                    DurationInMonths = 3,
                    Price = 1300_000m
                },
                new PackageTypeInfo
                {
                    PackageType = "Năm",
                    DurationInMonths = 12,
                    Price = 5_000_000m
                }
            };      
        }
    }
}
