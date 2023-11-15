using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SachOnline.Areas.Admin.Controllers
{
    public class SachController : Controller
    {
        // GET: Admin/Sach
        Model1 db = new Model1();
        public ActionResult Index()
        {
            var lstSachh=db.CHUDEs.ToList();
            return View();
        }
    }
}