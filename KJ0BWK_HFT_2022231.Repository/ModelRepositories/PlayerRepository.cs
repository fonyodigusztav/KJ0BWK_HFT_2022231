using KJ0BWK_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJ0BWK_HFT_2022231.Repository
{
    public class PlayerRepository : Repository<Player>, IRepository<Player>
    {
        public PlayerRepository(FootballDbContext ctx) :base(ctx)
        {

        }
        public override Player Read(int id)
        {
            return ctx.Players.FirstOrDefault(t => t.PlayerID == id);
        }

        public override void Update(Player item)
        {
            var oldPlayer = Read(item.PlayerID);
            if (oldPlayer == null)
            {
                throw new InvalidOperationException("player doesn't exists in the current context");
            }
            oldPlayer.Name = item.Name;
            oldPlayer.PlayerID = item.PlayerID;
            oldPlayer.Position = item.Position;
            oldPlayer.ClubID = item.ClubID;
            oldPlayer.Age = item.Age;
            oldPlayer.Rating = item.Rating;

            ctx.SaveChanges();
        }
    }
}
