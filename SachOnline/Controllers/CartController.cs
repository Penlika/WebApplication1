using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Dynamic;

namespace SachOnline.Controllers
{
    public class CartController : Controller
    {
        Model1 db = new Model1();
        // GET: GioHang
        public ActionResult Index()
        {
            var userLogin = (KHACHHANG)Session["Taikhoan"];
            if (userLogin == null)
            {
                return Redirect("~/Users/Login");
            }
            else
            {
                var GioHang = db.DONDATHANGs.FirstOrDefault(d => d.Ngaydat==null && d.MaKH == userLogin.MaKH);
                if (GioHang == null)
                {
                    GioHang = new DONDATHANG
                    {
                        MaKH = userLogin.MaKH,
                        Dathanhtoan = false
                    };
                    db.DONDATHANGs.Add(GioHang);
                    db.SaveChanges();
                }
                var lstCtGiohang = db.CHITIETDONTHANGs.Where(ct => ct.MaDonHang == GioHang.MaDonHang).ToList();
                var model = (from ct in lstCtGiohang
                             join s in db.SACHes
                             on ct.Masach equals s.Masach
                             select new
                             {
                                 MaDonHang= ct.MaDonHang,
                                 Masach = ct.Masach,
                                 Tensach = s.Tensach,
                                 Anhbia = s.Anhbia,
                                 Giaban = s.Giaban,
                                 Soluong = ct.Soluong,
                                 Thanhtien = ct.Soluong * s.Giaban,
                                 SoLuongTon= s.Soluongton
                             }).Select(t => t.ToExpando()).ToList();
                return View(model);
            }
        }

        public ActionResult AddToCart(int Masach)
        {
            var userLogin = (KHACHHANG)Session["Taikhoan"];
            if (userLogin == null)
            {
                return Redirect("~/Users/Login");
            }
            else
            {
                var GioHang = db.DONDATHANGs.FirstOrDefault(d => d.Ngaydat==null && d.MaKH == userLogin.MaKH);
                if (GioHang == null)
                {
                    GioHang = new DONDATHANG
                    {
                        MaKH = userLogin.MaKH,
                        Dathanhtoan = false
                    };
                    db.DONDATHANGs.Add(GioHang);
                    db.SaveChanges();
                }
                var ctDonhang = db.CHITIETDONTHANGs.FirstOrDefault(
                        ct => ct.Masach == Masach && ct.MaDonHang == GioHang.MaDonHang
                        );
                if (ctDonhang == null)
                {
                    ctDonhang = new CHITIETDONTHANG
                    {
                        Masach = Masach,
                        MaDonHang = GioHang.MaDonHang,
                        Soluong = 1
                    };
                }
                else
                {
                    ctDonhang.Soluong++;
                }
                db.CHITIETDONTHANGs.AddOrUpdate(ctDonhang);
                db.SaveChanges();
            }

            return RedirectToAction("index","SachOnline");
        }
        public ActionResult UpdateCart(int MaDonHang, int MaSach,int SoLuong)
        {
            var ct=db.CHITIETDONTHANGs.FirstOrDefault(t=>t.MaDonHang==MaDonHang && t.Masach == MaSach);
            if (SoLuong == 0)
            {
                db.CHITIETDONTHANGs.Remove(ct);
            }
            else
            {
                ct.Soluong = SoLuong;
                db.CHITIETDONTHANGs.AddOrUpdate(ct);
            }
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Delete(int MaDonHang,int MaSach)
        {
            var ct = db.CHITIETDONTHANGs.FirstOrDefault(t => t.MaDonHang == MaDonHang && t.Masach == MaSach);
            db.CHITIETDONTHANGs.Remove(ct);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpPost]
        public ActionResult DatHang(int MaDonHang,FormCollection f)
        {
            var dh=db.DONDATHANGs.FirstOrDefault(t=>t.MaDonHang==MaDonHang);
            if(dh != null)
            {
                dh.Tinhtranggiaohang = false;
                string k = f["NgayDat"];
                dh.Dathanhtoan = false;
                dh.Ngaydat = DateTime.Parse(f["NgayDat"]);
                dh.Ngaygiao = DateTime.Parse(f["NgayGiao"]);
                dh.DiaChiGH = f["DiaChiGH"];
                dh.DienThoaiGH = f["DienThoaiGH"];
                db.DONDATHANGs.AddOrUpdate(dh);
                db.SaveChanges();
                return RedirectToAction("XacNhanDatHang", "Cart");
            }
            return RedirectToAction("Index", "Cart");
        }
        public ActionResult XacNhanDatHang()
        {
            return View();
        }
    }
}