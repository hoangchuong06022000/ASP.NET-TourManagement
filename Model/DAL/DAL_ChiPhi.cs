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
        public List<CHIPHI> GetCPBySearch(string str)
        {
            QLDLEntity db = new QLDLEntity();
            List<CHIPHI> listChiPhi = new List<CHIPHI>();
            List<TOURDULICH> list = db.TOURDULICHes.Where(x => x.MATOUR.Contains(str) || x.TENGOI.Contains(str) || x.DACDIEM.Contains(str)).ToList();
            foreach (TOURDULICH tour in list)
            {
                List<DOANDULICH> listDoan = new List<DOANDULICH>();
                listDoan = db.DOANDULICHes.Where(c => c.MATOUR.Equals(tour.MATOUR)).ToList();
                foreach (DOANDULICH doan in listDoan)
                {
                    List<CHIPHI> listCP = new List<CHIPHI>();
                    listCP = db.CHIPHIs.Where(c => c.MADOAN.Equals(doan.MADOAN)).ToList();
                    foreach (CHIPHI cp in listCP)
                    {
                        listChiPhi.Add(cp);
                    }
                }
            }
            return listChiPhi;
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
