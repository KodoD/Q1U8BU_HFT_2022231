using Q1U8BU_HFT_2022231.Logic.Classes;
using Q1U8BU_HFT_2022231.Models;
using Q1U8BU_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1U8BU_HFT_2022231.Logic
{
    public class SalesLogic : ISalesLogic
    {
        IRepository<Sales> repo;
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
        
    }
}
