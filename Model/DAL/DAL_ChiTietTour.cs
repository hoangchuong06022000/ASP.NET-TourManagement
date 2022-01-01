using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Model;

namespace Model.DAL
{
    public class DAL_ChiTietTour
    {
        public List<CHITIETTOUR> GetChiTiet(string MaTour)
        {
            QLDLEntity db = new QLDLEntity();
            var result = from c in db.CHITIETTOURs where c.MATOUR == MaTour select c; 
            return result.ToList();
        }
        public List<CHITIETTOUR> GetCTTourBySearch(string str)
        {
            QLDLEntity db = new QLDLEntity();
            List<CHITIETTOUR> listCTTour = new List<CHITIETTOUR>();
            List<TOURDULICH> list = db.TOURDULICHes.Where(x => x.MATOUR.Contains(str) || x.TENGOI.Contains(str) || x.DACDIEM.Contains(str)).ToList();
            foreach (TOURDULICH tour in list)
            {
                List<CHITIETTOUR> listCT = new List<CHITIETTOUR>();
                listCT = db.CHITIETTOURs.Where(c => c.MATOUR.Equals(tour.MATOUR)).ToList();
                foreach (CHITIETTOUR ctTour in listCT)
                {
                    listCTTour.Add(ctTour);
                }
            }
            return listCTTour;
        }
        public CHITIETTOUR GetCTTById(string maTour, string maDD)
        {
            QLDLEntity db = new QLDLEntity();
            return db.CHITIETTOURs.Find(maTour, maDD);
        }

        public bool Insert(CHITIETTOUR ChiTietTour)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                db.CHITIETTOURs.Add(ChiTietTour);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(CHITIETTOUR ChiTietTourMoi)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                CHITIETTOUR ChiTiet = db.CHITIETTOURs.Find(ChiTietTourMoi.MATOUR, ChiTietTourMoi.MADIADIEM);
                db.CHITIETTOURs.Attach(ChiTiet);
                ChiTiet.THUTU = ChiTietTourMoi.THUTU;
                db.Entry(ChiTiet).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(CHITIETTOUR ChiTietTour)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                CHITIETTOUR ChiTiet = db.CHITIETTOURs.Find(ChiTietTour.MATOUR, ChiTietTour.MADIADIEM);
                db.CHITIETTOURs.Remove(ChiTiet);
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
