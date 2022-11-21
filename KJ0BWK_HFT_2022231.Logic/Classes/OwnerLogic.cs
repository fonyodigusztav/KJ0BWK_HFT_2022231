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
        
    }
}
