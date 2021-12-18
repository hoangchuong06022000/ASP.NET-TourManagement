using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Model;
using Model.DAL;

namespace Nhom05_QLDL.Controllers
{
    public class StatiticController : Controller
    {
        private DAL_ThongKe thongKe = new DAL_ThongKe();
        // GET: Statitic
        public ActionResult Statitic()
        {
            ViewBag.SoTour = thongKe.SoTour();
            ViewBag.SoDoan = thongKe.SoDoan();
            ViewBag.SoKhachHang = thongKe.SoKhachHang();
            ViewBag.SoKhachTheoDoan = thongKe.SoKhachTheoDoan(null);
            return View();
        }
    }
}