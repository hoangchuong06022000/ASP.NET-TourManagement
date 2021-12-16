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
    // Còn Chi Tiet Tour + Gia Tour
    public class HomeController : Controller
    {
        private DAL_Tour dalTour = new DAL_Tour();
        private DAL_LoaiHinh dalLH = new DAL_LoaiHinh();
        private DAL_DiaDiem dalDD = new DAL_DiaDiem();
        private DAL_ChiTietTour dalCTTour = new DAL_ChiTietTour();
        private DAL_GiaTour dalGia = new DAL_GiaTour();
        private QLDLEntity db = new QLDLEntity();
        private Tool tool = new Tool();
        // GET: Home
        public ActionResult Index(string maTour = "")
        {           
            dynamic myModel = new ExpandoObject();
            myModel.TOURDULICH = dalTour.GetAll();
            myModel.LOAIHINHDULICH = dalLH.GetAll();
            myModel.CHITIETTOUR = dalCTTour.GetChiTiet(maTour);
            myModel.GIATOUR = dalGia.GetAll();
            return View(myModel);
        }
        [HttpGet]
        public ActionResult AddTour()
        {
            string newMaTour = nextMaTour();
            DropDownListLoaiHinh();
            TOURDULICH tour = new TOURDULICH
            {
                MATOUR = newMaTour,
                TENGOI = "",
                DACDIEM = "",
                MALOAIHINH = ""

            };
            return View(tour);
        }
        [HttpPost]
        public ActionResult AddTour(TOURDULICH tour)
        {
            if (ModelState.IsValid)
            {
                if (dalTour.Insert(tour) == true)
                {
                    return RedirectToAction("Index");
                }
            }
            DropDownListLoaiHinh();
            return View();
        }
        public string nextMaTour()
        {
            return tool.next_maTour(dalTour.GetPkey());
        }
        public void DropDownListLoaiHinh(string selectedId = null)
        {
            ViewBag.MALOAIHINH = new SelectList(dalLH.GetAll(), "MaLoaiHinh", "TenLoaiHinh", selectedId);
        }
        public ActionResult EditTour(string maTour = "")
        {
            var tour = dalTour.GetTourById(maTour);
            DropDownListLoaiHinh(tour.TENLOAITOUR);
            return View(tour);
        }
        [HttpPost]
        public ActionResult EditTour(TOURDULICH tour)
        {
            if (dalTour.Update(tour) == true)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult DeleteTour(string maTour = "")
        {
            var tour = dalTour.GetTourById(maTour);
            return View(tour);
        }
        [HttpPost]
        public ActionResult DeleteTour(TOURDULICH tour)
        {
            if (dalTour.Delete(tour) == true)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public void DropDownListCTtour(string selectedId = null)
        {
            ViewBag.MATOUR = new SelectList(dalTour.GetAll(), "MaTour", "TenGoi", selectedId);
            ViewBag.MADIADIEM = new SelectList(dalDD.GetAll(), "MaDiaDiem", "TenDiaDiem", selectedId);
        }
        [HttpGet]
        public ActionResult AddCTTour(CTTOUR ctTour)
        {
            
            DropDownListCTtour();
            var model = db.CHITIETTOURs.Where(a => a.MATOUR.Equals(ctTour.BANGGIA.MATOUR));
            return View(ctTour);
        }
        public ActionResult DiaDiem()
        {
            dynamic myModel = new ExpandoObject();
            myModel.DIADIEM = dalDD.GetAll();
            return View(myModel);
        }
        [HttpGet]
        public ActionResult AddDiaDiem()
        {
            string newMaDD = nextMaDD();
            DIADIEM dd = new DIADIEM
            {
                MADIADIEM = newMaDD,
                TENDIADIEM = ""
            };
            return View(dd);
        }
        [HttpPost]
        public ActionResult AddDiaDiem(DIADIEM dd)
        {
            if (ModelState.IsValid)
            {
                if (dalDD.Insert(dd) == true)
                {
                    return RedirectToAction("DiaDiem");
                }
            }
            return View();
        }
        public string nextMaDD()
        {
            return tool.next_maDiaDiem(dalDD.GetPkey());
        }

        public ActionResult EditDiaDiem(string maDD = "")
        {
            var dd = dalDD.GetDDById(maDD);
            return View(dd);
        }
        [HttpPost]
        public ActionResult EditDiaDiem(DIADIEM dd)
        {
            if (dalDD.Update(dd) == true)
            {
                return RedirectToAction("DiaDiem");
            }
            return View();
        }
        public ActionResult DeleteDiaDiem(string maDD = "")
        {
            var dd = dalDD.GetDDById(maDD);
            return View(dd);
        }
        [HttpPost]
        public ActionResult DeleteDiaDiem(DIADIEM dd)
        {
            if (dalDD.Delete(dd) == true)
            {
                return RedirectToAction("DiaDiem");
            }
            return View();
        }
        public ActionResult LoaiHinh()
        {
            dynamic myModel = new ExpandoObject();
            myModel.LOAIHINHDULICH = dalLH.GetAll();
            return View(myModel);
        }
        [HttpGet]
        public ActionResult AddLoaiHinh()
        {
            string newMaLH = nextMaLH();
            LOAIHINHDULICH lh = new LOAIHINHDULICH
            {
                MALOAIHINH = newMaLH,
                TENLOAIHINH = ""
            };
            return View(lh);
        }
        [HttpPost]
        public ActionResult AddLoaiHinh(LOAIHINHDULICH lh)
        {
            if (ModelState.IsValid)
            {
                if (dalLH.Insert(lh) == true)
                {
                    return RedirectToAction("LoaiHinh");
                }
            }
            return View();
        }
        public string nextMaLH()
        {
            return tool.next_maLH(dalLH.GetPkey());
        }

        public ActionResult EditLoaiHinh(string maLH = "")
        {
            var lh = dalLH.GetLHById(maLH);
            return View(lh);
        }
        [HttpPost]
        public ActionResult EditLoaiHinh(LOAIHINHDULICH lh)
        {
            if (dalLH.Update(lh) == true)
            {
                return RedirectToAction("LoaiHinh");
            }
            return View();
        }
        public ActionResult DeleteLoaiHinh(string maLH = "")
        {
            var lh = dalLH.GetLHById(maLH);
            return View(lh);
        }
        [HttpPost]
        public ActionResult DeleteLoaiHinh(LOAIHINHDULICH lh)
        {
            if (dalLH.Delete(lh) == true)
            {
                return RedirectToAction("LoaiHinh");
            }
            return View();
        }
    }
}