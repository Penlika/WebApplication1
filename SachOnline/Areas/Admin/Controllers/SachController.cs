using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using System.IO;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;

namespace SachOnline.Areas.Admin.Controllers
{
    public class SachController : Controller
    {
        // GET: Admin/Sach
        Model1 db = new Model1();
        public ActionResult Index(int ? page)
        {
            var lstSaches = db.SACHes.OrderBy(s => s.Masach);
            int pageNum = (page ?? 1);
            int pageSize = 7;
            return View(db.SACHes.ToList().OrderBy(n=>n.Masach).ToPagedList(pageNum,pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.MaCD = new SelectList(db.CHUDEs.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NHAXUATBANs.ToList().OrderBy(n => n.MaNXB), "MaNXB", "TenNXB");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SACH model, FormCollection f, HttpPostedFileBase fFileUpload)
        {
            if (ModelState.IsValid)
            {
                if (fFileUpload != null)
                {
                    Image img = Image.FromStream(fFileUpload.InputStream, true, true);
                    model.Anhbia = Utility.ConvertImageToBase64(img);
                }
                db.SACHes.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Detail(int id)
        {
            var hotel = db.SACHes.SingleOrDefault(n => n.Masach == id);
            if (hotel == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(hotel);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var sach = db.SACHes.SingleOrDefault(n => n.Masach == id);
            ViewBag.MaCD = new SelectList(db.CHUDEs.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChuDe",sach.MaCD);
            ViewBag.MaNXB = new SelectList(db.NHAXUATBANs.ToList().OrderBy(n => n.MaNXB), "MaNXB", "TenNXB",sach.MaNXB);
            return View(sach);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(SACH model, HttpPostedFileBase fFileUpload)
        {
            if (ModelState.IsValid)
            {
                if (fFileUpload != null)
                {
                    Image img = Image.FromStream(fFileUpload.InputStream, true, true);
                    model.Anhbia = Utility.ConvertImageToBase64(img);
                }
                db.SACHes.AddOrUpdate(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var sach = db.SACHes.FirstOrDefault(s => s.Masach == id);
            if (sach == null)
            {
                TempData["Message"] = "Sách không tồn tại";
                return RedirectToAction("Index");
            }
            var ctdh = db.CHITIETDONTHANGs.Where(ct => ct.Masach == id).ToList();
            if (ctdh.Count() > 0)
            {
                TempData["Message"] = "Sách tồn tại đơn đặt hàng không thể xóa";
                return RedirectToAction("Index");
            }
            var vietSach = db.VIETSACHes.Where(tg => tg.MaSach == id);
            if (vietSach.Count() > 0)
            {
                db.VIETSACHes.RemoveRange(vietSach);
                db.SaveChanges();
            }
            db.SACHes.Remove(sach);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}