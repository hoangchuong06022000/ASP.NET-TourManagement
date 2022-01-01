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
        public List<PHANBONHANVIEN> GetPCBySearch(string str)
        {
            QLDLEntity db = new QLDLEntity();
            List<PHANBONHANVIEN> listPhanCong = new List<PHANBONHANVIEN>();
            List<NHANVIEN> listNV = db.NHANVIENs.Where(x => x.MANV.Contains(str) || x.TENNV.Contains(str)).ToList();
            foreach (NHANVIEN nv in listNV)
            {
                List<PHANBONHANVIEN> listPC = new List<PHANBONHANVIEN>();
                listPC = db.PHANBONHANVIENs.Where(c => c.MANV.Equals(nv.MANV)).ToList();
                foreach (PHANBONHANVIEN pc in listPC)
                {
                    listPhanCong.Add(pc);
                }
            }
            return listPhanCong;
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
