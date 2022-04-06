using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Datas
{
    public class RestaurantContext:DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {
        }
        public DbSet<KhachHangModel> KhachHangs { get; set; }
        public DbSet<TiecModel> Tiecs { get; set; }
        public DbSet<BookPhongModel> BookPhongs { get; set; }
        public DbSet<PhongModel> Phongs { get; set; }
        public DbSet<SanhModel> Sanhs { get; set; }
        public DbSet<NhanVienModel> NhanViens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KhachHangModel>().ToTable("khachhang").HasKey(c=>c.maKh);
            modelBuilder.Entity<TiecModel>().ToTable("tiec").HasKey(c=>c.maTiec);
            modelBuilder.Entity<BookPhongModel>().ToTable("bookphong").HasKey(c=> new { c.maTiec,c.maPhong});
            modelBuilder.Entity<PhongModel>().ToTable("phong").HasKey(c => c.maPhong);
            modelBuilder.Entity<SanhModel>().ToTable("sanh").HasKey(c => c.maSanh);
            modelBuilder.Entity<NhanVienModel>().ToTable("NHANVIEN");
        }
        public DbSet<MVC.Models.NhanVienModel> NhanVienModel { get; set; }
    }
}
