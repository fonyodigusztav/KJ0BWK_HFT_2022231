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
                new Player("1#Cristiano Ronaldo#36#ST#90#1"),
                new Player("2#Raheem Sterling#24#RW#89#2"),
                new Player("3#Gabriel Jesus#30#ST#85#3"),
                new Player("4#Harry Maguire#26#CB#60#1"),
                new Player("5#Didier Drogba#40#ST#99#2"),
                new Player("6#David Villa#50#LW#92#4"),
                new Player("7#Valverde#20#LW#75#5"),
                new Player("8#Borja Valero#60#CM#60#6"),
                new Player("9#Sergio Ramos#36#CB#89#5")
            });

            modelBuilder.Entity<Club>().HasData(new Club[]
            {
                new Club("1#Manchester United#PL#1"),
                new Club("2#Chelsea#PL#2"),
                new Club("3#Arsenal#PL#2"),
                new Club("4#Barcelona#PL#1"),
                new Club("5#RealMadrid#PL#1"),
                new Club("6#Sevilla#PL#3")
            });

            modelBuilder.Entity<Owner>().HasData(new Owner[]
            {
                new Owner("1#Gustav#32"),
                new Owner("2#James#65"),
                new Owner("3#Kiddo#46")
            });
        }
    }
}
