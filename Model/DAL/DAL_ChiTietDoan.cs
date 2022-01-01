using Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public class DAL_ChiTietDoan
    {
        public static string giaTour;
        public List<CHITIETDOAN> GetAll(string maDoan)
        {
            QLDLEntity db = new QLDLEntity();
            var result = from c in db.CHITIETDOANs where c.MADOAN == maDoan select c;
            return result.ToList();
        }
        public List<CHITIETDOAN> GetCTDoanBySearch(string str)
        {
            QLDLEntity db = new QLDLEntity();
            List<CHITIETDOAN> listCTDoan = new List<CHITIETDOAN>();
            List<TOURDULICH> list = db.TOURDULICHes.Where(x => x.MATOUR.Contains(str) || x.TENGOI.Contains(str) || x.DACDIEM.Contains(str)).ToList();
            foreach (TOURDULICH tour in list)
            {
                List<DOANDULICH> listDoan = new List<DOANDULICH>();
                listDoan = db.DOANDULICHes.Where(c => c.MATOUR.Equals(tour.MATOUR)).ToList();
                foreach (DOANDULICH doan in listDoan)
                {
                    List<CHITIETDOAN> listCT = new List<CHITIETDOAN>();
                    listCT = db.CHITIETDOANs.Where(c => c.MADOAN.Equals(doan.MADOAN)).ToList();
                    foreach (CHITIETDOAN ct in listCT)
                    {
                        listCTDoan.Add(ct);
                    }
                }
            }
            return listCTDoan;
        }
        public CHITIETDOAN GetCTDById(string maDoan, string maKH)
        {
            QLDLEntity db = new QLDLEntity();
            return db.CHITIETDOANs.Find(maDoan, maKH);
        }

        public bool Insert(CHITIETDOAN ChiTietDoan, string giaTour)
        {
            try
            {
                DAL_ChiTietDoan.giaTour = giaTour;
                QLDLEntity db = new QLDLEntity();
                DAL_DoanDuLich dalDoan = new DAL_DoanDuLich();
                db.CHITIETDOANs.Add(ChiTietDoan);
                db.SaveChanges();
                DOANDULICH doan = db.DOANDULICHes.Find(ChiTietDoan.MADOAN);
                db.DOANDULICHes.Attach(doan);
                doan.DOANHTHU = dalDoan.TinhDoanhThu(doan.MATOUR, doan.MADOAN, giaTour);
                db.Entry(doan).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(CHITIETDOAN ChiTietDoan, string giaTour)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                DAL_DoanDuLich dalDoan = new DAL_DoanDuLich();
                CHITIETDOAN ChiTiet = db.CHITIETDOANs.Find(ChiTietDoan.MADOAN, ChiTietDoan.MAKH);
                db.CHITIETDOANs.Attach(ChiTiet);
                ChiTiet.VAITROKH = ChiTietDoan.VAITROKH;
                db.Entry(ChiTiet).State = EntityState.Modified;
                db.SaveChanges();
                DOANDULICH doan = db.DOANDULICHes.Find(ChiTietDoan.MADOAN);
                db.DOANDULICHes.Attach(doan);
                doan.DOANHTHU = dalDoan.TinhDoanhThu(doan.MATOUR, doan.MADOAN, giaTour);
                db.Entry(doan).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(CHITIETDOAN ChiTietDoan)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                DAL_DoanDuLich dalDoan = new DAL_DoanDuLich();
                CHITIETDOAN ChiTiet = db.CHITIETDOANs.Find(ChiTietDoan.MADOAN, ChiTietDoan.MAKH);
                db.CHITIETDOANs.Remove(ChiTiet);
                db.SaveChanges();
                DOANDULICH doan = db.DOANDULICHes.Find(ChiTietDoan.MADOAN);
                db.DOANDULICHes.Attach(doan);
                doan.DOANHTHU = dalDoan.TinhDoanhThu(doan.MATOUR, doan.MADOAN, DAL_ChiTietDoan.giaTour);
                db.Entry(doan).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
