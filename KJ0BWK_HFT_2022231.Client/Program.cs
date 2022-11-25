using ConsoleTools;
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
                .Add("AVGAgeByClub", () => AVGAgeByClub(restS))
                .Add("PlayersInAClubOrderedByRating", () => PlayersInAClubOrderedByRating(restS))
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

        //ReadStart

        private static void ReadPlayer(int id,RestService restS)
        {
            var player = restS.Get<Player>(id, "player");
            Console.WriteLine(player.ToString());
        }
        private static void ReadPlayer(RestService restS)
        {
            Console.WriteLine("Insert the ID of the Player you want to Read!");
            int id = Convert.ToInt32(Console.ReadLine());
            ReadPlayer(id, restS);
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }
        private static void ReadClub(int id, RestService restS)
        {
            var club = restS.Get<Club>(id, "club");
            Console.WriteLine(club.ToString());
        }
        private static void ReadClub(RestService restS)
        {
            Console.WriteLine("Insert the ID of the Club you want to Read!");
            int id = Convert.ToInt32(Console.ReadLine());
            ReadClub(id, restS);
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }
        private static void ReadOwner(int id, RestService restS)
        {
            var owner = restS.Get<Owner>(id, "owner");
            Console.WriteLine(owner.ToString());
        }
        private static void ReadOwner(RestService restS)
        {
            Console.WriteLine("Insert the ID of the Owner you want to Read!");
            int id = Convert.ToInt32(Console.ReadLine());
            ReadOwner(id, restS);
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }
        //ReadEnd

        //UpdateStart
        private static void UpdatePlayer(int ID, string name, int age, string position,
            double rating, int clubID, RestService restS)
        {
            Player newPlayer = new Player
            {
                PlayerID = ID,
                Name = name,
                Age = age,
                Position = position,
                Rating = rating,
                ClubID = clubID
            };
            restS.Put<Player>(newPlayer, "player");
        }
        private static void UpdatePlayer(RestService restS)
        {
            Console.WriteLine("Insert the ID you want to update!");
            int ID = Convert.ToInt32(Console.ReadLine());
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
            UpdatePlayer(ID, name, age, position, rating, clubID, restS);
        }

        private static void UpdateClub(int ID, string name, string championship, int ownerID, RestService restS)
        {
            Club newClub = new Club
            {
                ClubID = ID,
                Name = name,
                Championship = championship,
                OwnerID = ownerID
            };

            restS.Put<Club>(newClub, "club");
        }

        private static void UpdateClub(RestService restS)
        {
            Console.WriteLine("Insert the name of your new Club!");
            int ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert the name of your new Club!");
            string name = Console.ReadLine();
            Console.WriteLine("Insert the championship of your new Club!");
            string championship = Console.ReadLine();
            Console.WriteLine("Insert the ownerID of your new Club!");
            int ownerID = Convert.ToInt32(Console.ReadLine());
            UpdateClub(ID, name, championship, ownerID, restS);
        }

        private static void UpdateOwner(int ID, string name, int age, RestService restS)
        {
            Owner newOwner = new Owner
            {
                OwnerID = ID,
                Name = name,
                Age = age
            };
            restS.Put<Owner>(newOwner, "owner");
        }
        private static void UpdateOwner(RestService restS)
        {
            Console.WriteLine("Insert the ID of your new Owner!");
            int ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert the name of your new Owner!");
            string name = Console.ReadLine();
            Console.WriteLine("Insert the age of your new Owner!");
            int age = Convert.ToInt32(Console.ReadLine());
            UpdateOwner(ID, name, age, restS);
        }

        //UpdateEnd
        //ReadAllStart
        private static void ReadAllPlayer(RestService restS)
        {
            var player = restS.Get<Player>("player");

            foreach (var item in player)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }
        private static void ReadAllClub(RestService restS)
        {
            var club = restS.Get<Club>("club");

            foreach (var item in club)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }
        private static void ReadAllOwner(RestService restS)
        {
            var owner = restS.Get<Owner>("owner");

            foreach (var item in owner)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }
        //ReadAllEnd


        //NonCrud
        private static void OwnerOfClubs(RestService restS)
        {
            var clubsOwners = restS.Get<KeyValuePair<string, string>>("stat/ownerofclubs");
            Console.WriteLine("Clubs listed with its Owners next to it:");
            foreach (var item in clubsOwners)
            {
                Console.WriteLine(item.Key, item.Value);
            }
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }
        private static void AVGRatingByClub(RestService restS)
        {
            var avgRatings = restS.Get<KeyValuePair<string, double>>("stat/avgratingsbyclub");
            Console.WriteLine("Clubs listed with the average ratings of its players");
            foreach (var item in avgRatings)
            {
                Console.WriteLine(item.Key, item.Value);
            }
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }
        private static void TeamStatistics(RestService restS)
        {
            //var teamstat = restS.Get<Logic.PlayerLogic.TeamInfo>("stat/avgratingsbyclub");
            Console.WriteLine("hiba");
        }
        private static void AVGAgeByClub(RestService restS)
        {
            var avgAge = restS.Get<KeyValuePair<string, double>>("stat/avgagesbyclub");
            Console.WriteLine("Clubs listed with the average ages of its players");
            foreach (var item in avgAge)
            {
                Console.WriteLine(item.Key, item.Value);
            }
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }
        private static void PlayersInAClubOrderedByRating(RestService restS)
        {
            var orderedPlayers = restS.Get<Player>("stat/playersinacluborderedbyrating");
            Console.WriteLine("Players in a club ordered by rating");
            foreach (var item in orderedPlayers)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }


    }
}
