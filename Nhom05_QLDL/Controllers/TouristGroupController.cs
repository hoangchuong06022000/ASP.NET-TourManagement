using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Model;
using Model.DAL;
using System.Dynamic;

namespace Nhom05_QLDL.Controllers
{
    public class TouristGroupController : Controller
    {
        private DAL_DoanDuLich dalDoan = new DAL_DoanDuLich();
        private DAL_NoiDung dalND = new DAL_NoiDung();
        private DAL_ChiTietDoan dalCTToan = new DAL_ChiTietDoan();
        private DAL_ChiPhi dalCP = new DAL_ChiPhi();
        private DAL_LoaiChiPhi dalLoaiCP = new DAL_LoaiChiPhi();
        // GET: TouristGroup
        public ActionResult TouristGroup(string maDoan = "")
        {
            
            dynamic myModel = new ExpandoObject();
            myModel.DOANDULICH = dalDoan.GetAll();
            myModel.NOIDUNG = dalND.GetAll();
            myModel.CHITIETDOAN = dalCTToan.GetAll(maDoan);
            myModel.CHIPHI = dalCP.GetAll();
            return View(myModel);
        }
        public ActionResult LoaiChiPhi()
        {
            dynamic myModel = new ExpandoObject();
            myModel.LOAICHIPHI = dalLoaiCP.GetAll();
            return View(myModel);
        }
        [HttpGet]
        public ActionResult AddLoaiCP()
        {
            string newMaLCP = nextMaLCP();
            LOAICHIPHI lcp = new LOAICHIPHI
            {
                MACHIPHI = newMaLCP,
                TENLOAICHIPHI = ""
            };
            return View(lcp);
        }
        [HttpPost]
        public ActionResult AddLoaiCP(LOAICHIPHI khach)
        {
            if (ModelState.IsValid)
            {
                if (dalLoaiCP.Insert(khach) == true)
                {
                    return RedirectToAction("LoaiChiPhi");
                }
            }
            return View();
        }
        public string nextMaLCP()
        {
            Tool tool = new Tool();
            return tool.next_maChiPhi(dalLoaiCP.GetPkey());
        }

        public ActionResult EditLoaiCP(string maLCP = "")
        {
            var lcp = dalLoaiCP.GetLoaiCPById(maLCP);
            return View(lcp);
        }
        [HttpPost]
        public ActionResult EditLoaiCP(LOAICHIPHI kh)
        {
            if (dalLoaiCP.Update(kh) == true)
            {
                return RedirectToAction("LoaiChiPhi");
            }
            return View();
        }
        public ActionResult DeleteLoaiCP(string maLCP = "")
        {
            var lcp = dalLoaiCP.GetLoaiCPById(maLCP);
            return View(lcp);
        }
        [HttpPost]
        public ActionResult DeleteLoaiCP(LOAICHIPHI lcp)
        {
            if (dalLoaiCP.Delete(lcp) == true)
            {
                return RedirectToAction("LoaiChiPhi");
            }
            return View();
        }
    }
}