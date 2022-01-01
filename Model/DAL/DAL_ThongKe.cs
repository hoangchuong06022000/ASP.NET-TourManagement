using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Model;
using Model.DAL;

namespace Model.DAL
{
    public class DAL_ThongKe
    {
       
        public List<ModelThongKeNhanVien> ThongKeNhanVien()
        {
            using (var ctx = new QLDLEntity())
            {
                var query = ctx.Database
                    .SqlQuery<ModelThongKeNhanVien>("SELECT PB.MANV, TENNV, COUNT(MADOAN) AS 'SOLAN' FROM NHANVIEN NV, PHANBONHANVIEN PB WHERE PB.MANV = NV.MANV GROUP BY PB.MANV, TENNV").ToList();

                return query;
            }
        }

        public List<ModelThongKeNhanVien> ThongKeNhanVientuDen(DateTime NgayTu, DateTime NgayDen)
        {
            using (var ctx = new QLDLEntity())
            {
                var query = ctx.Database
                    .SqlQuery<ModelThongKeNhanVien>("SELECT PB.MANV, TENNV, COUNT(PB.MADOAN) AS 'SOLAN' FROM NHANVIEN NV, PHANBONHANVIEN PB, DOANDULICH DOAN " +
                    " WHERE PB.MANV = NV.MANV AND DOAN.MADOAN = PB.MADOAN AND NGAYKHOIHANH >= '" + NgayTu.Year + "-" + NgayTu.Month + "-" + NgayTu.Day +
                    "' AND NGAYKETTHUC <= '" + NgayDen.Year + "-" + NgayDen.Month + "-" + NgayDen.Day +
                    "' GROUP BY PB.MANV, TENNV").ToList();

                return query;
            }
        }

        public List<ModelThongKeTour> ThongKeTour()
        {
            using (var ctx = new QLDLEntity())
            {
                var query = ctx.Database
                    .SqlQuery<ModelThongKeTour>("SELECT MATOUR, SUM(DOANHTHU) 'TONGTHU', COUNT(DOAN.MADOAN) AS 'SODOAN' FROM DOANDULICH DOAN GROUP BY MATOUR").ToList();

                return query;
            }
        }
    }
}
