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
    public class StatiticController : Controller
    {
        private DAL_ThongKe thongKe = new DAL_ThongKe();
        private DAL_DoanDuLich dalDoan = new DAL_DoanDuLich();
        private ThongKeNhanVien tkNV = new ThongKeNhanVien();
        private ThongKeTour tkTour = new ThongKeTour();
        // GET: Statitic
        public ActionResult Statitic()
        {
            return View();
        }
        public ActionResult ViewStatitic(DateTime ngayTu, DateTime ngayDen)
        {
            if((ngayTu != null) && (ngayDen != null))
            {
                dynamic myModel = new ExpandoObject();
                myModel.NHANVIEN = tkNV.ThongKeNhanVientuDen(ngayTu, ngayDen);
                myModel.TOUR = tkTour.ThongKeTourDL();
                return View(myModel);
            }
            return RedirectToAction("Statitic");
        }

    }
}