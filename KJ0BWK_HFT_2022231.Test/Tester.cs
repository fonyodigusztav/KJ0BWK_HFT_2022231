using KJ0BWK_HFT_2022231.Logic;
using KJ0BWK_HFT_2022231.Models;
using KJ0BWK_HFT_2022231.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJ0BWK_HFT_2022231.Test
{
    [TestFixture]
    public class Tester
    {
        PlayerLogic playerL;
        ClubLogic clubL;
        OwnerLogic ownerL;

        [SetUp]
        public void Initialization()
        {
            var mockPlayerRepository = new Mock<IRepository<Player>>();
            var mockClubRepository = new Mock<IRepository<Club>>();
            var mockOwnerRepository = new Mock<IRepository<Owner>>();

            var owners = new List<Owner>()
            {
                new Owner()
                {
                    Name = "Gusztav",
                    Age = 20,
                    OwnerID = 34
                }
            }.AsQueryable();
            
            var clubs = new List<Club>()
            {
                new Club()
                {
                    ClubID = 22,
                    Name = "PSG",
                    Championship = "Ligue1",
                    OwnerID = 34,

                },
                new Club()
                {
                    ClubID = 23,
                    Name = "Barcelona",
                    Championship = "LaLiga",
                    OwnerID = 34,

                }
            }.AsQueryable();


            var players = new List<Player>()
            {
                new Player()
                {
                    Name = "Neymar",
                    Age = 36,
                    ClubID = 22,
                    PlayerID = 30,
                    Position = "ST",
                    Rating = 91
                },
                new Player()
                {
                    Name = "Messi",
                    Age = 35,
                    ClubID = 22,
                    PlayerID = 31,
                    Position = "RW",
                    Rating = 97
                },
                new Player()
                {
                    Name = "Lewandowski",
                    Age = 37,
                    ClubID = 23,
                    PlayerID = 32,
                    Position = "SW",
                    Rating = 93
                }
            }.AsQueryable();

            mockPlayerRepository.Setup((t) => t.ReadAll()).Returns(players);
            mockClubRepository.Setup((t) => t.ReadAll()).Returns(clubs);
            mockOwnerRepository.Setup((t) => t.ReadAll()).Returns(owners);

            playerL = new PlayerLogic(mockPlayerRepository.Object);
            clubL = new ClubLogic(mockClubRepository.Object);
            ownerL = new OwnerLogic(mockOwnerRepository.Object);

        }

        [TestCase(-30,false)]
        [TestCase(30,true)]
        public void CreatePlayerTest(int age, bool result)
        {
            if (result)
            {
                Assert.That(
                    () =>
                    {
                        playerL.Create(
                            new Player()
                            {
                                Name = "Name",
                                Age = age,
                                PlayerID = 1,
                                Position = "CB",
                                Rating = 24
                            }           
                                        );
                    }, Throws.Nothing
                            );
            }
            else
            {
                Assert.That(
                    () =>
                    {
                        playerL.Create(
                            new Player()
                            {
                                Name = "Name",
                                Age = age,
                                PlayerID = 1,
                                Position = "CB",
                                Rating = 24
                            }
                                        );
                    }, Throws.Exception
                            );
            }
        }

        [TestCase("ASDF", false)]
        [TestCase("ASD", true)]
        public void CreatePlayerTest2(string position, bool result)
        {
            if (result)
            {
                Assert.That(
                    () =>
                    {
                        playerL.Create(
                            new Player()
                            {
                                Name = "Name",
                                Age = 18,
                                PlayerID = 1,
                                Position = position,
                                Rating = 24
                            }
                                        );
                    }, Throws.Nothing
                            );
            }
            else
            {
                Assert.That(
                    () =>
                    {
                        playerL.Create(
                            new Player()
                            {
                                Name = "Name",
                                Age = 18,
                                PlayerID = 1,
                                Position = position,
                                Rating = 24
                            }
                                        );
                    }, Throws.Exception
                            );
            }
        }

        [TestCase(-10, false)]
        [TestCase(100, false)]
        [TestCase(50, true)]
        public void CreatePlayerTest3(int rating, bool result)
        {
            if (result)
            {
                Assert.That(
                    () =>
                    {
                        playerL.Create(
                            new Player()
                            {
                                Name = "Name",
                                Age = 18,
                                PlayerID = 1,
                                Position = "ST",
                                Rating = rating
                            }
                                        );
                    }, Throws.Nothing
                            );
            }
            else
            {
                Assert.That(
                    () =>
                    {
                        playerL.Create(
                            new Player()
                            {
                                Name = "Name",
                                Age = 18,
                                PlayerID = 1,
                                Position = "ST",
                                Rating = rating
                            }
                                        );
                    }, Throws.Exception
                            );
            }
        }

        [TestCase("name", "championship", true)]
        [TestCase("name", null,false)]
        [TestCase(null, "championship",false)]
        public void CreateClubTest(string name, string championship, bool result)
        {
            if (result)
            {
                Assert.That(
                    () =>
                    {
                        clubL.Create(
                            new Club()
                            {
                                Name = name,
                                Championship = championship,
                            }
                                        );
                    }, Throws.Nothing
                            );
            }
            else
            {
                Assert.That(
                    () =>
                    {
                        clubL.Create(
                            new Club()
                            {
                                Name = name,
                                Championship = championship,
                            }
                                        );
                    }, Throws.Exception
                            );
            }
        }
        [TestCase(-30, false)]
        [TestCase(30, true)]
        public void CreateOwnerTest(int age, bool result)
        {
            if (result)
            {
                Assert.That(
                    () =>
                    {
                        ownerL.Create(
                            new Owner()
                            {
                                Name = "owner",
                                Age = age
                            }
                                        );
                    }, Throws.Nothing
                            );
            }
            else
            {
                Assert.That(
                    () =>
                    {
                        ownerL.Create(
                            new Owner()
                            {
                                Name = "owner",
                                Age = age
                            }
                                        );
                    }, Throws.Exception
                            );
            }
        }

        
        //public IEnumerable<KeyValuePair<string, double>> AVGRatingByClub()
        //{
        //    return from x in repo.ReadAll()
        //           group x by x.Club.Name into g
        //           select new KeyValuePair<string, double>
        //           (g.Key, g.Average(t => t.Rating));
        //}
    }
}
