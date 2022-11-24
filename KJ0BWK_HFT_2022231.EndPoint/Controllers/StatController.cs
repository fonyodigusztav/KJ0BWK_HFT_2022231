using KJ0BWK_HFT_2022231.Logic;
using KJ0BWK_HFT_2022231.Models;
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
            return cll.OwnersOfClubs();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGRatingByClub()
        {
            return pll.AVGRatingByClub();
        }
        [HttpGet]
        public IEnumerable<PlayerLogic.TeamInfo> TeamStatistics()
        {
            return pll.TeamStatistics();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGAgeByClub()
        {
            return pll.AVGAgeByClub();
        }
        [HttpGet("{clubName}")]
        public IEnumerable<Player> PlayersInAClubOrderedByRating(string clubName)
        {
            return pll.PlayersInAClubOrderedByRating(clubName);
        }
        //public IEnumerable<Player> PlayersInAClubOrderedByRating(string clubName)
        //{
        //    return repo.ReadAll().Where(t => t.Club.Name == clubName)
        //        .OrderByDescending(t => t.Rating)
        //        .Select(t => t);
        //}
    }
}
