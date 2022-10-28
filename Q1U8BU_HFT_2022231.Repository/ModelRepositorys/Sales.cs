using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q1U8BU_HFT_2022231.Models;

namespace Q1U8BU_HFT_2022231.Repository
{
    public class Sales : Repository<Sales>, IRepository<Sales>
    {
        public Sales(HFTContext ctx) : base(ctx)
        {
        }

        public override Sales Read(int id)
        {
            return ctx.Sales.FirstOrDefault(t=>t.)
        }

        public override void Update(Sales item)
        {
            var old = Read(item.Salesid);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
