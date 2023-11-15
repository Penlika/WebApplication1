namespace SachOnline.Migrations
{
    using SachOnline.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading;
    using System.IO;
    using System.Web;

    internal sealed class Configuration : DbMigrationsConfiguration<SachOnline.Models.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SachOnline.Models.Model1 context)
        {

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var lstChuDe = new List<CHUDE>();
            lstChuDe.Add(new CHUDE { MaCD = 1, TenChuDe = "Văn học" });
            lstChuDe.Add(new CHUDE { MaCD = 2, TenChuDe = "Công nghệ thông tin" });
            lstChuDe.Add(new CHUDE { MaCD = 3, TenChuDe = "Kinh tế" });
            lstChuDe.ForEach(c => context.CHUDEs.AddOrUpdate(c));
            var lstNXB = new List<NHAXUATBAN>();
            lstNXB.Add(new NHAXUATBAN { MaNXB = 1, TenNXB = "Giáo dục" });
            lstNXB.Add(new NHAXUATBAN { MaNXB = 2, TenNXB = "Khoa học tự nhiên" });
            lstNXB.ForEach(n => context.NHAXUATBANs.AddOrUpdate(n));
            base.Seed(context);

            var lstSach = new List<SACH>();
            lstSach.Add(new SACH
            {
                Tensach = "Other",
                Mota = "A Good Book",
                MaCD = 2,
                MaNXB = 3,
                Giaban = 400000,
                Anhbia = "data:image/jpeg;base64," + Utility.ConvertImageToBase64("C:\\Users\\ACER\\source\\repos\\WebApplication1\\SachOnline\\Images\\gtO1o2E.jpeg")
            });
            lstSach.Add(new SACH
            {
                Tensach = "Other",
                Mota = "A Good Book",
                MaCD = 3,
                MaNXB = 4,
                Giaban = 15000,
                Anhbia = "data:image/jpeg;base64," + Utility.ConvertImageToBase64("C:\\Users\\ACER\\source\\repos\\WebApplication1\\SachOnline\\Images\\wp10508780.jpg")
            });
            lstSach.Add(new SACH
            {
                Tensach = "Other",
                Mota = "A Good Book",
                MaCD = 4,
                MaNXB = 4,
                Giaban = 800000,
                Anhbia = "data:image/jpeg;base64," + Utility.ConvertImageToBase64("C:\\Users\\ACER\\source\\repos\\WebApplication1\\SachOnline\\Images\\wp10508780.jpg")
            });
            lstSach.Add(new SACH
            {
                Tensach = "Other",
                Mota = "A Good Book",
                MaCD = 2,
                MaNXB = 1,
                Giaban = 1000000,
                Anhbia = "data:image/jpeg;base64," + Utility.ConvertImageToBase64("C:\\Users\\ACER\\source\\repos\\WebApplication1\\SachOnline\\Images\\Mizuhara.Chizuru.full.3189263.jpg")
            });
            lstSach.Add(new SACH
            {
                Tensach = "Other",
                Mota = "A Good Book",
                MaCD = 1,
                MaNXB = 2,
                Giaban = 300000,
                Anhbia = "data:image/jpeg;base64," + Utility.ConvertImageToBase64("C:\\Users\\ACER\\source\\repos\\WebApplication1\\SachOnline\\Images\\Vladilena.Milizé.full.3345460.jpg")
            });
            lstSach.ForEach(s => context.SACHes.AddOrUpdate(s));
            base.Seed(context);

            var lstUsers = new List<USER>();
            lstUsers.Add(new USER { UserName = "admin", Password = "123", Role = "admin", Email = "vanhuudhsp@gmail.com", Avatar = Utility.ConvertImageToBase64(Path.GetFullPath("../Images/Avatar.png")) });
            lstUsers.Add(new USER { UserName = "huutv", Password = "123", Role = "cashier" });
            lstUsers.ForEach(s => context.USERs.AddOrUpdate(s));
            base.Seed(context);
        }
    }
}
