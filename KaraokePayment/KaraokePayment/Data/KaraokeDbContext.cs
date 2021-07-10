using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using KaraokePayment.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace KaraokePayment.Data
{
    public class KaraokeDbContext : IdentityDbContext
    {
        public KaraokeDbContext()
        {
            
        }
        public KaraokeDbContext(DbContextOptions<KaraokeDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<BookPhongOrder> BookPhongOrders { get; set; }
        public virtual DbSet<BookPhongOrderPhong> BookPhongOrderPhongs { get; set; }
        public virtual DbSet<CaLV> CaLvs { get; set; }
        public virtual DbSet<DiaChi> DiaChis{ get; set; }
        public virtual DbSet<HangHoa> HangHoas{ get; set; }
        public virtual DbSet<NhanVienCaLV> NhanVienCaLvs{ get; set; }
        public virtual DbSet<Phong> Phongs{ get; set; }
        public virtual DbSet<ThemHangHoa> ThemHangHoas{ get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed();
        }
    }
}
