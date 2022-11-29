using Q1U8BU_HFT_2022231.Models;
using Q1U8BU_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1U8BU_HFT_2022231.Logic
{
    public class SongLogic : ISongLogic
    {
        IRepository<Song> repo;
        IRepository<Author> repo2;//IOC KONTENER,fACTORY PATTERN

        public SongLogic(IRepository<Song> repo,IRepository<Author> repo2)
        {
            this.repo = repo;
            this.repo2 = repo2;
        }

        public SongLogic(IRepository<Song> repo)
        {
            this.repo=repo;
        }

        public void Create(Song item)
        {
            if (item.Like < 0 || item.Like > 5)
            {
                throw new ArgumentException("The points need to be between 1-5");
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

        public Song Read(int id)
        {
            var movie = this.repo.Read(id);
            if (movie == null)
            {
                throw new ArgumentException("This Song dosent exists");
            }
            return movie;
        }

        public IQueryable<Song> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Song item)
        {
            this.repo.Update(item);
        }
        public IEnumerable<Favorite> Favoriterank()
        {
            var favorite = from x in repo.ReadAll()
                           orderby x.Like descending
                           group x by new { x.SongID, x.AuthorID, x.Name, x.Like } into g
                           select new Favorite
                           {
                               ID = g.Key.SongID,
                               Name = g.Key.Name,
                               Likes = g.Key.Like,
                               author = repo2.Read((g.Key.AuthorID)).Name,
                           };

            return favorite.Take(1);//autor name


        }
        public IEnumerable<Favorite> leastFavoriterank()
        {
            var favorite = from x in repo.ReadAll()
                           orderby x.Like ascending
                           group x by new { x.SongID, x.AuthorID, x.Name, x.Like } into g
                           select new Favorite
                           {
                               ID = g.Key.SongID,
                               Name = g.Key.Name,
                               Likes = g.Key.Like,
                               author = repo2.Read((g.Key.AuthorID)).Name,
                           };

            return favorite.Take(1);//autor name

        }

    }
}
