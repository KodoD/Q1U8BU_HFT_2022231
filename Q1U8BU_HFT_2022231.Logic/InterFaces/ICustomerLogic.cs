using Q1U8BU_HFT_2022231.Models;
using System.Linq;

namespace Q1U8BU_HFT_2022231.Logic
{
    public interface ICustomerLogic
    {
        void Create(Customer item);
        void Delete(int id);
        double? GetAvgYear();
        Customer Read(int id);
        IQueryable<Customer> ReadAll();
        void Update(Customer item);
    }
}