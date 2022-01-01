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
    public class DAL_KhachHang
    {
        public List<KHACH> GetAll()
        {
            QLDLEntity db = new QLDLEntity();
            return db.KHACHes.ToList();
        }
        public List<KHACH> GetKHBySearch(string str)
        {
            QLDLEntity db = new QLDLEntity();
            return db.KHACHes.Where(x => x.MAKH.Contains(str) || x.HOTEN.Contains(str) || x.CMND.Contains(str) || x.DIACHI.Contains(str) || x.SDT.Contains(str) || x.GIOITINH.Contains(str) || x.QUOCTICH.Contains(str)).ToList();
        }
        public KHACH GetKHById(string maKH)
        {
            QLDLEntity db = new QLDLEntity();
            return db.KHACHes.Find(maKH);
        }

        public List<string> GetPkey()
        {
            List<string> ListPkey = new List<string>();
            QLDLEntity db = new QLDLEntity();
            foreach (KHACH kh in db.KHACHes.ToList())
            {
                ListPkey.Add(kh.MAKH);
            }
            return ListPkey;
        }

        public bool Insert(KHACH Khach)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                db.KHACHes.Add(Khach);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(KHACH KhachMoi)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                KHACH Khach = db.KHACHes.Find(KhachMoi.MAKH);
                db.KHACHes.Attach(Khach);
                Khach.HOTEN = KhachMoi.HOTEN;
                Khach.CMND = KhachMoi.CMND;
                Khach.DIACHI = KhachMoi.DIACHI;
                Khach.GIOITINH = KhachMoi.GIOITINH;
                Khach.SDT = KhachMoi.SDT;
                Khach.QUOCTICH = KhachMoi.QUOCTICH;
                db.Entry(Khach).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(KHACH Khach)
        {
            
            try
            {
                QLDLEntity db = new QLDLEntity();
                KHACH KH = db.KHACHes.Where(p => p.MAKH == Khach.MAKH).SingleOrDefault();
                db.KHACHes.Remove(KH);
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
