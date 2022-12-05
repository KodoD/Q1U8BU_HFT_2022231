using Q1U8BU_HFT_2022231.Models;
using Q1U8BU_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Q1U8BU_HFT_2022231.Logic
{
    public class SalesLogic : ISalesLogic
    {
        IRepository<Sales> repo;
        IRepository<Author> repo2;
        IRepository<Customer> repo3;
        IRepository<Song> repo4;

        public SalesLogic(IRepository<Sales> repo, IRepository<Author> repo2, IRepository<Customer> repo3, IRepository<Song> repo4)
        {
            this.repo = repo;
            this.repo2 = repo2;
            this.repo3 = repo3;
            this.repo4 = repo4;


        }

        public SalesLogic(IRepository<Sales> repo)
        {
            this.repo = repo;
        }

        public void Create(Sales item)
        {
            if (item.Price < 1800)
            {
                throw new ArgumentException("Too Cheap");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Cant be negati index");
            }
            this.repo.Delete(id);
        }

        public Sales Read(int id)
        {
            var movie = this.repo.Read(id);
            if (movie == null)
            {
                throw new ArgumentException("This Sales dosent exists");
            }
            return movie;
        }

        public IQueryable<Sales> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Sales item)
        {
            this.repo.Update(item);
        }
        public IEnumerable<MostWanted> MostWanted()
        {
            var wanted = from x in repo.ReadAll()
                         group x by new { x.SongID } into g
                         select new MostWanted
                         {
                             Id = g.Key.SongID,
                             Name = repo4.Read(g.Key.SongID).Name,
                             Count = repo.ReadAll().Where(x => x.SongID == g.Key.SongID).Count(),
                         };
            return wanted.ToList().OrderByDescending(x=>x.Count).Take(1);
        }
        public IEnumerable<MostWanted> LeastWanted()
        {
            var wanted = from x in repo.ReadAll()
                         group x by new { x.SongID } into g
                         select new MostWanted
                         {
                             Id = g.Key.SongID,
                             Name = repo4.Read(g.Key.SongID).Name,
                             Count = repo.ReadAll().Where(x => x.SongID == g.Key.SongID).Count(),
                         };
            return wanted.ToList().OrderBy(x => x.Count).Take(1);
        }
        public IEnumerable<RegularGuest> RegularGuests()
        {
            var valamicsoda = repo.ReadAll();
            var regular = from x in repo.ReadAll()
                          group x by new { x.CustomerID } into g
                          select new RegularGuest
                          {
                              ID = g.Key.CustomerID,
                              Name = repo3.Read(g.Key.CustomerID).Name,
                              SpentM = repo.ReadAll().Where(x => x.CustomerID == g.Key.CustomerID).Sum(x => x.Price)

                          };
            return regular.Where(x => x.SpentM>30000).ToList().OrderByDescending(x => x.SpentM);


        }

        //kik azok akik xy-t vettek 
        public IEnumerable<Customer> WhoBoughtIt(int id)
        {
            
            var regular = from x in repo.ReadAll()
                          where(id==x.SongID)
                          select new Customer
                          {
                              CustomerID= x.CustomerID,
                              Name=x.Customer.Name,
                              Age = x.Customer.Age,
                              

                          };
            return regular.ToList();

        }
        public IEnumerable<Song> WhatBought(int id) {

            //LINQ cant translate
            var songs = from x in repo.ReadAll()
                        where (id == x.CustomerID)
                        select new Song
                        {
                            SongID = x.SongID,
                            Name = x.Song.Name,
                            AuthorID = x.Song.AuthorID,

                             Like=x.Song.Like,
                             


                          };

            return songs.ToList();

        }
    }
}
