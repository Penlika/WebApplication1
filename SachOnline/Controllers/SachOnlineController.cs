using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace SachOnline.Controllers
{
    public class SachOnlineController : Controller
    {
        Model1 db = new Model1();
        // GET: SachOnline
        public ActionResult Index(int?page)
        {
            var lstSach = db.SACHes.OrderBy(s=>s.Masach);
            int pageNumber = (page) ?? 1;
            int pageSize = 3;
            ViewBag.TieuDe = "SÁCH MỚI";
            return View(lstSach.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult ChuDePartial()
        {
            var lstCHUDE = db.CHUDEs;
            return PartialView(lstCHUDE);
        }
        public ActionResult NavPartial()
        {
            var dropChuDe =new object[] { db.CHUDEs,db.NHAXUATBANs};
            return PartialView(dropChuDe);
        }
        public ActionResult SachBanPartial()
        {
            var Sach = db.SACHes;
            return PartialView(Sach);
        }
        public ActionResult NXBPartial()
        {
            var NXB = db.NHAXUATBANs;
            return PartialView(NXB);
        }
        public ActionResult SachTheoChuDe(int MaCD)
        {
            var lstSach = db.SACHes.Where(s => s.MaCD == MaCD);
            return View(lstSach);
        }
        public ActionResult ChiTietSach(int MaSach)
        {
            var sach=db.SACHes.FirstOrDefault( s=>s.Masach ==MaSach);
            return View(sach);
        }
    }
}