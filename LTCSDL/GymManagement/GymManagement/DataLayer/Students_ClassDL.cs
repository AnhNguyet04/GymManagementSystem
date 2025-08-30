using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class Students_ClassDL: DataProvider
    {
        public int DangKyLop(int studentId, int classId)
        {
            Connect();
            try
            {
                string sqlCheck = "SELECT Status FROM Student_Classes WHERE Student_id = @studentId AND Class_id = @classId";
                using (SqlCommand cmd = new SqlCommand(sqlCheck, cn))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    cmd.Parameters.AddWithValue("@classId", classId);
                    object result = cmd.ExecuteScalar();
                    if (result !=null)
                    {
                        string status = result.ToString();
                        if (status == "Đang hoạt động")
                        {
                            return -1;
                        }    
                        else if (status == "Đã bị hủy")
                        {
                            string sqlUpdate = "UPDATE Student_Classes SET Status = N'Đang hoạt động', Registered = GETDATE() WHERE Student_id = @studentId AND Class_id = @classId";
                            using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, cn))
                            {
                                cmdUpdate.Parameters.AddWithValue("@studentId", studentId);
                                cmdUpdate.Parameters.AddWithValue("@classId", classId);
                                return cmdUpdate.ExecuteNonQuery() > 0 ? 2 : 0;
                            }    
                        }    
                    }
                    string sqlInsert = "INSERT INTO Student_Classes (Student_id, Class_id, Registered, Status) VALUES (@studentId, @classId, GETDATE(), N'Đang hoạt động')";
                    using (SqlCommand cmdInsert = new SqlCommand(sqlInsert, cn))
                    {
                        cmdInsert.Parameters.AddWithValue("@studentId", studentId);
                        cmdInsert.Parameters.AddWithValue("@classId", classId);
                        return cmdInsert.ExecuteNonQuery() > 0 ? 1 : 0;
                    }
                }    
            }
            catch
            {
                return 0;
            }
            finally
            {
                DisConnect();
            }
        }
        public bool HuyDangKy(int studentId, int classId)
        {
            string sql = "UPDATE Student_Classes SET Status = N'Đã bị hủy' WHERE Student_id = @studentId AND Class_id = @classId";
            Connect();
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    cmd.Parameters.AddWithValue("@classId", classId);
                    return cmd.ExecuteNonQuery() > 0;
                }    
            }
            finally
            {
                DisConnect();
            }
        }
        public bool KiemTraTrung(int studentId, int classId)
        {
            string sql = "SELECT COUNT (*) FROM Student_Classes sc " +
                "JOIN Classes c1 on sc.Class_id = c1.Class_id " +
                "JOIN Classes c2 on c2.Class_id = @classId " +
                "WHERE sc.Student_id = @studentId AND c1.Schedule =c2.Schedule AND sc.Status = N'Đang hoạt động' ";
            Connect();
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql,cn))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    cmd.Parameters.AddWithValue("@classId", classId);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }    
            }
            finally
            {
                DisConnect();
            }
        }
        public int AvailableSlots(int classId)
        {
            string sql = "SELECT (c.Max_Student - COUNT(sc.Student_id)) AS AvailableSlots " +
                "FROM Classes c " +
                "LEFT JOIN Student_Classes sc ON c.Class_id = sc.Class_id AND sc.Status = N'Đang hoạt động' " +
                "WHERE c.Class_id = @classId " +
                "GROUP BY c.Max_Student ";
            Connect();
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql,cn))
                {
                    cmd.Parameters.AddWithValue("@classId", classId);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }    
            }
            finally
            {
                DisConnect();
            }
        }
        public List<Classes> GetClassesByStudent(int studentID)
        {
            List<Classes> classes = new List<Classes>();
            string sql = "SELECT c.*, sc.Status FROM Student_Classes sc JOIN Classes c ON sc.Class_id = c.Class_id AND sc.Status = N'Đang hoạt động' WHERE sc.Student_id = @StudentId";
            Connect();
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Classes cls = new Classes
                            {
                                ClassID = Convert.ToInt32(reader["Class_id"]),
                                ClassName = reader["Class_name"].ToString(),
                                Category = Convert.ToInt32(reader["Category"]),
                                TrainerID = Convert.ToInt32(reader["Trainer_id"]),
                                Schedule = reader["Schedule"].ToString(),
                                MaxStudent = Convert.ToInt32(reader["Max_Student"]),
                                Price = Convert.ToDecimal(reader["Price"]),
                                StartDate = Convert.ToDateTime(reader["Start_date"]),
                                EndDate = Convert.ToDateTime(reader["End_date"]),
                                Description = reader["Description"].ToString()
                            };
                            classes.Add(cls);
                        }
                    }
                }
            }
            finally
            {
                DisConnect();
            }
            return classes;
        }

        public List<Student_Classes> GetClassesByStudentId(int studentID)
        {
            List<Student_Classes> list = new List<Student_Classes>();
            string sql = "SELECT * FROM Student_Classes WHERE Student_id = @StudentId AND Status = N'Đang hoạt động'";

            Connect();
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student_Classes sc = new Student_Classes
                            {
                                StudentId = Convert.ToInt32(reader["Student_id"]),
                                ClassId = Convert.ToInt32(reader["Class_id"]),
                                Status = reader["Status"].ToString(),
                                RegisteredDate = Convert.ToDateTime(reader["Registered"])
                            };
                            list.Add(sc);
                        }
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
