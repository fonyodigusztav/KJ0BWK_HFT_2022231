using System;
using System.Collections.Generic;
using System.Linq;
using KJ0BWK_HFT_2022231.Models;
using KJ0BWK_HFT_2022231.Repository;

namespace KJ0BWK_HFT_2022231.Logic
{
    public class PlayerLogic : IPlayerLogic
    {

        IRepository<Player> repo;

        public PlayerLogic(IRepository<Player> repo)
        {
            this.repo = repo;
        }

        public void Create(Player item)
        {
            if (item.Age <= 0)
            {
                throw new ArgumentException($"{item.Name} Player's age is invalid");
            }
            if (item.Position.Length > 3)
            {
                throw new ArgumentException($"{item.Name} Player's Position must be specified with maximum of three letters");
            }
            if (item.Rating < 1 || item.Rating > 99)
            {
                throw new ArgumentException($"{item.Name} Player's Rating must be between 1 and 99");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Player Read(int id)
        {
            var player = this.repo.Read(id);
            if (player == null)
            {
                throw new ArgumentException("Player does not exist in the current database");
            }
            return player;
        }

        public IQueryable<Player> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Player item)
        {
            this.repo.Update(item);
        }

        //non cruds!

        public double? GetAverageRatePerTeam(int clubID)
        {
            return this.repo
                .ReadAll()
                .Where(t => t.ClubID == clubID)
                .Average(t => t.Rating);
        }
        //public IEnumerable<KeyValuePair<string, double>> AVGRatingByClub()
        //{
        //    return from x in repo.ReadAll()
        //           group x by x.Club.Name into g
        //           select new KeyValuePair<string, double>
        //           (g.Key, g.Average(t => t.Rating));
        //}
        public IEnumerable<KeyValuePair<string, double>> AVGRatingByClub()
        {
            return from x in repo.ReadAll()
                   group x by x.Club.Name into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.Rating));
        }
        public IEnumerable<TeamInfo> TeamStatistics()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Club.Name into g
                   select new TeamInfo()
                   {
                       ClubName = g.Key,
                       AvgRating = g.Average(t => t.Rating),
                       PlayerNumber = g.Count()
                   };
        }
        public IEnumerable<KeyValuePair<string, double>> AVGAgeByClub()
        {
            return from x in repo.ReadAll()
                   group x by x.Club.Name into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.Age));
        }
        public IEnumerable<Player> PlayersInAClubOrderedByRating(string clubName)
        {
            return repo.ReadAll().Where(t => t.Club.Name == clubName)
                .OrderByDescending(t => t.Rating)
                .Select(t => t);
        }

        public Player BestPlayerInAClub(string clubName)
        {
            return repo.ReadAll()
                .Where(t => t.Club.Name == clubName)
                .OrderByDescending(t => t.Rating)
                .Select(t => t)
                .First();
        }
        public class TeamInfo
        {
            public string ClubName { get; set; }
            public double? AvgRating { get; set; }
            public int PlayerNumber { get; set; }

            public override bool Equals(object obj)
            {
                TeamInfo b = obj as TeamInfo;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.ClubName == b.ClubName
                        && this.AvgRating == b.AvgRating
                        && this.PlayerNumber == b.PlayerNumber;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.ClubName, this.AvgRating, this.PlayerNumber);
            }
        }
    }
}
