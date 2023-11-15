using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SachOnline.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<CHITIETDONTHANG> CHITIETDONTHANGs { get; set; }
        public virtual DbSet<CHUDE> CHUDEs { get; set; }
        public virtual DbSet<DONDATHANG> DONDATHANGs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<NHAXUATBAN> NHAXUATBANs { get; set; }
        public virtual DbSet<SACH> SACHes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TACGIA> TACGIAs { get; set; }
        public virtual DbSet<VIETSACH> VIETSACHes { get; set; }
        public virtual DbSet<USER> USERs { get; set; }  
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETDONTHANG>()
                .Property(e => e.Dongia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DONDATHANG>()
                .HasMany(e => e.CHITIETDONTHANGs)
                .WithRequired(e => e.DONDATHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.DienthoaiKH)
                .IsUnicode(false);

            modelBuilder.Entity<NHAXUATBAN>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.Giaban)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SACH>()
                .Property(e => e.Anhbia)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.CHITIETDONTHANGs)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.VIETSACHes)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TACGIA>()
                .Property(e => e.Dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<TACGIA>()
                .HasMany(e => e.VIETSACHes)
                .WithRequired(e => e.TACGIA)
                .WillCascadeOnDelete(false);
        }
    }
}
