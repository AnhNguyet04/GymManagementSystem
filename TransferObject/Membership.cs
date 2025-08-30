using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Membership
    {
        public int MembershipId { get; set; }
        public int StudentId { get; set; }
        public string Packagetype { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public decimal Price { get; set; }
    }
    public class MembershipInfo
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string PackageType { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ClassNames { get; set; }
    }
}
