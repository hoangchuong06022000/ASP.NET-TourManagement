using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public class ThongKeNhanVien
    {
        public List<ModelThongKeNhanVien> ThongKeNV()
        {
            DAL_ThongKe TK = new DAL_ThongKe();
            return TK.ThongKeNhanVien();
        }

        public List<ModelThongKeNhanVien> ThongKeNhanVientuDen(DateTime NgayTu, DateTime NgayDen)
        {
            DAL_ThongKe TK = new DAL_ThongKe();
            return TK.ThongKeNhanVientuDen(NgayTu, NgayDen);
        }
    }
    public class ModelThongKeNhanVien
    {
        public string MANV { get; set; }
        public string TENNV { get; set; }
        public int SOLAN { get; set; }
    }
}
