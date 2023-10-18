namespace SachOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gfgf : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KHACHHANG", "Taikhoan", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.KHACHHANG", "Matkhau", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AlterColumn("dbo.KHACHHANG", "Email", c => c.String(nullable: false, maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KHACHHANG", "Email", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.KHACHHANG", "Matkhau", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.KHACHHANG", "Taikhoan", c => c.String(maxLength: 50, unicode: false));
        }
    }
}
