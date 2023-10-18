using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ChuDeController : Controller
    {
        // GET: ChuDe
        QLBANSACHEntities1 db = new QLBANSACHEntities1();
        public ActionResult Index()
        {
            var chude = db.CHUDEs;
            return View(chude);
        }
    }
}