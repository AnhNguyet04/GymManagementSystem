using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Students
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public DateTime? DOB { get; set; }
        public string Gender { get; set; }  
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime RegisteredDate { get; set; }
    }
    public class Student_Classes
    {
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public string Status { get; set; }
        public DateTime RegisteredDate { get; set; }
    }

    public class StudentCountByCategory
    {
        public string CategoryName { get; set; }
        public int StudentCount { get; set; }
    }
}
