using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using ZavenDotNetInterview.App.Models;

namespace ZavenDotNetInterview.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Log> Logs { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog = Zaven; Integrated Security = true");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Log>(entity =>
            {
                entity.HasKey(i => i.Id);
                entity.Property(i => i.Id).ValueGeneratedOnAdd();
                
            });
            builder.Entity<Job>(entity =>
            {
                entity.HasKey(i => i.Id);
                entity.Property(i => i.Id).ValueGeneratedOnAdd();
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(i => i.Name).IsRequired();
                entity.HasMany(i => i.Logs).WithOne(i => i.Job).HasForeignKey(i => i.JobId);
            });
            
        }
    }
}
