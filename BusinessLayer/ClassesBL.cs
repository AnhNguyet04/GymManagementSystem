using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class ClassesBL
    {
        public List<Classes> GetAllClasses()
        {
            return new ClassesDL().GetAllClasses();
        }
        public List<Classes> GetClassesByTrainer(int trainerId)
        {
            return new ClassesDL().GetClassesByTrainer(trainerId);
        }
        public Classes GetClassById(int classId)
        {
            return new ClassesDL().GetClassById(classId);
        }
        public int AddClass(Classes classes)
        {
            try
            {
                return new ClassesDL().AddClass(classes);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public int UpdateClass(Classes classes)
        {
            try
            {
                return new ClassesDL().UpdateClass(classes);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public int DeleteClass(Classes classes)
        {
            try
            {
                return new ClassesDL().DeleteClass(classes);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
