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
            var oldOwner = Read(item.OwnerID);
            if (oldOwner == null)
            {
                throw new InvalidOperationException("owner doesn't exists in the current context");
            }
            oldOwner.Name = item.Name;
            oldOwner.OwnerID = item.OwnerID;
            oldOwner.Age = item.Age;

            ctx.SaveChanges();
        }
    }
}
