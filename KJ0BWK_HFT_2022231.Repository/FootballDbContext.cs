using System;
using KJ0BWK_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJ0BWK_HFT_2022231.Repository
{
    internal class FootballDbContext: DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public FootballDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseInMemoryDatabase("football")
                    .UseLazyLoadingProxies();            
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(player => player
            .HasOne(player => player.Club)
            .WithMany(club => club.Players)
            .HasForeignKey(player => player.ClubID)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Club>(club => club
            .HasOne(club => club.Owner)
            .WithMany(owner => owner.Clubs)
            .HasForeignKey(club => club.OwnerID)
            .OnDelete(DeleteBehavior.Cascade));


            modelBuilder.Entity<Player>().HasData(new Player[]
            {
                new Player("1#Cristiano Ronaldo#36#ST#90#4"),
                new Player("2#Raheem Sterling#24#RW#89#5"),
                new Player("3#Gabriel Jesus#30#ST#85#6")
            });

            modelBuilder.Entity<Club>().HasData(new Club[]
            {
                new Club("4#Manchester united#PL#7"),
                new Club("5#Chelsea#PL#8"),
                new Club("6#Arsenal#PL#9")
            });

            modelBuilder.Entity<Owner>().HasData(new Owner[]
            {
                new Owner("7#Gustav#4#32"),
                new Owner("8#James#5#65"),
                new Owner("9#Kiddo#6#46")
            });
        }
    }
}
