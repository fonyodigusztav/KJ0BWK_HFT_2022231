using KJ0BWK_HFT_2022231.Models;
using System.Collections.Generic;
using System.Linq;

namespace KJ0BWK_HFT_2022231.Logic
{
    public interface IPlayerLogic
    {
        void Create(Player item);
        void Delete(int id);
        double? GetAverageRatePerTeam(int clubID);
        Player Read(int id);
        IQueryable<Player> ReadAll();
        IEnumerable<PlayerLogic.TeamInfo> TeamStatistics();
        void Update(Player item);
    }
}