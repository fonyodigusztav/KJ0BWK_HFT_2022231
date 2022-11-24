using KJ0BWK_HFT_2022231.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KJ0BWK_HFT_2022231.EndPoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IPlayerLogic pll;
        IClubLogic cll;
        IOwnerLogic owl;
        public StatController(IPlayerLogic pll, IClubLogic cll, IOwnerLogic owl)
        {
            this.pll = pll;
            this.cll = cll;
            this.owl = owl;
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> OwnersOfClubs()
        {
            return cll.
        }

        //public IEnumerable<KeyValuePair<string, string>> OwnersOfClubs()
        //{
        //    return from x in repo.ReadAll()
        //           select new KeyValuePair<string, string>
        //           (x.Name, x.Owner.Name);
        //}
        //public IEnumerable<KeyValuePair<string, double>> AVGRatingByClub()
        //{
        //    return from x in repo.ReadAll()
        //           group x by x.Club.Name into g
        //           select new KeyValuePair<string, double>
        //           (g.Key, g.Average(t => t.Rating));
        //}
        //public IEnumerable<TeamInfo> TeamStatistics()
        //{
        //    return from x in this.repo.ReadAll()
        //           group x by x.Club.Name into g
        //           select new TeamInfo()
        //           {
        //               ClubName = g.Key,
        //               AvgRating = g.Average(t => t.Rating),
        //               PlayerNumber = g.Count()
        //           };
        //}
        //public IEnumerable<KeyValuePair<string, double>> AVGAgeByClub()
        //{
        //    return from x in repo.ReadAll()
        //           group x by x.Club.Name into g
        //           select new KeyValuePair<string, double>
        //           (g.Key, g.Average(t => t.Age));
        //}
        //public IEnumerable<Player> PlayersInAClubOrderedByRating(string clubName)
        //{
        //    return repo.ReadAll().Where(t => t.Club.Name == clubName)
        //        .OrderByDescending(t => t.Rating)
        //        .Select(t => t);
        //}
    }
}
