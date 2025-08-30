using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Equipment
    {
        public int EquipmentId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Status { get; set; }
        public int GymId { get; set; }
        public string GymName { get; set; }
    }
}
