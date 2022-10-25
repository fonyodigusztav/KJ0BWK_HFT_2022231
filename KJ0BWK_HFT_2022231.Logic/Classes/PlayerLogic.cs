﻿using System;
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
            if (item.Rating >= 100 && item.Rating <= 0)
            {
                throw new ArgumentException("A player's rating must be between 0 and 100!");
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
        public IEnumerable<TeamInfo> TeamStatistics()
        {
            return from x in this.repo.ReadAll()
                   group x by x.ClubID into g
                   select new TeamInfo()
                   {
                       ClubID = g.Key,
                       AvgRating = g.Average(t => t.Rating),
                       PlayerNumber = g.Count()
                   };
        }

        public class TeamInfo
        {
            public int ClubID { get; set; }
            public double? AvgRating { get; set; }
            public int PlayerNumber { get; set; }
        }
    }
}
