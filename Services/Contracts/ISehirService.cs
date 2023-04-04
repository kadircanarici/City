using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISehirService
    {
        IEnumerable<Sehir> GetAllSehirler(bool trackChanges);
        Sehir GetOneSehirById(int id, bool trackChanges);
        Sehir CreateOneSehir(Sehir sehir);
        void UpdateOneSehir(int id, Sehir sehir, bool trackChanges);
        void DeleteOneSehir(int id, bool trackChanges);
    }
}
