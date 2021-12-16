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
    // Done
    public class TouristController : Controller
    {
        private QLDLEntity db = new QLDLEntity();
        private DAL_KhachHang dalKhach = new DAL_KhachHang();
        // GET: Tourist
        public ActionResult Tourist()
        {          
            dynamic myModel = new ExpandoObject();
            myModel.KHACH = dalKhach.GetAll();
            return View(myModel);
        }
        [HttpGet]
        public ActionResult AddTourist()
        {
            string newMaKH = nextMaKH();
            KHACH khach = new KHACH
            {
                MAKH = newMaKH,
                HOTEN = "",
                CMND = "",
                DIACHI = "",
                GIOITINH = "",
                SDT = "",
                QUOCTICH = ""

            };
            return View(khach);
        }
        [HttpPost]
        public ActionResult AddTourist(KHACH khach)
        {
            if (ModelState.IsValid)
            {
                if (dalKhach.Insert(khach) == true)
                {
                    return RedirectToAction("Tourist");
                }
            }
            return View();
        }
        public string nextMaKH()
        {
            Tool tool = new Tool();
            return tool.next_maKH(dalKhach.GetPkey());
        }

        public ActionResult EditTourist(string maKH = "")
        {
            var kh = dalKhach.GetKHById(maKH);
            return View(kh);
        }
        [HttpPost]
        public ActionResult EditTourist(KHACH kh)
        {
            if (dalKhach.Update(kh) == true)
            {
                return RedirectToAction("Tourist");
            }
            return View();
        }
        public ActionResult DeleteTourist(string maKH = "")
        {
            var kh = dalKhach.GetKHById(maKH);
            return View(kh);
        }
        [HttpPost]
        public ActionResult DeleteTourist(KHACH kh)
        {
            if (dalKhach.Delete(kh) == true)
            {
                return RedirectToAction("Tourist");
            }
            return View();
        }
    }
}