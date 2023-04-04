using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class SehirRepository : RepositoryBase<Sehir>, ISehirRepository
    {
        public SehirRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneSehir(Sehir sehir) => Create(sehir);
        public void DeleteOneSehir(Sehir sehir) => Delete(sehir);
        public IQueryable<Sehir> GetAllSehirler(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(s=>s.Id);
        public Sehir GetOneSehirById(int id, bool trackChanges) =>
            FindByCondition(s => s.Id.Equals(id), trackChanges).SingleOrDefault();
        public void UpdateOneSehir(Sehir sehir) => Update(sehir);
    }
}
