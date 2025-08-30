using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Classes
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public int Category {  get; set; }
        public int TrainerID { get; set; }
        public string Schedule {  get; set; }
        public int MaxStudent {  get; set; }
        public int AvailableSlots { get; set; }
        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}
