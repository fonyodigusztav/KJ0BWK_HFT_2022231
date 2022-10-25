using KJ0BWK_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJ0BWK_HFT_2022231.Repository
{
    public class OwnerRepository : Repository<Owner>, IRepository<Owner>
    {
        public OwnerRepository(FootballDbContext ctx) : base(ctx)
        {

        }
        public override Owner Read(int id)
        {
            return ctx.Owners.FirstOrDefault(t => t.OwnerID == id);
        }

        public override void Update(Owner item)
        {
            var old = Read(item.OwnerID);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
