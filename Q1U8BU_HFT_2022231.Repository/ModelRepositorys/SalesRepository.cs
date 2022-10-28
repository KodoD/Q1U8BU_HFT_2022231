using Q1U8BU_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1U8BU_HFT_2022231.Repository
{
    public class SalesRepository : Repository<Sales>, IRepository<Sales>
    {
        public SalesRepository(HFTContext ctx) : base(ctx)
        {
        }

        public override Sales Read(int id)
        {
            return ctx.Sales.FirstOrDefault(t => t.SalesID == id);
        }

        public override void Update(Sales item)
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
