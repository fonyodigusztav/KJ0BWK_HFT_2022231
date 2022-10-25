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
        static PlayerLogic playerLogic;
        static ClubLogic clubLogic;
        static OwnerLogic ownerLogic;
        static void Create(string entity)
        {
            Console.WriteLine(entity + " create");
            Console.ReadLine();
        }
        static void List(string entity)
        {
            if (entity == "Player")
            {
                var items = playerLogic.ReadAll();
                Console.WriteLine("ID" + "\t" + "Name");
                foreach (var item in items)
                {
                    Console.WriteLine(item.PlayerID + "\t" + item.Name);
                }
                Console.ReadLine();
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
            Console.WriteLine("Hello");

            var ctx = new FootballDbContext();

            var playerRepo = new PlayerRepository(ctx);
            var clubRepo = new ClubRepository(ctx);
            var ownerRepo = new OwnerRepository(ctx);

            playerLogic = new PlayerLogic(playerRepo);
            clubLogic = new ClubLogic(clubRepo);
            ownerLogic = new OwnerLogic(ownerRepo);


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
