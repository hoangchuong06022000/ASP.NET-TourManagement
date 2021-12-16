using Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public class DAL_ChiPhi
    {
        public List<CHIPHI> GetAll()
        {
            QLDLEntity db = new QLDLEntity();
            return db.CHIPHIs.ToList();
        }
        public CHIPHI GetCPById(string maCP, string maDoan)
        {
            QLDLEntity db = new QLDLEntity();
            return db.CHIPHIs.Find(maCP, maDoan);
        }
        public bool Insert(CHIPHI cp)
        {
            QLDLEntity db = new QLDLEntity();
            db.CHIPHIs.Add(cp);
            db.SaveChanges();
            return true;
        }

        public bool Update(CHIPHI CP)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                CHIPHI cp = db.CHIPHIs.Find(CP.MACHIPHI, CP.MADOAN);
                db.CHIPHIs.Attach(cp);
                cp.SOTIEN = CP.SOTIEN;
                db.Entry(cp).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(CHIPHI CP)
        {

            try
            {
                QLDLEntity db = new QLDLEntity();
                CHIPHI cp = db.CHIPHIs.Find(CP.MACHIPHI, CP.MADOAN);
                db.CHIPHIs.Remove(cp);
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
