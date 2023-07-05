using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCOURSE.Model.Entities
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<HocVien> HocVien { get; set; }
        public virtual DbSet<KhoaHoc> KhoaHoc { get; set; }
        public virtual DbSet<NgayHoc> NgayHoc { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server = THUOCLE\\THUOCLE; Database = QuanLyCOURSE; Trusted_Connection = True; " +
                $"TrustServerCertificate=True");
        }
    }
}
