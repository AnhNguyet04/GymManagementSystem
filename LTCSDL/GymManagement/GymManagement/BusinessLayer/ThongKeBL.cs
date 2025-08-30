using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class ThongKeBL
    {
        public List<StudentCountByCategory> GetStudentCountByCategory()
        {
            return new ThongKeDL().GetStudentCountByCategory();
        }
        public DataTable GetStudentCountByMonth()
        {
            return new ThongKeDL().GetStudentCountByMonth();
        }
        public DataTable GetDoanhThuTheoThang()
        {
            return new ThongKeDL().GetDoanhThuTheoThang();
        }
        public DataTable GetTiLeMembershipPackage()
        {
            ThongKeDL dl = new ThongKeDL();
            return dl.GetTiLeMembershipPackage();
        }

    }
}
