using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q1U8BU_HFT_2022231.Models;

namespace Q1U8BU_HFT_2022231.Repository
{
    public interface IRepository<T> where T : class
    {
        T Read(int id);
        IQueryable<T> ReadAll();
        void Create(T item);
        void Update(T item);
        void Delete(int id);

    }
}
