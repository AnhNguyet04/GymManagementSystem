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
    public class StudentsDL: DataProvider
    {
        public List<Students> GetStudentsByClassId(int classId)
        {
            List<Students> students = new List<Students>();
            string sql = "SELECT s.* FROM Students s JOIN Student_Classes sc ON s.Student_id = sc.Student_id WHERE sc.Class_id = @classId AND sc.Status = N'Đang hoạt động'";
            Connect();
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql,cn))
                {
                    cmd.Parameters.AddWithValue("@classId", classId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Students student = new Students
                            {
                                StudentId = Convert.ToInt32(reader["Student_id"]),
                                FullName = reader["Full_name"].ToString(),
                                DOB = Convert.ToDateTime(reader["DOB"]),
                                Gender = reader["Gender"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Email = reader["Email"].ToString(),
                                Address = reader["Address"].ToString(),
                                RegisteredDate = Convert.ToDateTime(reader["RegisteredDate"])
                            };
                            students.Add(student);
                        }    
                    }    
                }    
            }
            finally
            {
                DisConnect();
            }
            return students;
        }

        public List<Students> GetAllStudents()
        {
            List<Students> students = new List<Students>();
            string sql = "SELECT * FROM Students";
            Connect();
            try
            {
                using (SqlDataReader reader = MyExecuteReader(sql, CommandType.Text))
                {
                    while (reader.Read())
                    {
                        Students student = new Students
                        {
                            StudentId = Convert.ToInt32(reader["Student_id"]),
                            FullName = reader["Full_name"].ToString(),
                            DOB = Convert.ToDateTime(reader["DOB"]),
                            Gender = reader["Gender"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Email = reader["Email"].ToString(),
                            Address = reader["Address"].ToString(),
                            RegisteredDate = Convert.ToDateTime(reader["RegisteredDate"])
                        };
                        students.Add(student);
                    }
                }
            }
            finally
            {
                DisConnect();
            }
            return students;
        }
    }
}
