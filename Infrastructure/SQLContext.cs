using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Opendata.Entities;

namespace Opendata.Infrastructure
{
    public class SQLContext : DbContext
    {

        private string connectString;

        public DbSet<THSR> THSRs { get; set; }
        public DbSet<CourtVerdict> CourtVerdicts { get; set; }
        public DbSet<JUList> JLists { get; set; }
        public DbSet<JUDoc> JDocs { get; set; }
        public SQLContext(IConfiguration configuration) : base()
        {
            this.connectString = configuration.GetSection("ConnectionStrings")["DefaultConnection"];

            //this.ConnectString = connectString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                System.Diagnostics.Debug.WriteLine(this.connectString);
                optionsBuilder.UseSqlServer(this.connectString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


    }
}