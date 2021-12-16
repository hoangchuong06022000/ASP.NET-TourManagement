using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Model;

namespace Model.DAL
{
    public class DAL_DiaDiem
    {
        public List<DIADIEM> GetAll()
        {
            QLDLEntity db = new QLDLEntity();
            return db.DIADIEMs.ToList();
        }
        public DIADIEM GetDDById(string maDD)
        {
            QLDLEntity db = new QLDLEntity();
            return db.DIADIEMs.Find(maDD);
        }
        public List<string> GetPkey()
        {
            List<string> ListPkey = new List<string>();
            QLDLEntity db = new QLDLEntity();
            foreach (DIADIEM dd in db.DIADIEMs.ToList())
            {
                ListPkey.Add(dd.MADIADIEM);
            }
            return ListPkey;
        }
        public bool Insert(DIADIEM DiaDiem)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                db.DIADIEMs.Add(DiaDiem);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(DIADIEM DiaDiem)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                DIADIEM dd = db.DIADIEMs.Find(DiaDiem.MADIADIEM);
                db.DIADIEMs.Attach(dd);
                dd.TENDIADIEM = DiaDiem.TENDIADIEM;
                db.Entry(dd).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(DIADIEM DiaDiem)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                DIADIEM dd = db.DIADIEMs.Where(p => p.MADIADIEM == DiaDiem.MADIADIEM).SingleOrDefault();
                db.DIADIEMs.Remove(dd);
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
