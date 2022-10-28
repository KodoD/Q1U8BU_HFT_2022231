using Q1U8BU_HFT_2022231.Models;
using Q1U8BU_HFT_2022231.Repository;
using System;
using System.Linq;

namespace Q1U8BU_HFT_2022231.Logic
{
    public class CustomerLogic : ICustomerLogic
    {
        IRepository<Customer> repo;
        public CustomerLogic(IRepository<Customer> repo)
        {
            this.repo = repo;
        }

        public void Create(Customer item)
        {
            if (item.Age < 18)
            {
                throw new ArgumentException("Too young");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Cant be negatiindexv");
            }
            this.repo.Delete(id);
        }

        public Customer Read(int id)
        {
            var movie = this.repo.Read(id);
            if (movie == null)
            {
                throw new ArgumentException("This Customer dosent exists");
            }
            return movie;
        }

        public IQueryable<Customer> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Customer item)
        {
            this.repo.Update(item);
        }


        public double? GetAvgYear() { return this.repo.ReadAll().Average(t => t.Age); }
    }
}
