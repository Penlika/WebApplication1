using PagedList;
using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

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
            ViewBag.MaCD = new SelectList(db.CHUDEs.ToList().OrderBy(c => c.MaCD), "MaCD", "TenChuDe");
            ViewBag.MaNXB= new SelectList(db.NHAXUATBANs.ToList().OrderBy(n => n.MaNXB), "MaNXB", "TenNXB");
            return View();
        }
        [HttpPost]
        public ActionResult Create(SACH model)
        {
            ViewBag.MaCD = new SelectList(db.CHUDEs.ToList().OrderBy(c => c.MaCD), "MaCD", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NHAXUATBANs.ToList().OrderBy(n => n.MaNXB), "MaNXB", "TenNXB");
            if(ModelState.IsValid)
            {
                model.Mota = ViewBag.MoTa;
                db.SACHes.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        //public ActionResult Detail(int id)
        //{

        //}
        //public ActionResult Edit(int id)
        //{

        //}
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