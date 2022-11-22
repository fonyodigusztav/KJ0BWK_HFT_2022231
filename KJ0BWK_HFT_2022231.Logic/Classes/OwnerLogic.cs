using KJ0BWK_HFT_2022231.Models;
using KJ0BWK_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJ0BWK_HFT_2022231.Logic
{
    public class OwnerLogic : IOwnerLogic
    {
        IRepository<Owner> repo;

        public OwnerLogic(IRepository<Owner> repo)
        {
            this.repo = repo;
        }

        public void Create(Owner item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Owner Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Owner> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Owner item)
        {
            this.repo.Update(item);
        }
        public IEnumerable<KeyValuePair<string, ICollection<Club>>> asd()
        {
            return repo.ReadAll()
                .Where(t => t.Clubs.Count() >= 2)
                .Select(t => new KeyValuePair<string, ICollection<Club>>
                (t.Name, t.Clubs));
        }
        //public IEnumerable<KeyValuePair<string, double>> AVGAgeByClub()
        //{
        //    return from x in repo.ReadAll()
        //           group x by x.Club.Name into g
        //           select new KeyValuePair<string, double>
        //           (g.Key, g.Average(t => t.Age));
        //}

        //public IEnumerable<Player> PlayersInAClubOrderedByRating(string clubName)
        //{
        //    return repo.ReadAll().Where(t => t.Club.Name == clubName)
        //        .OrderByDescending(t => t.Rating)
        //        .Select(t => t);
        //}
    }
}
