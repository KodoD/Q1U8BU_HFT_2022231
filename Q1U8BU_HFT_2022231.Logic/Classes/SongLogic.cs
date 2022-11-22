﻿using Q1U8BU_HFT_2022231.Logic.Classes;
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
        public SongLogic(IRepository<Song> repo)
        {
            this.repo = repo;
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
            var favorite = from x in Song
                           join y in Author on x.AuthorID equals y.AuthorID
                           orderby x.Likes
                           select new Favorite {
                               ID = x.SongID,  
                               Name=x.Name,
                               Likes=x.Like,
                               author=y.Name
                         }
            return favorite;//autor name
               
        }

    }
}
