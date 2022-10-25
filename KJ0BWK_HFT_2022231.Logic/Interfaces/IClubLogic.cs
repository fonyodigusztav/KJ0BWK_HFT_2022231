using KJ0BWK_HFT_2022231.Models;
using System.Linq;

namespace KJ0BWK_HFT_2022231.Logic
{
    interface IClubLogic
    {
        void Create(Club item);
        void Delete(int id);
        Club Read(int id);
        IQueryable<Club> ReadAll();
        void Update(Club item);
    }
}