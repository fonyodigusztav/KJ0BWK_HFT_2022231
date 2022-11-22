using ConsoleTools;
using KJ0BWK_HFT_2022231.Logic;
using KJ0BWK_HFT_2022231.Models;
using KJ0BWK_HFT_2022231.Repository;
using System;
using System.Linq;

namespace KJ0BWK_HFT_2022231.Client
{
    class Program
    {
         
        static RestService rest;
        static void Create(string entity)
        {
            Console.WriteLine(entity + " create");
            Console.ReadLine();
        }
        static void List(string entity)
        {
            if (entity == "Player")
            {
                
            }
        }
        static void Update(string entity)
        {
            Console.WriteLine(entity + " update");
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            Console.WriteLine(entity + " delete");
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");



            var ctx = new FootballDbContext();
            var repo = new PlayerRepository(ctx);
            var logic = new PlayerLogic(repo);
            //"1#Cristiano Ronaldo#36#ST#90#4"
            Player p = new Player()
            {
                PlayerID = 6,
                Name = "Lampard",
                Age = 40,
                Position = "CM",
                Rating = 88,
                ClubID = 5
            };
            logic.Create(p);

            var avg = logic.GetAverageRatePerTeam(4);
            var bestplayer = logic.BestPlayerInAClub("Chelsea");


            var playersInAClubOrdered = logic.PlayersInAClubOrderedByRating("Chelsea");
            var avgAge = logic.AVGAgeByClub();
            var avgRating = logic.AVGRatingByClub();
            var teamStat = logic.TeamStatistics();

            var repoclub = new ClubRepository(ctx);
            var logicClub = new ClubLogic(repoclub);


            var repoOwner = new OwnerRepository(ctx);
            var logicOwner = new OwnerLogic(repoOwner);
            var asd = logicOwner.asd();
            ;






            var ownerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Owner"))
                .Add("Create", () => Create("Owner"))
                .Add("Delete", () => Delete("Owner"))
                .Add("Update", () => Update("Owner"))
                .Add("Exit", ConsoleMenu.Close);

            var clubSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Club"))
                .Add("Create", () => Create("Club"))
                .Add("Delete", () => Delete("Club"))
                .Add("Update", () => Update("Club"))
                .Add("Exit", ConsoleMenu.Close);

            var playerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Player"))
                .Add("Create", () => Create("Player"))
                .Add("Delete", () => Delete("Player"))
                .Add("Update", () => Update("Player"))
                .Add("Exit", ConsoleMenu.Close);
            
            var menu = new ConsoleMenu(args, level: 0)
                .Add("Players", () => playerSubMenu.Show())
                .Add("Clubs", () => clubSubMenu.Show())
                .Add("Owners", () => ownerSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);
            
            menu.Show();
            ;
        }
    }
}
