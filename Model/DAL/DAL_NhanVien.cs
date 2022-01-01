using Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public class DAL_NhanVien
    {
        public List<NHANVIEN> GetAll()
        {
            QLDLEntity db = new QLDLEntity();
            return db.NHANVIENs.ToList();
        }
        public List<NHANVIEN> GetNVBySearch(string str)
        {
            QLDLEntity db = new QLDLEntity();
            return db.NHANVIENs.Where(x => x.MANV.Contains(str) || x.TENNV.Contains(str)).ToList();
        }
        public NHANVIEN GetNVById(string maNV)
        {
            QLDLEntity db = new QLDLEntity();
            return db.NHANVIENs.Find(maNV);
        }

        public List<string> GetPkey()
        {
            List<string> ListPkey = new List<string>();
            QLDLEntity db = new QLDLEntity();
            foreach (NHANVIEN nv in db.NHANVIENs.ToList())
            {
                ListPkey.Add(nv.MANV);
            }
            return ListPkey;
        }
        public bool Insert(NHANVIEN nv)
        {
            QLDLEntity db = new QLDLEntity();
            db.NHANVIENs.Add(nv);
            db.SaveChanges();
            return true;
        }

        public bool Update(NHANVIEN NV)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                NHANVIEN nv = db.NHANVIENs.Find(NV.MANV);
                db.NHANVIENs.Attach(nv);
                nv.TENNV = NV.TENNV;
                db.Entry(nv).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(NHANVIEN NV)
        {

            try
            {
                QLDLEntity db = new QLDLEntity();
                NHANVIEN nv = db.NHANVIENs.Where(p => p.MANV == NV.MANV).SingleOrDefault();
                db.NHANVIENs.Remove(nv);
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
