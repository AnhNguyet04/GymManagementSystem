using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using DataLayer.Helpers;

namespace DataLayer
{
    public class TrainerDL: DataProvider
    {
        public List<Trainer> GetAllTrainers()
        {
            List<Trainer> trainers = new List<Trainer>();
            string trainersql = "SELECT User_id, Full_name, Phone, Email FROM Users WHERE Role = N'Huấn luyện viên'";
            Connect();
            try
            {
                using (SqlDataReader reader = MyExecuteReader(trainersql, CommandType.Text))
                {
                    while (reader.Read())
                    {
                        Trainer trainer = new Trainer
                        {
                            TrainerID = Convert.ToInt32(reader["User_id"]),
                            FullName = reader["Full_name"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Email = reader["Email"].ToString()
                        };
                        trainers.Add(trainer);
                    }
                }
                string classsql = "SELECT Trainer_id, Class_name FROM Classes";
                using (SqlDataReader reader = MyExecuteReader(classsql, CommandType.Text))
                {
                    while (reader.Read())
                    {
                        int trainerId = Convert.ToInt32(reader["Trainer_id"]);
                        string className = reader["Class_name"].ToString();

                        //Gán lớp vào trainer tương ứng
                        Trainer trainer = trainers.FirstOrDefault(t => t.TrainerID == trainerId);
                        if (trainer != null)
                        {
                            trainer.Classes.Add(className);
                        }
                    }
                }
            }
            finally
            {
                DisConnect();
            }
            foreach (var trainer in trainers)
            {
                if (trainer.Classes.Count == 0)
                {
                    trainer.Classes.Add("Chưa có lớp nào");
                }    
            }
            return trainers;
        }
        public List<Trainer> GetAvailableTrainers(DateTime newStartDate, DateTime newEndDate, string newSchedule)
        {
            List<Trainer> availableTrainers = new List<Trainer>();
            List<Trainer> allTrainers = GetAllTrainers();
            List<Classes> allClasses = new ClassesDL().GetAllClasses();

            var newScheduleSlots = ScheduleHelper.ParseSchedule(newSchedule);
            foreach (var trainer in allTrainers)
            {
                var trainerClasses = allClasses
                    .Where(c => c.TrainerID == trainer.TrainerID &&
                                newStartDate <= c.EndDate && newEndDate >= c.StartDate)
                    .ToList();

                bool conflict = false;

                foreach (var cls in trainerClasses)
                {
                    var existingScheduleSlots = ScheduleHelper.ParseSchedule(cls.Schedule);
                    if (ScheduleHelper.IsScheduleOverlap(newScheduleSlots, existingScheduleSlots))
                    {
                        conflict = true;
                        break;
                    }
                }

                if (!conflict)
                {
                    availableTrainers.Add(trainer);
                }
            }

            return availableTrainers;
        }
        public Trainer GetTrainerById(int id)
        {
            Trainer trainer = null;
            string sql = "SELECT User_id, Full_name, Phone, Email FROM Users WHERE Role = N'Huấn luyện viên' AND User_id = @id";
            Connect();
            try
            {
                using (SqlDataReader reader = MyExecuteReader(sql, CommandType.Text, new SqlParameter[] { new SqlParameter("@id", id) }))

                {
                    if (reader.Read())
                    {
                        trainer = new Trainer
                        {
                            TrainerID = Convert.ToInt32(reader["User_id"]),
                            FullName = reader["Full_name"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Email = reader["Email"].ToString(),
                            Classes = new List<string>()
                        };
                    }
                }

                if (trainer != null)
                {
                    string classSql = "SELECT Class_name FROM Classes WHERE Trainer_id = @id";
                    using (SqlDataReader reader = MyExecuteReader(classSql, CommandType.Text, new SqlParameter[] { new SqlParameter("@id", id) }))
                    {
                        while (reader.Read())
                        {
                            trainer.Classes.Add(reader["Class_name"].ToString());
                        }
                    }

                    if (trainer.Classes.Count == 0)
                        trainer.Classes.Add("Chưa có lớp nào");
                }
            }
            finally
            {
                DisConnect();
            }
            return trainer;
        }
        public Trainer GetTrainerByName(string name)
        {
            Trainer trainer = null;
            string sql = "SELECT User_id, Full_name, Phone, Email FROM Users WHERE Role = N'Huấn luyện viên' AND Full_name = @name";
            Connect();
            try
            {
                using (SqlDataReader reader = MyExecuteReader(sql, CommandType.Text, new SqlParameter[] { new SqlParameter("@name", name) }))
                {
                    if (reader.Read())
                    {
                        trainer = new Trainer
                        {
                            TrainerID = Convert.ToInt32(reader["User_id"]),
                            FullName = reader["Full_name"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Email = reader["Email"].ToString(),
                            Classes = new List<string>()
                        };
                    }
                }

                if (trainer != null)
                {
                    string classSql = "SELECT Class_name FROM Classes WHERE Trainer_id = @id";
                    using (SqlDataReader reader = MyExecuteReader(classSql, CommandType.Text, new SqlParameter[] { new SqlParameter("@id", trainer.TrainerID) }))
                    {
                        while (reader.Read())
                        {
                            trainer.Classes.Add(reader["Class_name"].ToString());
                        }
                    }

                    if (trainer.Classes.Count == 0)
                        trainer.Classes.Add("Chưa có lớp nào");
                }
            }
            finally
            {
                DisConnect();
            }
            return trainer;
        }


    }
}
