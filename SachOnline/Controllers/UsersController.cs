using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SachOnline.Controllers
{
    public class UsersController : Controller
    {
        Model1 db=new Model1();

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(KHACHHANG Model)
        {
            if(ModelState.IsValid)
            {
                var tk=db.KHACHHANGs.FirstOrDefault(k=>k.Taikhoan==Model.Taikhoan);
                if(tk!=null)
                {
                    ModelState.AddModelError("Taikhoan","Tài khoản không tồn tại");
                    return View(Model);
                }
                db.KHACHHANGs.Add(Model);
                db.SaveChanges();
                return View();
            }
            return View(Model);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                var u = db.KHACHHANGs.FirstOrDefault(k => k.Taikhoan == user.UserName && k.Matkhau == user.Password);
                if (u != null)
                {
                    Session["Taikhoan"] = u;
                }
                else
                {
                    ModelState.AddModelError("Password", "Tài khoản không tồn tại hoặc sai mật khẩu");
                }
            }
            return RedirectToAction("index","SachOnline");
        }
        public ActionResult Logout()
        {
            Session["Taikhoan"] = null;
            return Redirect("~/");
        }
    }
}