using Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public class DAL_DoanDuLich
    {
        public List<DOANDULICH> GetAll()
        {
            QLDLEntity db = new QLDLEntity();
            return db.DOANDULICHes.ToList();
        }
        public double TinhDoanhThu(string maTour, string maDoan, string giaTour)
        {
            QLDLEntity db = new QLDLEntity();
            double doanhThu = 0;
            var gia = from c in db.GIATOURs where c.MAGIA == giaTour select c.THANHTIEN;
            int soKH = db.CHITIETDOANs.Where(a => a.MADOAN == maDoan).Count();
            doanhThu = soKH * gia.SingleOrDefault().Value;
            return doanhThu;
        }
        public List<DOANDULICH> GetDoanBySearch(string str)
        {
            QLDLEntity db = new QLDLEntity();
            List<DOANDULICH> listDoan = new List<DOANDULICH>();
            List<TOURDULICH> list = db.TOURDULICHes.Where(x => x.MATOUR.Contains(str) || x.TENGOI.Contains(str) || x.DACDIEM.Contains(str)).ToList();
            foreach (TOURDULICH tour in list)
            {
                List<DOANDULICH> listD = new List<DOANDULICH>();
                listD = db.DOANDULICHes.Where(c => c.MATOUR.Equals(tour.MATOUR)).ToList();
                foreach (DOANDULICH doan in listD)
                {
                    listDoan.Add(doan);
                }
            }
            return listDoan;
        }
        public DOANDULICH GetDoanById(string maDoan)
        {
            QLDLEntity db = new QLDLEntity();
            return db.DOANDULICHes.Find(maDoan);
        }

        public List<string> GetPkey()
        {
            List<string> ListPkey = new List<string>();
            QLDLEntity db = new QLDLEntity();
            foreach (DOANDULICH doan in db.DOANDULICHes.ToList())
            {
                ListPkey.Add(doan.MADOAN);
            }
            return ListPkey;
        }
        public bool Insert(DOANDULICH doan)
        {
            QLDLEntity db = new QLDLEntity();
            db.DOANDULICHes.Add(doan);
            db.SaveChanges();
            return true;
        }

        public bool Update(DOANDULICH DOAN)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                DOANDULICH doan = db.DOANDULICHes.Find(DOAN.MADOAN);
                db.DOANDULICHes.Attach(doan);
                doan.MATOUR = DOAN.MATOUR;
                doan.NGAYKHOIHANH = DOAN.NGAYKHOIHANH;
                doan.NGAYKETTHUC = DOAN.NGAYKETTHUC;
                doan.DOANHTHU = DOAN.DOANHTHU;
                doan.NOIDUNG.HANHTRINH = DOAN.NOIDUNG.HANHTRINH;
                doan.NOIDUNG.KHACHSAN = DOAN.NOIDUNG.KHACHSAN;
                db.Entry(doan).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(DOANDULICH DOAN)
        {

            try
            {
                QLDLEntity db = new QLDLEntity();
                NOIDUNG noiDung = db.NOIDUNGs.Where(p => p.MADOAN == DOAN.MADOAN).SingleOrDefault();
                db.NOIDUNGs.Remove(noiDung);
                DOANDULICH doan = db.DOANDULICHes.Where(p => p.MADOAN == DOAN.MADOAN).SingleOrDefault();
                db.DOANDULICHes.Remove(doan);
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
