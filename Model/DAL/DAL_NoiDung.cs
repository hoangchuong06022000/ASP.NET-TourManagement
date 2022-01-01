using Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public class DAL_NoiDung
    {
        public List<NOIDUNG> GetAll()
        {
            QLDLEntity db = new QLDLEntity();
            return db.NOIDUNGs.ToList();
        }
        public List<NOIDUNG> GetNDBySearch(string str)
        {
            QLDLEntity db = new QLDLEntity();
            List<NOIDUNG> listNoiDung = new List<NOIDUNG>();
            List<TOURDULICH> list = db.TOURDULICHes.Where(x => x.MATOUR.Contains(str) || x.TENGOI.Contains(str) || x.DACDIEM.Contains(str)).ToList();
            foreach (TOURDULICH tour in list)
            {
                List<DOANDULICH> listDoan = new List<DOANDULICH>();
                listDoan = db.DOANDULICHes.Where(c => c.MATOUR.Equals(tour.MATOUR)).ToList();
                foreach (DOANDULICH doan in listDoan)
                {
                    List<NOIDUNG> listND = new List<NOIDUNG>();
                    listND = db.NOIDUNGs.Where(c => c.MADOAN.Equals(doan.MADOAN)).ToList();
                    foreach (NOIDUNG nd in listND)
                    {
                        listNoiDung.Add(nd);
                    }
                }
            }
            return listNoiDung;
        }
        public NOIDUNG GetNDById(string maDoan)
        {
            QLDLEntity db = new QLDLEntity();
            return db.NOIDUNGs.Find(maDoan);
        }

        public List<string> GetPkey()
        {
            List<string> ListPkey = new List<string>();
            QLDLEntity db = new QLDLEntity();
            foreach (NOIDUNG nd in db.NOIDUNGs.ToList())
            {
                ListPkey.Add(nd.MADOAN);
            }
            return ListPkey;
        }
        public bool Insert(NOIDUNG nd)
        {
            QLDLEntity db = new QLDLEntity();
            db.NOIDUNGs.Add(nd);
            db.SaveChanges();
            return true;
        }

        public bool Update(NOIDUNG NV)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                NOIDUNG nv = db.NOIDUNGs.Find(NV.MADOAN);
                db.NOIDUNGs.Attach(nv);
                nv.HANHTRINH = NV.HANHTRINH;
                nv.KHACHSAN = NV.KHACHSAN;
                db.Entry(nv).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(NOIDUNG NV)
        {

            try
            {
                QLDLEntity db = new QLDLEntity();
                NOIDUNG nd = db.NOIDUNGs.Where(p => p.MADOAN == NV.MADOAN).SingleOrDefault();
                db.NOIDUNGs.Remove(nd);
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
