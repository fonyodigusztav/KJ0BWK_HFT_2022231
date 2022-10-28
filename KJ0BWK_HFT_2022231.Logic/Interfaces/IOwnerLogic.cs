using KJ0BWK_HFT_2022231.Models;
using System.Linq;

namespace KJ0BWK_HFT_2022231.Logic
{
    public interface IOwnerLogic
    {
        void Create(Owner item);
        void Delete(int id);
        Owner Read(int id);
        IQueryable<Owner> ReadAll();
        void Update(Owner item);
    }
}