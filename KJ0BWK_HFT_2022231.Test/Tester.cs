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
using static KJ0BWK_HFT_2022231.Logic.PlayerLogic;

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

            //var mockPlayerRepository = new Mock<IPlayerRepository>();
            //var mockClubRepository = new Mock<IClubRepository>();
            //var mockOwnerRepository = new Mock<IOwnerRepository>();

            var owners = new List<Owner>()
            {
                //new Owner("1#Gustav#20"),
                new Owner()
                {
                    Name = "Gusztav",
                    Age = 20,
                    OwnerID = 1,
                },
                new Owner()
                {
                    Name = "Gellert",
                    Age = 30,
                    OwnerID = 2,
                }
            }.AsQueryable();

            var clubs = new List<Club>()
            {
                //new Club("4#PSG#Ligue1#1"),
                //new Club("5#Barcelona#LaLiga#1"),
                new Club()
                {
                    ClubID = 1,
                    Name = "PSG",
                    Championship = "Ligue1",
                    OwnerID = 1,
                    Owner = owners.First()
                },
                new Club()
                {
                    ClubID = 2,
                    Name = "Barcelona",
                    Championship = "LaLiga",
                    OwnerID = 2,
                    Owner = owners.Skip(1).First()
                }
            }.AsQueryable();

            


            var players = new List<Player>()
            {
                //new Player("1#Neymar#35#ST#20#4"),
                //new Player("2#Messi#35#RW#20#4"),
                //new Player("3#Lewandowski#40#ST#10#5"),
                //new Player("4#Gavi#20#CM#20#5")
                new Player()
                {
                    PlayerID = 1,
                    Name = "Neymar",
                    Age = 35,
                    Position = "ST",
                    Rating = 20,
                    ClubID = 1,
                    Club = clubs.First()
                },
                new Player()
                {
                    PlayerID = 2,
                    Name = "Messi",
                    Age = 35,
                    Position = "RW",
                    Rating = 20,
                    ClubID = 1,
                    Club = clubs.First()
                },
                new Player()
                {
                    PlayerID = 3,
                    Name = "Lewandowski",
                    Age = 40,
                    Position = "ST",
                    Rating = 10,
                    ClubID = 2,
                    Club = clubs.Skip(1).First()
                },
                new Player()
                {
                    PlayerID = 4,
                    Name = "Gavi",
                    Age = 20,
                    Position = "CDM",
                    Rating = 20,
                    ClubID = 2,
                    Club = clubs.Skip(1).First()
                }
            }.AsQueryable();
            

            mockPlayerRepository.Setup((t) => t.ReadAll()).Returns(players);
            mockClubRepository.Setup((t) => t.ReadAll()).Returns(clubs);
            mockOwnerRepository.Setup((t) => t.ReadAll()).Returns(owners);


            playerL = new PlayerLogic(mockPlayerRepository.Object);
            clubL = new ClubLogic(mockClubRepository.Object);
            ownerL = new OwnerLogic(mockOwnerRepository.Object);
            ;
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

        //non cruds

        [Test]
        public void AVGRatingByClubTest()
        {
            var result = playerL.AVGRatingByClub();
            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("PSG", 20),
                new KeyValuePair<string, double>("Barcelona", 15)
            };
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AVGAgeByClubTest()
        {
            var result = playerL.AVGAgeByClub();
            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("PSG", 35),
                new KeyValuePair<string, double>("Barcelona", 30)
            };
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void PlayersInAClubOrderedByRatingTest()
        {
            var result = playerL.PlayersInAClubOrderedByRating(2);
            var l = playerL.ReadAll().FirstOrDefault(x => x.Name == "Lewandowski");
            var g = playerL.ReadAll().FirstOrDefault(x => x.Name == "Gavi");
            var expected = new List<Player>();
            expected.Add(g);
            expected.Add(l);
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void TeamStatisticsTest()
        {
            var result = playerL.TeamStatistics().ToList();
            var expected = new List<TeamInfo>()
            {
                new TeamInfo()
                {
                    AvgRating = 20,
                    ClubName = "PSG",
                    PlayerNumber = 2
                },
                new TeamInfo()
                {
                    AvgRating = 15,
                    ClubName = "Barcelona",
                    PlayerNumber = 2
                }
            };

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void OwnersOfClubsTest()
        {
            var result = clubL.OwnersOfClubs();
            var expected = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>( "PSG","Gusztav"),
                new KeyValuePair<string, string>("Barcelona","Gellert")
            };
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void DefendersInAClubTest()
        {
            var result = playerL.DefendersInAClub();
            var expected = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("PSG", 0),
                new KeyValuePair<string, int>("Barcelona", 1),
            };
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void AttackersInAClubTest()
        {
            var result = playerL.AttackersInAClub();
            var expected = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("PSG", 2),
                new KeyValuePair<string, int>("Barcelona", 1),
            };
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void GetAverageRatePerTeamTest()
        {
            double? result = playerL.GetAverageRatePerTeam(2);
            double? expected = 15;
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void BestPlayerInAClubTest()
        {
            Player result = playerL.BestPlayerInAClub("Barcelona");
            Player expected = playerL.ReadAll()
                .FirstOrDefault(x => x.Name == "Gavi");
            Assert.That(result, Is.EqualTo(expected));
        }

    }
}
