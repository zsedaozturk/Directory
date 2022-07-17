using Directory.ReportService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Directory.ReportService.DataAccess.RSContext
{
    public class ReportServiceContext : DbContext
    {
        public DbSet<Report> Reports { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=TDReportServiceDb;Integrated Security=true; User Id=postgres;Password=1780;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>().ToTable("Report", "public");
        }
    }
}
