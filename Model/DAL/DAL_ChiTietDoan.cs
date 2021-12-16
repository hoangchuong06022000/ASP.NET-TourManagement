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
        public List<CHITIETDOAN> GetAll(string maDoan)
        {
            QLDLEntity db = new QLDLEntity();
            var result = from c in db.CHITIETDOANs where c.MADOAN == maDoan select c;
            return result.ToList();
        }
        public CHITIETDOAN GetCTDById(string maDoan, string maKH)
        {
            QLDLEntity db = new QLDLEntity();
            return db.CHITIETDOANs.Find(maDoan, maKH);
        }

        public bool Insert(CHITIETDOAN ChiTietDoan)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                db.CHITIETDOANs.Add(ChiTietDoan);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(CHITIETDOAN ChiTietDoan)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                CHITIETDOAN ChiTiet = db.CHITIETDOANs.Find(ChiTietDoan.MADOAN, ChiTietDoan.MAKH);
                db.CHITIETDOANs.Attach(ChiTiet);
                ChiTiet.VAITROKH = ChiTietDoan.VAITROKH;
                db.Entry(ChiTiet).State = EntityState.Modified;
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
                CHITIETDOAN ChiTiet = db.CHITIETDOANs.Find(ChiTietDoan.MADOAN, ChiTietDoan.MAKH);
                db.CHITIETDOANs.Remove(ChiTiet);
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
