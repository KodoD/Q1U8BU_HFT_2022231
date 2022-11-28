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

        public SalesLogic(IRepository<Sales> repo, IRepository<Author> repo2, IRepository<Customer> repo3)
        {
            this.repo = repo;
            this.repo2 = repo2;
            this.repo3 = repo3;
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
                           orderby Count(x.Song) descending
                           group x by new {x.SongID, x.AuthorID, x.Name, x.Like } into g
                           select new Stat
                           {
                               ID = g.Key.SongID,
                               Name = g.Key.Name,
                               Likes = g.Key.Like,
                               author = repo2.Read((g.Key.AuthorID)).Name,
                           };
            return wanted;
        }
        public IEnumerable<MostWanted> LeastWanted()
        {
            var wanted = from x in repo.ReadAll()
                         orderby x ascending
                         group x by new { x.SongID, x.AuthorID, x.Name, x.Like } into g
                         select new Stat
                         {
                             ID = g.Key.Author,
                             Name = g.Key.Name,
                             Likes = g.Key.Like,
                             author = repo2.Read((g.Key.AuthorID)).Name,
                         };
            return wanted;
        }
        public IEnumerable<RegularGuest> RegularGuests()
        {
            var regular = from x in repo.ReadAll()
                         orderby x descending
                         group x by new { x.CustomerID ,x.Customer } into g
                         select new Stat
                         {
                             ID = g.Key.CustomerID,
                             Name = g.Key.,
                             Likes = g.Key.Like,
                             author = repo3.Read((g.Key.CustomerID)).Name,
                         };
            return regular;
        }
    }
}
