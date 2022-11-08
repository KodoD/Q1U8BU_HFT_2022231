using Q1U8BU_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1U8BU_HFT_2022231.Repository
{
    public class AuthorRepository : Repository<Author>, IRepository<Author>
    {
        public AuthorRepository(HFTContext ctx) : base(ctx)
        {
        }

        public override Author Read(int id)
        {
            return ctx.Author.FirstOrDefault(t => t.AutherId == id);
        }

        public override void Update(Author item)
        {
            var old = Read(item.AutherId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }

    }
}
