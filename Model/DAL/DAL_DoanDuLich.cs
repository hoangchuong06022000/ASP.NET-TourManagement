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
