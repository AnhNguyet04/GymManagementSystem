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
    public class ClassesDL: DataProvider
    {
        Students_ClassDL studentClassDL = new Students_ClassDL();
        public List<Classes> GetAllClasses()
        {
            List<Classes> classes = new List<Classes>();
            string sql = "SELECT * FROM Classes";

            Connect();
            try
            {
                using (SqlDataReader reader = MyExecuteReader(sql,CommandType.Text))
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
                        cls.AvailableSlots = studentClassDL.AvailableSlots(cls.ClassID);
                        classes.Add(cls);
                    }
                }    
            }
            finally
            {
                DisConnect();
            }
            return classes;
        }

        public List<Classes> GetClassesByTrainer(int trainerID)
        {
            List<Classes> classes = new List<Classes>();
            string sql = "SELECT * FROM Classes WHERE Trainer_id = @TrainerID";
            Connect();
            try
            {
                using (SqlCommand cmd = new SqlCommand (sql,cn))
                {
                    cmd.Parameters.AddWithValue("@TrainerID", trainerID);
                    using (SqlDataReader reader=cmd.ExecuteReader())
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
                            Students_ClassDL studentClassDL = new Students_ClassDL();
                            classes.Add(cls);
                        }
                    }
                }    
            }
            finally
            {
                DisConnect();
            }
            return classes ;
        }

        public Classes GetClassById(int classId)
        {
            Classes cls = null;
            string sql = "SELECT * FROM Classes WHERE Class_id = @ClassId";

            Connect();
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@ClassId", classId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cls = new Classes
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
                        }
                    }
                }
            }
            finally
            {
                DisConnect();
            }

            return cls;
        }

        private int ExecuteClassProc(string producedure, Classes classes)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            // Nếu là update, thêm class_id trước
            if (producedure.Equals("uspUpdateClass", StringComparison.OrdinalIgnoreCase))
            {
                parameters.Add(new SqlParameter("@class_id", classes.ClassID));
            }
            parameters.Add(new SqlParameter("@class_name", classes.ClassName));
            parameters.Add(new SqlParameter("@category", classes.Category));
            parameters.Add(new SqlParameter("@trainer_id", classes.TrainerID));
            parameters.Add(new SqlParameter("@schedule", classes.Schedule));
            parameters.Add(new SqlParameter("@max_student", classes.MaxStudent));
            parameters.Add(new SqlParameter("@price", classes.Price));
            parameters.Add(new SqlParameter("@startdate", classes.StartDate));
            parameters.Add(new SqlParameter("@enddate", classes.EndDate));
            parameters.Add(new SqlParameter("@mota", classes.Description));
            try
            {
                return (MyExecuteNonQuery(producedure, CommandType.StoredProcedure, parameters));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public int AddClass(Classes classes)
        {
            return ExecuteClassProc("uspAddClass", classes);
        }

        public int UpdateClass(Classes classes)
        {
            return ExecuteClassProc("uspUpdateClass", classes);
        }
        public int DeleteClass(Classes classes)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@class_id", classes.ClassID),
            };
            try
            {
                return MyExecuteNonQuery("uspDeleteClass", CommandType.StoredProcedure, parameters);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
