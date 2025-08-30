using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class Students_ClassBL
    {
        Students_ClassDL dl = new Students_ClassDL();
        public int DangKyLop(int userId, int classId)
        {
            if (dl.KiemTraTrung(userId, classId))
                throw new Exception("Lớp bị trùng lịch với lớp đã đăng ký.");
            if (dl.AvailableSlots(classId) <= 0)
                throw new Exception("Lớp đã đầy.");
            return dl.DangKyLop(userId, classId);
        }
        public bool HuyDangKy(int studentId, int classId)
        {
            if (!dl.HuyDangKy(studentId, classId))
                throw new Exception("Không thể hủy học viên khỏi lớp.");
            return true;
        }
        public int AvailableSlots(int classId)
        {
            return dl.AvailableSlots(classId);
        }
        public List<Classes> GetClassesByStudent(int studentID)
        {
            return dl.GetClassesByStudent(studentID);
        }
        public List<Student_Classes> GetClassesByStudentId(int studentID)
        {
            return dl.GetClassesByStudentId(studentID);
        }
    }
}
