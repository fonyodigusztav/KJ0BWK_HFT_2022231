using KJ0BWK_HFT_2022231.Logic;
using KJ0BWK_HFT_2022231.Models;
using KJ0BWK_HFT_2022231.Repository;
using System;
using System.Linq;

namespace KJ0BWK_HFT_2022231.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Hello");

            var ctx = new FootballDbContext();

            var playerRepo = new PlayerRepository(ctx);
            var clubRepo = new ClubRepository(ctx);
            var ownerRepo = new OwnerRepository(ctx);

            var playerLogic = new PlayerLogic(playerRepo);
            var clubLogic = new ClubLogic(clubRepo);
            var ownerLogic = new OwnerLogic(ownerRepo);
            ;
        }
    }
}
