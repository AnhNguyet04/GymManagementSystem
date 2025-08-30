using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class BaoTriBL
    {
        private BaoTriDL baotriDL = new BaoTriDL();

        public List<Maintenance> LayBaoTriTongHop(int dinhKyBaoTriNgay)
        {
            var dt = baotriDL.LayDanhSachBaoTriTongHop(dinhKyBaoTriNgay);
            return dt;
        }
        public List<Maintenance> LayLichSuBaoTriTheoThietBi(int equipmentId)
        {
            return baotriDL.LayLichSuBaoTriTheoThietBi(equipmentId);
        }
        public bool ThemBaoTriMoi(int equipmentId, DateTime date, string status)
        {
            return baotriDL.ThemBaoTri(equipmentId, date, status);
        }

        public bool HoanTatBaoTri(int maintenanceId)
        {
            return baotriDL.HoanTatBaoTri(maintenanceId);
        }
        public bool KiemTraTrungLichBaoTri(int equipmentId, DateTime date)
        {
            return baotriDL.KiemTraTrungLichBaoTri(equipmentId, date);
        }
        public bool XoaBaoTri(int maintenanceId)
        {
            return baotriDL.XoaBaoTri(maintenanceId);
        }
        public bool CapNhatTinhTrangThietBi(int equipmentId, string newStatus)
        {
            return baotriDL.CapNhatTinhTrangThietBi(equipmentId, newStatus);
        }
    }
}
