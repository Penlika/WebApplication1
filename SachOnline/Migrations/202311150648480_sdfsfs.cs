namespace SachOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdfsfs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CHITIETDONTHANG",
                c => new
                    {
                        MaDonHang = c.Int(nullable: false),
                        Masach = c.Int(nullable: false),
                        Soluong = c.Int(),
                        Dongia = c.Decimal(precision: 18, scale: 0),
                    })
                .PrimaryKey(t => new { t.MaDonHang, t.Masach })
                .ForeignKey("dbo.DONDATHANG", t => t.MaDonHang)
                .ForeignKey("dbo.SACH", t => t.Masach)
                .Index(t => t.MaDonHang)
                .Index(t => t.Masach);
            
            CreateTable(
                "dbo.DONDATHANG",
                c => new
                    {
                        MaDonHang = c.Int(nullable: false, identity: true),
                        Dathanhtoan = c.Boolean(),
                        Tinhtranggiaohang = c.Boolean(),
                        Ngaydat = c.DateTime(),
                        Ngaygiao = c.DateTime(),
                        MaKH = c.Int(),
                        DiaChiGH = c.String(),
                        DienThoaiGH = c.String(),
                    })
                .PrimaryKey(t => t.MaDonHang)
                .ForeignKey("dbo.KHACHHANG", t => t.MaKH)
                .Index(t => t.MaKH);
            
            CreateTable(
                "dbo.KHACHHANG",
                c => new
                    {
                        MaKH = c.Int(nullable: false, identity: true),
                        HoTen = c.String(nullable: false, maxLength: 50),
                        Taikhoan = c.String(nullable: false, maxLength: 50, unicode: false),
                        Matkhau = c.String(nullable: false, maxLength: 250, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        DiachiKH = c.String(maxLength: 200),
                        DienthoaiKH = c.String(maxLength: 50, unicode: false),
                        Ngaysinh = c.DateTime(),
                    })
                .PrimaryKey(t => t.MaKH);
            
            CreateTable(
                "dbo.SACH",
                c => new
                    {
                        Masach = c.Int(nullable: false, identity: true),
                        Tensach = c.String(nullable: false, maxLength: 100),
                        Giaban = c.Decimal(precision: 18, scale: 0),
                        Mota = c.String(),
                        Anhbia = c.String(unicode: false),
                        Ngaycapnhat = c.DateTime(),
                        Soluongton = c.Int(),
                        MaCD = c.Int(),
                        MaNXB = c.Int(),
                    })
                .PrimaryKey(t => t.Masach)
                .ForeignKey("dbo.CHUDE", t => t.MaCD)
                .ForeignKey("dbo.NHAXUATBAN", t => t.MaNXB)
                .Index(t => t.MaCD)
                .Index(t => t.MaNXB);
            
            CreateTable(
                "dbo.CHUDE",
                c => new
                    {
                        MaCD = c.Int(nullable: false, identity: true),
                        TenChuDe = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.MaCD);
            
            CreateTable(
                "dbo.NHAXUATBAN",
                c => new
                    {
                        MaNXB = c.Int(nullable: false, identity: true),
                        TenNXB = c.String(nullable: false, maxLength: 50),
                        Diachi = c.String(maxLength: 200),
                        DienThoai = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.MaNXB);
            
            CreateTable(
                "dbo.VIETSACH",
                c => new
                    {
                        MaTG = c.Int(nullable: false),
                        MaSach = c.Int(nullable: false),
                        Vaitro = c.String(maxLength: 50),
                        Vitri = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => new { t.MaTG, t.MaSach })
                .ForeignKey("dbo.TACGIA", t => t.MaTG)
                .ForeignKey("dbo.SACH", t => t.MaSach)
                .Index(t => t.MaTG)
                .Index(t => t.MaSach);
            
            CreateTable(
                "dbo.TACGIA",
                c => new
                    {
                        MaTG = c.Int(nullable: false, identity: true),
                        TenTG = c.String(nullable: false, maxLength: 50),
                        Diachi = c.String(maxLength: 100),
                        Tieusu = c.String(),
                        Dienthoai = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.MaTG);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.USER",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        Avatar = c.String(),
                        Email = c.String(),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VIETSACH", "MaSach", "dbo.SACH");
            DropForeignKey("dbo.VIETSACH", "MaTG", "dbo.TACGIA");
            DropForeignKey("dbo.SACH", "MaNXB", "dbo.NHAXUATBAN");
            DropForeignKey("dbo.SACH", "MaCD", "dbo.CHUDE");
            DropForeignKey("dbo.CHITIETDONTHANG", "Masach", "dbo.SACH");
            DropForeignKey("dbo.DONDATHANG", "MaKH", "dbo.KHACHHANG");
            DropForeignKey("dbo.CHITIETDONTHANG", "MaDonHang", "dbo.DONDATHANG");
            DropIndex("dbo.VIETSACH", new[] { "MaSach" });
            DropIndex("dbo.VIETSACH", new[] { "MaTG" });
            DropIndex("dbo.SACH", new[] { "MaNXB" });
            DropIndex("dbo.SACH", new[] { "MaCD" });
            DropIndex("dbo.DONDATHANG", new[] { "MaKH" });
            DropIndex("dbo.CHITIETDONTHANG", new[] { "Masach" });
            DropIndex("dbo.CHITIETDONTHANG", new[] { "MaDonHang" });
            DropTable("dbo.USER");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.TACGIA");
            DropTable("dbo.VIETSACH");
            DropTable("dbo.NHAXUATBAN");
            DropTable("dbo.CHUDE");
            DropTable("dbo.SACH");
            DropTable("dbo.KHACHHANG");
            DropTable("dbo.DONDATHANG");
            DropTable("dbo.CHITIETDONTHANG");
        }
    }
}
