using Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public class DAL_PhanBoNhanVien
    {
        public List<PHANBONHANVIEN> GetAll()
        {
            QLDLEntity db = new QLDLEntity();
            return db.PHANBONHANVIENs.ToList();
        }
        public PHANBONHANVIEN GetPCById(string maNV, string maDoan)
        {
            QLDLEntity db = new QLDLEntity();
            return db.PHANBONHANVIENs.Find(maNV, maDoan);
        }
        public bool Insert(PHANBONHANVIEN nv)
        {
            QLDLEntity db = new QLDLEntity();
            db.PHANBONHANVIENs.Add(nv);
            db.SaveChanges();
            return true;
        }

        public bool Update(PHANBONHANVIEN NV)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                PHANBONHANVIEN nv = db.PHANBONHANVIENs.Find(NV.MANV, NV.MADOAN);
                db.PHANBONHANVIENs.Attach(nv);
                nv.NHIEMVU = NV.NHIEMVU;
                db.Entry(nv).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(PHANBONHANVIEN NV)
        {

            try
            {
                QLDLEntity db = new QLDLEntity();
                PHANBONHANVIEN nv = db.PHANBONHANVIENs.Find(NV.MANV, NV.MADOAN);
                db.PHANBONHANVIENs.Remove(nv);
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
