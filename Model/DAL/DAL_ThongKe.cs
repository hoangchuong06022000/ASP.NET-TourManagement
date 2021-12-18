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
        private QLDLEntity db = new QLDLEntity();
        public int SoTour()
        {
            return db.TOURDULICHes.Count();
        }

        public int SoDoan()
        {
            return db.DOANDULICHes.Count();
        }

        public int SoKhachHang()
        {
            return db.KHACHes.Count();
        }

        public int SoKhachTheoDoan(string maDoan)
        {
            CHITIETDOAN ctDoan = (CHITIETDOAN)db.CHITIETDOANs.Where(a => a.MADOAN == maDoan);
            return db.KHACHes.Where(a => a.MAKH == ctDoan.MAKH).Count();
        }

        public int SoLanDiTourNV(string maNV)
        {
            NHANVIEN nv = (NHANVIEN)db.NHANVIENs.Where(a => a.MANV == maNV);
            return db.PHANBONHANVIENs.Where(a => a.MANV == nv.MANV).Count();
        }

        public double DoanhThuMoiDoan(string maDoan)
        {
            DOANDULICH doan = (DOANDULICH)db.DOANDULICHes.Where(a => a.MADOAN == maDoan);
            return doan.DOANHTHU;
        }

        public double ChiPhiMoiDoan(string maDoan)
        {
            CHIPHI chiPhi = (CHIPHI)db.CHIPHIs.Where(a => a.MADOAN == maDoan);
            return chiPhi.SOTIEN.GetValueOrDefault();
        }
    }
}
