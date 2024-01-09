using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjecTrail.Models;

namespace ProjecTrail
{
    public class AppDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        
        public AppDbContext()
        {
            SQLitePCL.Batteries_V2.Init();

            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionDb = $"Filename ={PathDb.GetPath("ProjecTrail.db")}";
            optionsBuilder.UseSqlite(connectionDb);
        }
    }
}
