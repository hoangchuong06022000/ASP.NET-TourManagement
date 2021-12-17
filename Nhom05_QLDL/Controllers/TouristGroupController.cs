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
    //Done
    public class TouristGroupController : Controller
    {
        private DAL_DoanDuLich dalDoan = new DAL_DoanDuLich();
        private DAL_Tour dalTour = new DAL_Tour();
        private DAL_KhachHang dalKH = new DAL_KhachHang();
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
        public void DropDownListDoan(string selectedId = null)
        {
            ViewBag.MATOUR = new SelectList(dalTour.GetAll(), "MaTour", "TenGoi", selectedId);
        }
        [HttpGet]
        public ActionResult AddTouristGroup()
        {
            string newMaDoan = nextMaDoan();
            DOANDULICH doan = new DOANDULICH
            {
                MADOAN = newMaDoan,
                MATOUR = "",
                NGAYKHOIHANH = null,
                NGAYKETTHUC = null,
                DOANHTHU = 0
            };
            DropDownListDoan();
            return View(doan);
        }
        [HttpPost]
        public ActionResult AddTouristGroup(DOANDULICH doan)
        {
            if (ModelState.IsValid)
            {
                if (dalDoan.Insert(doan) == true)
                {
                    return RedirectToAction("TouristGroup");
                }
            }
            DropDownListDoan();
            return View();
        }
        public string nextMaDoan()
        {
            Tool tool = new Tool();
            return tool.next_maDoan(dalDoan.GetPkey());
        }

        public ActionResult EditTouristGroup(string maDoan = "")
        {
            DropDownListDoan();
            var doan = dalDoan.GetDoanById(maDoan);
            return View(doan);
        }
        [HttpPost]
        public ActionResult EditTouristGroup(DOANDULICH doan)
        {
            if (dalDoan.Update(doan) == true)
            {
                return RedirectToAction("TouristGroup");
            }
            DropDownListDoan();
            return View();
        }
        public ActionResult DeleteTouristGroup(string maDoan = "")
        {
            var doan = dalDoan.GetDoanById(maDoan);
            return View(doan);
        }
        [HttpPost]
        public ActionResult DeleteTouristGroup(DOANDULICH doan)
        {
            if (dalDoan.Delete(doan) == true)
            {
                return RedirectToAction("TouristGroup");
            }
            return View();
        }
        public void DropDownListCTDoan(string selectedId = null)
        {
            ViewBag.MADOAN = new SelectList(dalDoan.GetAll(), "MaDoan", "MaDoan", selectedId);
            ViewBag.MAKH = new SelectList(dalKH.GetAll(), "MAKH", "HoTen", selectedId);
        }
        [HttpGet]
        public ActionResult AddCTTouristGroup()
        {
            DropDownListCTDoan();
            return View();
        }
        [HttpPost]
        public ActionResult AddCTTouristGroup(CHITIETDOAN ctDoan)
        {
            if (ModelState.IsValid)
            {
                if (dalCTToan.Insert(ctDoan) == true)
                {
                    return RedirectToAction("TouristGroup");
                }
            }
            DropDownListCTDoan();
            return View();
        }

        public ActionResult EditCTTouristGroup(string maDoan = "", string maKH = "")
        {
            var ctDoan = dalCTToan.GetCTDById(maDoan, maKH);
            return View(ctDoan);
        }
        [HttpPost]
        public ActionResult EditCTTouristGroup(CHITIETDOAN ctDoan)
        {
            if (dalCTToan.Update(ctDoan) == true)
            {
                return RedirectToAction("TouristGroup");
            }
            return View();
        }
        public ActionResult DeleteCTTouristGroup(string maDoan = "", string maKH = "")
        {
            var ctDoan = dalCTToan.GetCTDById(maDoan, maKH);
            return View(ctDoan);
        }
        [HttpPost]
        public ActionResult DeleteCTTouristGroup(CHITIETDOAN ctDoan)
        {
            if (dalCTToan.Delete(ctDoan) == true)
            {
                return RedirectToAction("TouristGroup");
            }
            return View();
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
        public void DropDownListChiPhi(string selectedId = null)
        {
            ViewBag.MACHIPHI = new SelectList(dalCP.GetAll(), "MAChiPhi", "TenLoaiChiPhi", selectedId);
            ViewBag.MADOAN = new SelectList(dalDoan.GetAll(), "MaDoan", "MaDoan", selectedId);
        }
        public ActionResult AddChiPhi()
        {
            DropDownListChiPhi();
            return View();
        }
        [HttpPost]
        public ActionResult AddChiPhi(CHIPHI chiPhi)
        {
            if (ModelState.IsValid)
            {
                if (dalCP.Insert(chiPhi) == true)
                {
                    return RedirectToAction("TouristGroup");
                }
            }
            DropDownListChiPhi();
            return View();
        }
     
        public ActionResult EditChiPhi(string maCP = "", string maDoan = "")
        {
            var chiPhi = dalCP.GetCPById(maCP, maDoan);
            return View(chiPhi);
        }
        [HttpPost]
        public ActionResult EditChiPhi(CHIPHI chiPhi)
        {
            if (dalCP.Update(chiPhi) == true)
            {
                return RedirectToAction("TouristGroup");
            }
            return View();
        }
        public ActionResult DeleteChiPhi(string maCP = "", string maDoan = "")
        {
            var chiPhi = dalCP.GetCPById(maCP, maDoan);
            return View(chiPhi);
        }
        [HttpPost]
        public ActionResult DeleteChiPhi(CHIPHI chiPhi)
        {
            if (dalCP.Delete(chiPhi) == true)
            {
                return RedirectToAction("TouristGroup");
            }
            return View();
        }
        public void DropDownListNoiDung(string selectedId = null)
        {
            ViewBag.MADOAN = new SelectList(dalDoan.GetAll(), "MaDoan", "MaDoan", selectedId);
        }
        public ActionResult AddNoiDung()
        {
            DropDownListNoiDung();
            return View();
        }
        [HttpPost]
        public ActionResult AddNoiDung(NOIDUNG nd)
        {
            if (ModelState.IsValid)
            {
                if (dalND.Insert(nd) == true)
                {
                    return RedirectToAction("TouristGroup");
                }
            }
            DropDownListNoiDung();
            return View();
        }

        public ActionResult EditNoiDung(string maDoan = "")
        {
            var nd = dalND.GetNDById(maDoan);
            return View(nd);
        }
        [HttpPost]
        public ActionResult EditNoiDung(NOIDUNG nd)
        {
            if (dalND.Update(nd) == true)
            {
                return RedirectToAction("TouristGroup");
            }
            return View();
        }
        public ActionResult DeleteNoiDung(string maDoan = "")
        {
            var nd = dalND.GetNDById(maDoan);
            return View(nd);
        }
        [HttpPost]
        public ActionResult DeleteNoiDung(NOIDUNG nd)
        {
            if (dalND.Delete(nd) == true)
            {
                return RedirectToAction("TouristGroup");
            }
            return View();
        }
    }
}