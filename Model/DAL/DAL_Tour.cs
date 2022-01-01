using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Model.Model;

namespace Model.DAL
{
    public class DAL_Tour
    {
        public List<TOURDULICH> GetAll()
        {
            QLDLEntity db = new QLDLEntity();
            return db.TOURDULICHes.ToList();
        }
        public List<TOURDULICH> GetTourBySearch(string str)
        {
            QLDLEntity db = new QLDLEntity();
            return db.TOURDULICHes.Where(x => x.MATOUR.Contains(str) || x.TENGOI.Contains(str) || x.DACDIEM.Contains(str)).ToList();
        }
        public TOURDULICH GetTourById(string maTour)
        {
            QLDLEntity db = new QLDLEntity();           
            return db.TOURDULICHes.Find(maTour);
        }

        public List<string> GetPkey()
        {
            List<string> ListPkey = new List<string>();
            QLDLEntity db = new QLDLEntity();
            foreach(TOURDULICH tour in db.TOURDULICHes.ToList())
            {
                ListPkey.Add(tour.MATOUR);
            }
            return ListPkey;
        }

        public bool Insert(TOURDULICH Tour)
        {
                QLDLEntity db = new QLDLEntity();
                db.TOURDULICHes.Add(Tour);
                db.SaveChanges();
                return true;
        }

        public bool Update(TOURDULICH Tour)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                TOURDULICH tour = db.TOURDULICHes.Find(Tour.MATOUR);
                db.TOURDULICHes.Attach(tour);
                tour.MALOAIHINH = Tour.MALOAIHINH;
                tour.TENGOI = Tour.TENGOI;
                tour.DACDIEM = Tour.DACDIEM;
                db.Entry(tour).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(TOURDULICH Tour)
        {
            
            try
            {
                QLDLEntity db = new QLDLEntity();
                TOURDULICH tour = db.TOURDULICHes.Where(p => p.MATOUR == Tour.MATOUR).SingleOrDefault();
                db.TOURDULICHes.Remove(tour);
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
