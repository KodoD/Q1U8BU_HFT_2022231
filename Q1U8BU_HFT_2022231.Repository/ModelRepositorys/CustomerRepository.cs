using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q1U8BU_HFT_2022231.Models;

namespace Q1U8BU_HFT_2022231.Repository
{
    public class CustomerRepository : Repository<Customer>, IRepository<Customer>
    {
        public CustomerRepository(HFTContext ctx) : base(ctx)
        {
        }

        public override Customer Read(int id)
        {
            return ctx.Customer.FirstOrDefault(t => t.CustomerID == id);
        }

        public override void Update(Customer item)
        {
            var old=Read(item.CustomerID);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
