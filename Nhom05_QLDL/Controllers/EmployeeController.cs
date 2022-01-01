using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.Model;
using Model.DAL;
using System.Dynamic;



namespace Nhom05_QLDL.Controllers
{
    public class EmployeeController : Controller
    {
        private QLDLEntity db = new QLDLEntity();
        private DAL_NhanVien dalNV = new DAL_NhanVien();
        private DAL_PhanBoNhanVien dalPBNV = new DAL_PhanBoNhanVien();
        // GET: Employee
        public ActionResult Search(string strSearch)
        {
            dynamic myModel = new ExpandoObject();
            if (!String.IsNullOrEmpty(strSearch))
            {
                myModel.NHANVIEN = dalNV.GetNVBySearch(strSearch);
                myModel.PHANBONHANVIEN = dalPBNV.GetPCBySearch(strSearch);
                return View(myModel);
            }
            ViewBag.StrSearch = strSearch;
            return View("SearchNull");
        }
        public ActionResult Employee()
        {
            dynamic myModel = new ExpandoObject();
            myModel.NHANVIEN = dalNV.GetAll();
            myModel.PHANBONHANVIEN = dalPBNV.GetAll();
            return View(myModel);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            string newMaNV = nextMaNV();
            NHANVIEN nv = new NHANVIEN
            {
                MANV = newMaNV,
                TENNV = ""
            };
            return View(nv);
        }
        [HttpPost]
        public ActionResult AddEmployee(NHANVIEN nv)
        {
            if (ModelState.IsValid)
            {
                if (dalNV.Insert(nv) == true)
                {
                    return RedirectToAction("Employee");
                }
            }
            return View();
        }
        public string nextMaNV()
        {
            Tool tool = new Tool();
            return tool.next_maNV(dalNV.GetPkey());
        }
        
        public ActionResult EditEmployee(string maNV = "")
        {
            var nv = dalNV.GetNVById(maNV);
            return View(nv);
        }
        [HttpPost]
        public ActionResult EditEmployee(NHANVIEN nv)
        {
            if (dalNV.Update(nv) == true)
            {
                return RedirectToAction("Employee");
            }
            return View();
        }
        public ActionResult DeleteEmployee(string maNV = "")
        {
            var nv = dalNV.GetNVById(maNV);
            return View(nv);
        }
        [HttpPost]
        public ActionResult DeleteEmployee(NHANVIEN nv)
        {
            if (dalNV.Delete(nv) == true)
            {
                return RedirectToAction("Employee");
            }
            return View();
        }
        public void DropDownList(string selectedId = null)
        {
            DAL_DoanDuLich doan = new DAL_DoanDuLich();
            ViewBag.MANV = new SelectList(dalNV.GetAll(), "MaNV", "TenNV", selectedId);
            ViewBag.MADOAN = new SelectList(doan.GetAll(), "MaDoan", "MaDoan", selectedId);
        }
        [HttpGet]
        public ActionResult AddAssignment()
        {
            DropDownList();
            return View();
        }
        [HttpPost]
        public ActionResult AddAssignment(PHANBONHANVIEN nv)
        {
            if (ModelState.IsValid)
            {
                if (dalPBNV.Insert(nv) == true)
                {
                    return RedirectToAction("Employee");
                }
            }
            DropDownList();
            return View();
        }
        public ActionResult EditAssignment(string maNV = "", string maDoan = "")
        {
            var nv = dalPBNV.GetPCById(maNV, maDoan);
            return View(nv);
        }
        [HttpPost]
        public ActionResult EditAssignment(PHANBONHANVIEN nv)
        {
            if (dalPBNV.Update(nv) == true)
            {
                return RedirectToAction("Employee");
            }
            return View();
        }
        public ActionResult DeleteAssignment(string maNV = "", string maDoan = "")
        {
            var nv = dalPBNV.GetPCById(maNV, maDoan);
            return View(nv);
        }
        [HttpPost]
        public ActionResult DeleteAssignment(PHANBONHANVIEN nv)
        {
            if (dalPBNV.Delete(nv) == true)
            {
                return RedirectToAction("Employee");
            }
            return View();
        }
    }
}