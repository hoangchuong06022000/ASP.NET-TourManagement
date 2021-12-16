using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Model;

namespace Model.DAL
{
    public class DAL_LoaiHinh
    {
        public List<LOAIHINHDULICH> GetAll()
        {
            QLDLEntity db = new QLDLEntity();
            return db.LOAIHINHDULICHes.ToList();
        }
        public LOAIHINHDULICH GetLHById(string maLH)
        {
            QLDLEntity db = new QLDLEntity();
            return db.LOAIHINHDULICHes.Find(maLH);
        }

        public List<string> GetPkey()
        {
            List<string> ListPkey = new List<string>();
            QLDLEntity db = new QLDLEntity();
            foreach (LOAIHINHDULICH lh in db.LOAIHINHDULICHes.ToList())
            {
                ListPkey.Add(lh.MALOAIHINH);
            }
            return ListPkey;
        }
        public bool Insert(LOAIHINHDULICH LoaiHinh)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                db.LOAIHINHDULICHes.Add(LoaiHinh);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(LOAIHINHDULICH LoaiHinh)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                LOAIHINHDULICH lh = db.LOAIHINHDULICHes.Find(LoaiHinh.MALOAIHINH);
                db.LOAIHINHDULICHes.Attach(lh);
                lh.TENLOAIHINH = LoaiHinh.TENLOAIHINH;
                db.Entry(lh).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Delete(LOAIHINHDULICH LoaiHinh)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                LOAIHINHDULICH lh = db.LOAIHINHDULICHes.Find(LoaiHinh.MALOAIHINH);
                db.LOAIHINHDULICHes.Attach(lh);
                db.LOAIHINHDULICHes.Remove(lh);
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
