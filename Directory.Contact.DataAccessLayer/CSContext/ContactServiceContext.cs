using Directory.ContactService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Directory.ContactService.DataAccess.CSContext
{
    
    public class ContactServiceContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=TDUserServiceDb;Integrated Security=true; User Id=postgres;Password=1780;");
        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User", "public");
            modelBuilder.Entity<Contact>().ToTable("Contact", "public");
        }
       
    }
    
}
