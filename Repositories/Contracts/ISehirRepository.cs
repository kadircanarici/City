using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ISehirRepository : IRepositoryBase<Sehir>
    {
        IQueryable<Sehir> GetAllSehirler(bool trackChanges);
        Sehir GetOneSehirById(int id, bool trackChanges);
        void CreateOneSehir(Sehir sehir);
        void UpdateOneSehir(Sehir sehir);
        void DeleteOneSehir(Sehir sehir);
    }
}
