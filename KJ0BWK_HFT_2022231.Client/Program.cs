﻿using ConsoleTools;
using KJ0BWK_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KJ0BWK_HFT_2022231.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);
            RestService rest = new RestService("http://localhost:64355/");
            MenuMain(rest);



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
        }
        public static void MenuMain(RestService restS)
        {
            var menu = new ConsoleMenu()
                .Add("Player CRUD", () => PlayerCRUDMenu(restS))
                .Add("Club CRUD", () => ClubCRUDMenu(restS))
                .Add("Owner CRUD", () => OwnerCRUDMenu(restS))
                .Add("NON CRUD", () => NonCrudMenu(restS))
                .Add("Close", ConsoleMenu.Close);
            menu.Show();
        }
        public static void PlayerCRUDMenu(RestService restS)
        {
            var menuPlayer = new ConsoleMenu()
                .Add("PlayerDelete", () => DeletePlayer(restS))
                .Add("PlayerCreate", () => CreatePlayer(restS))
                .Add("PlayerRead", () => ReadPlayer(restS))
                .Add("PlayerUpdate", () => UpdatePlayer(restS))
                .Add("PlayerReadAll", () => ReadAllPlayer(restS))
                .Add("Close", ConsoleMenu.Close);
            menuPlayer.Show();
        }
        public static void ClubCRUDMenu(RestService restS)
        {
            var menuClub = new ConsoleMenu()
                .Add("ClubDelete", () => DeleteClub(restS))
                .Add("ClubCreate", () => CreateClub(restS))
                .Add("ClubRead", () => ReadClub(restS))
                .Add("ClubUpdate", () => UpdateClub(restS))
                .Add("ClubReadAll", () => ReadAllClub(restS))
                .Add("Close", ConsoleMenu.Close);
            menuClub.Show();
        }
        public static void OwnerCRUDMenu(RestService restS)
        {
            var menuOwner = new ConsoleMenu()
                .Add("OwnerDelete", () => DeleteOwner(restS))
                .Add("OwnerCreate", () => CreateOwner(restS))
                .Add("OwnerRead", () => ReadOwner(restS))
                .Add("OwnerUpdate", () => UpdateOwner(restS))
                .Add("OwnerReadAll", () => ReadAllOwner(restS))
                .Add("Close", ConsoleMenu.Close);
            menuOwner.Show();
        }
        public static void NonCrudMenu(RestService restS)
        {
            var menuNonCrud = new ConsoleMenu()
                .Add("OwnersOfClubs", () => OwnerOfClubs(restS))
                .Add("AVGRatingByClub", () => AVGRatingByClub(restS))
                .Add("TeamStatistics", () => TeamStatistics(restS))
                .Add("OwnerUpdate", () => AVGAgeByClub(restS))
                .Add("OwnerReadAll", () => PlayersInAClubOrderedByRating(restS))
                .Add("Close", ConsoleMenu.Close);
            menuNonCrud.Show();
        }

        //Delete start
        private static void DeletePlayer(int id, RestService restS)
        {
            restS.Delete(id, "player");
        }
        private static void DeletePlayer(RestService restS)
        {
            Console.WriteLine("Please insert the ID of the Player you wish to be deleted!");
            int id = Convert.ToInt32(Console.ReadLine());
            DeletePlayer(id, restS);
            Console.WriteLine("Deleted successfully");
            System.Threading.Thread.Sleep(1000);
        }

        private static void DeleteClub(int id, RestService restS)
        {
            restS.Delete(id, "club");
        }
        private static void DeleteClub(RestService restS)
        {
            Console.WriteLine("Please insert the ID of the Club you wish to be deleted!");
            int id = Convert.ToInt32(Console.ReadLine());
            DeleteClub(id, restS);
            Console.WriteLine("Deleted successfully");
            System.Threading.Thread.Sleep(1000);
        }

        private static void DeleteOwner(int id, RestService restS)
        {
            restS.Delete(id, "owner");
        }
        private static void DeleteOwner(RestService restS)
        {
            Console.WriteLine("Please insert the ID of the Owner you wish to be deleted!");
            int id = Convert.ToInt32(Console.ReadLine());
            DeleteOwner(id, restS);
            Console.WriteLine("Deleted successfully");
            System.Threading.Thread.Sleep(1000);
        }

        //Delete end

        //Create start
        private static void CreatePlayer(string name, int age, string position, 
            double rating, int clubID, RestService restS)
        {
            Player newPlayer = new Player
            {
                Name = name,
                Age = age,
                Position = position,
                Rating = rating,
                ClubID = clubID
            };
            restS.Post<Player>(newPlayer, "player");
        }

        private static void CreatePlayer(RestService restS)
        {
            Console.WriteLine("Insert the name of your new Player!");
            string name = Console.ReadLine();
            Console.WriteLine("Insert the age of your new Player!");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert the position of you new Player!");
            string position = Console.ReadLine();
            Console.WriteLine("Insert the rating of you new Player!");
            double rating = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Insert the clubID of your new Player!");
            int clubID = Convert.ToInt32(Console.ReadLine());
            CreatePlayer(name, age, position, rating, clubID, restS);
        }

        private static void CreateClub(string name, string championship, int ownerID,RestService restS)
        {
            Club newClub = new Club
            {
                Name = name,
                Championship = championship,
                OwnerID = ownerID
            };

            restS.Post<Club>(newClub, "club");
        }

        private static void CreateClub(RestService restS)
        {
            Console.WriteLine("Insert the name of your new Club!");
            string name = Console.ReadLine();
            Console.WriteLine("Insert the championship of your new Club!");
            string championship = Console.ReadLine();
            Console.WriteLine("Insert the ownerID of your new Club!");
            int ownerID = Convert.ToInt32(Console.ReadLine());
            CreateClub(name, championship, ownerID ,restS);
        }

        private static void CreateOwner(string name, int age, RestService restS)
        {
            Owner newOwner = new Owner
            {
                Name = name,
                Age = age
            };
            restS.Post<Owner>(newOwner, "owner");
        }
        private static void CreateOwner(RestService restS)
        {
            Console.WriteLine("Insert the name of your new Owner!");
            string name = Console.ReadLine();
            Console.WriteLine("Insert the age of your new Owner!");
            int age = Convert.ToInt32(Console.ReadLine());
            CreateOwner(name,age, restS);
        }

        //CreateEnd






        static void Create(string entity)
        {
            if (entity == "Player")
            {
                Console.Write("Enter Player Name: ");
                string name = Console.ReadLine();
                rest.Post(new Player() { Name = name }, "player");
            }
        }
        static void List(string entity)
        {
            if (entity == "Player")
            {
                List<Player> players = rest.Get<Player>("player");
                foreach (var item in players)
                {
                    Console.WriteLine(item.Name);
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
        
    }
}
