using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using DataLayer;

namespace BusinessLayer
{
    public class StudentsBL
    {
        public List<Students> GetStudentsByClassId(int classId)
        {
            return new StudentsDL().GetStudentsByClassId(classId);
        }
        public List<Students> GetAllStudents()
        {
            return new StudentsDL().GetAllStudents();
        }
    }
}
