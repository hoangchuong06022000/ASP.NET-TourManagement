using Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public class DAL_LoaiChiPhi
    {
        public List<LOAICHIPHI> GetAll()
        {
            QLDLEntity db = new QLDLEntity();
            return db.LOAICHIPHIs.ToList();
        }
        public LOAICHIPHI GetLoaiCPById(string maCP)
        {
            QLDLEntity db = new QLDLEntity();
            return db.LOAICHIPHIs.Find(maCP);
        }

        public List<string> GetPkey()
        {
            List<string> ListPkey = new List<string>();
            QLDLEntity db = new QLDLEntity();
            foreach (LOAICHIPHI lcp in db.LOAICHIPHIs.ToList())
            {
                ListPkey.Add(lcp.MACHIPHI);
            }
            return ListPkey;
        }
        public bool Insert(LOAICHIPHI lcp)
        {
            QLDLEntity db = new QLDLEntity();
            db.LOAICHIPHIs.Add(lcp);
            db.SaveChanges();
            return true;
        }

        public bool Update(LOAICHIPHI LCP)
        {
            try
            {
                QLDLEntity db = new QLDLEntity();
                LOAICHIPHI cp = db.LOAICHIPHIs.Find(LCP.MACHIPHI);
                db.LOAICHIPHIs.Attach(cp);
                cp.TENLOAICHIPHI = LCP.TENLOAICHIPHI;
                db.Entry(cp).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(LOAICHIPHI LCP)
        {

            try
            {
                QLDLEntity db = new QLDLEntity();
                LOAICHIPHI cp = db.LOAICHIPHIs.Where(p => p.MACHIPHI == LCP.MACHIPHI).SingleOrDefault();
                db.LOAICHIPHIs.Remove(cp);
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
