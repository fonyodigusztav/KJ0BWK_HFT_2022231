using System;
using KJ0BWK_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJ0BWK_HFT_2022231.Repository
{
    public class FootballDbContext: DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public FootballDbContext()
        {
            this.Database.EnsureCreated();
        }
    }
}
