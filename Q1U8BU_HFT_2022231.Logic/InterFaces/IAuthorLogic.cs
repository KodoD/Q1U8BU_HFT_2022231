using Q1U8BU_HFT_2022231.Models;
using System.Linq;

namespace Q1U8BU_HFT_2022231.Logic
{
    public interface IAuthorLogic
    {
        void Create(Author item);
        void Delete(int id);
        Author Read(int id);
        IQueryable<Author> ReadAll();
        void Update(Author item);
    }
}