using Q1U8BU_HFT_2022231.Models;
using System.Collections.Generic;
using System.Linq;

namespace Q1U8BU_HFT_2022231.Logic
{
    public interface ISalesLogic
    {
        void Create(Sales item);
        void Delete(int id);
        Sales Read(int id);
        IQueryable<Sales> ReadAll();
        void Update(Sales item);
        IEnumerable<MostWanted> MostWanted();
        IEnumerable<MostWanted> LeastWanted();
        IEnumerable<RegularGuest> RegularGuests();
    }
}