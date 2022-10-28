using System;
using Microsoft.EntityFrameworkCore;
using Q1U8BU_HFT_2022231.Models;

namespace Q1U8BU_HFT_2022231.Repository
{
    public class HFTContext:DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Song> Song { get; set; }
        public  HFTContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            if (!builder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Diak.mdf;Integrated Security=True;MultipleActiveResultSets=true";

                builder.UseLazyLoadingProxies().UseSqlServer(conn);
            }
        }
    }
}
