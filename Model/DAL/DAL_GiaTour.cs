using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Model;

namespace Model.DAL
{
    public class DAL_GiaTour
    {
        public List<GIATOUR> GetAll()
        {
            QLDLEntity db = new QLDLEntity();
            return db.GIATOURs.ToList();
        }
        public List<GIATOUR> GetGiaTourBySearch(string str)
        {
            QLDLEntity db = new QLDLEntity();
            List<GIATOUR> listGia = new List<GIATOUR>();
            List<TOURDULICH> list = db.TOURDULICHes.Where(x => x.MATOUR.Contains(str) || x.TENGOI.Contains(str) || x.DACDIEM.Contains(str)).ToList();
            foreach (TOURDULICH tour in list)
            {
                List<GIATOUR> listG = new List<GIATOUR>();
                listG = db.GIATOURs.Where(c => c.MATOUR.Equals(tour.MATOUR)).ToList();
                foreach (GIATOUR gia in listG)
                {
                    listGia.Add(gia);
                }
            }
            return listGia;
        }

        public List<GIATOUR> GetGiaByMaTour(string maTour)
        {
            QLDLEntity db = new QLDLEntity();
            return db.GIATOURs.Where(x => x.MATOUR == maTour).ToList();
        }
        public GIATOUR GetGiaById(string maGia)
        {
            QLDLEntity db = new QLDLEntity();
            return db.GIATOURs.Find(maGia);
        }

        public List<string> GetPkey()
        {
            List<string> ListPkey = new List<string>();
            QLDLEntity db = new QLDLEntity();
            foreach (GIATOUR gia in db.GIATOURs.ToList())
            {
                ListPkey.Add(gia.MAGIA);
            }
            return ListPkey;
        }

        public bool Insert(GIATOUR GiaTour)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                db.GIATOURs.Add(GiaTour);
                db.SaveChanges();
                return true;  
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(GIATOUR GiaTourMoi)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                GIATOUR Gia = db.GIATOURs.Find(GiaTourMoi.MAGIA);
                db.GIATOURs.Attach(Gia);
                Gia.THANHTIEN = GiaTourMoi.THANHTIEN;
                Gia.TG_BATDAU = GiaTourMoi.TG_BATDAU;
                Gia.TG_KETTHUC = GiaTourMoi.TG_KETTHUC;
                db.Entry(Gia).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public  bool Delete(GIATOUR GiaTour)
        {

            try
            {
                QLDLEntity db = new QLDLEntity();
                GIATOUR Gia= db.GIATOURs.Where(p => p.MAGIA == GiaTour.MAGIA).SingleOrDefault();
                db.GIATOURs.Remove(Gia);
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
