using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public  class Maintenance
    {
        public int MaintenanceId { get; set; }
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public DateTime? MaintenanceDate { get; set; }
        public string Status { get; set; }

        public DateTime PurchaseDate { get; set; }
        public DateTime? NextMaintenanceDate { get; set; }

        public DateTime? ActualMaintenanceDate { get; set; }
    }
}
