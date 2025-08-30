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
    public class ThietBiBL
    {
        private ThietBiDL thietbiDL = new ThietBiDL();
        public List<Equipment> XemTatCaThietBi()
        {
            return thietbiDL.XemTatCaThietBi();
        }
        public int ThemThietBi(Equipment eq)
        {
            return thietbiDL.ThemThietBi(eq);
        }
        public List<Gym> GetActiveGyms()
        {
            return thietbiDL.GetActiveGyms();
        }
        public int CapNhatThietBi(Equipment eq)
        {
            return thietbiDL.CapNhatThietBi(eq);
        }

        public bool XoaThietBi(int id)
        {
            return thietbiDL.XoaThietBi(id);
        }
        public bool CapNhatTinhTrangThietBi(int equipmentId, string status)
        {
            return thietbiDL.CapNhatTinhTrangThietBi(equipmentId, status);
        }
        public List<Equipment> TimKiemThietBi(string tuKhoa, string kieuTim)
        {
            return thietbiDL.TimKiemThietBi(tuKhoa, kieuTim);
        }
    }
}
