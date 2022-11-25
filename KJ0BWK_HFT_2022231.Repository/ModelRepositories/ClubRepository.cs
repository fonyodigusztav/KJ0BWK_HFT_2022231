using KJ0BWK_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJ0BWK_HFT_2022231.Repository
{
    public class ClubRepository : Repository<Club>, IRepository<Club>
    {
        public ClubRepository(FootballDbContext ctx) : base(ctx)
        {

        }
        public override Club Read(int id)
        {
            return ctx.Clubs.FirstOrDefault(t => t.ClubID == id);
        }

        public override void Update(Club item)
        {
            var oldClub = Read(item.ClubID);
            if (oldClub == null)
            {
                throw new InvalidOperationException("club doesn't exists in the current context");
            }
            oldClub.Name = item.Name;
            oldClub.Championship = item.Championship;
            oldClub.OwnerID = item.OwnerID;
            oldClub.ClubID = item.ClubID;

            ctx.SaveChanges();
        }
    }
}
