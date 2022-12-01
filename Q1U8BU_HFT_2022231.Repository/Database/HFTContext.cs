using System;
using System.Data;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using Q1U8BU_HFT_2022231.Models;

namespace Q1U8BU_HFT_2022231.Repository
{
    public class HFTContext:DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Song> Song { get; set; }
        public DbSet<Author> Author { get; set; }
        public  HFTContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            if (!builder.IsConfigured)
            {

                builder.UseLazyLoadingProxies().UseInMemoryDatabase("database");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Sales>(sales => sales
                .HasOne(sales => sales.Customer)
                .WithMany(customer => customer.Sales)
                .HasForeignKey(sales => sales.CustomerID)
                .OnDelete(DeleteBehavior.SetNull));


            modelBuilder.Entity<Sales>(sales => sales
           .HasOne(sales => sales.Song)
           .WithMany(song=> song.Sales)
           .HasForeignKey(sales => sales.SongID)
           .OnDelete(DeleteBehavior.SetNull));

            modelBuilder.Entity<Song>(song => song
                 .HasOne(song => song.Author)
                 .WithMany(author => author.Songs)
                 .HasForeignKey(song => song.AuthorID)
                 .OnDelete(DeleteBehavior.SetNull));

            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                new Author("1#Tony Stark"),
                new Author("2#Pepper Potts"),
                new Author("3#Rhodey"),
                new Author("4#Obadiah Stane"),
                new Author("5#Christine Everhart"),
                new Author("6#Yinsen"),
                new Author("7#Raza"),
                new Author("8#Agent Coulson"),
                new Author("9#General Gabriel"),
                new Author("10#Abu Bakaar"),
                new Author("11#JARVIS")


            });



            modelBuilder.Entity<Customer>().HasData(new Customer[]
            {
                new Customer("1#Varga8#19"),
                new Customer("2#Kovacs#36"),
                new Customer("3#Jakab#39"),
                new Customer("4#Kiss#27"),
                new Customer("5#Ferenci#29"),
                new Customer("6#Nagy#48"),
                new Customer("7#Nemeth#31"),
                new Customer("8#Szabo#28"),
                new Customer("9#Danko#19"),
                new Customer("10#Sziklai#58"),
                new Customer("11#Szoszi#43"),
                new Customer("12#Nemecsek#23"),
                });



            modelBuilder.Entity<Song>().HasData(new Song[]
            {
                new Song("1#Aaron Schwartz#2"),
                new Song("2#Aaron Taylor-Johnson#3"),
                new Song("3#Abby Ryder Fortson#1"),
                new Song("4#Abraham Attah#5"),
                new Song("5#Adewale Akinnuoye-Agbaje#3"),
                new Song("6#Adriana Barraza#4"),
                new Song("7#Alaa Safi#5"),
                new Song("8#Alan Scott#3"),
                new Song("9#Alfred Molina#5"),
                new Song("10#Algenis Perez Soto#4"),
                new Song("11#Alice Krige#3"),
                new Song("12#Amali Golden#2"),
                new Song("13#Amy Landecker#1"),
                new Song("14#Andrew Garfield#3"),
                new Song("15#Andy Le#6#3"),
                new Song("16#Andy Serkis#7#4"),
           

            });

            modelBuilder.Entity<Sales>().HasData(new Sales[]
            {
                new Sales("1#Tony Stark#2#3#21210"),
                new Sales("2#Pepper Potts#5#2#21213"),
                new Sales("3#Rhodey#1#4#10110"),
                new Sales("4#Obadiah Stane#2#3#10000"),
                new Sales("5#Christine Everhart#10#11#10101"),
                new Sales("6#Yinsen#5#12#3148"),
                new Sales("7#Raza#9#11#21210"),
                new Sales("8#Agent Coulson#10#2#10001"),
                new Sales("9#General Gabriel#11#7#10133"),
                new Sales("10#Abu Bakaar#2#4#9499"),
                new Sales("11#JARVIS#5#5#55555"),
                

            });
     }
     }
}
