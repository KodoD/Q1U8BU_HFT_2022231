using Q1U8BU_HFT_2022231.Models;
using System.Collections.Generic;
using System.Linq;

namespace Q1U8BU_HFT_2022231.Logic
{
    public interface ISongLogic
    {
        void Create(Song item);
        void Delete(int id);
        Song Read(int id);
        IQueryable<Song> ReadAll();
        void Update(Song item);
        
    }
}