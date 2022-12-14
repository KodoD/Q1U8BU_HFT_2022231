using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q1U8BU_HFT_2022231.Models;

namespace Q1U8BU_HFT_2022231.Repository
{
    public class SongRepository : Repository<Song>, IRepository<Song>
    {
        public SongRepository(HFTContext ctx) : base(ctx)
        {
        }

        public override Song Read(int id)
        {
            return ctx.Song.FirstOrDefault(t => t.SongID == id);
        }

        public override void Update(Song item)
        {
            var old = Read(item.SongID);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
