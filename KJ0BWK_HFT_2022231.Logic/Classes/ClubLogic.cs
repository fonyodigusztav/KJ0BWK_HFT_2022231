using KJ0BWK_HFT_2022231.Models;
using KJ0BWK_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJ0BWK_HFT_2022231.Logic
{
    public class ClubLogic : IClubLogic
    {
        IRepository<Club> repo;

        public ClubLogic(IRepository<Club> repo)
        {
            this.repo = repo;
        }

        public void Create(Club item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if (item.Name == null ||
                item.Championship == null)
            {
                throw new ArgumentException(
                                    "Please set all input datas correctly"
                                );
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Club Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Club> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Club item)
        {
            this.repo.Update(item);
        }
    }
}
