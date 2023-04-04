using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<ISehirRepository> _sehirRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _sehirRepository=new Lazy<ISehirRepository>(()=>new SehirRepository(_context));
        }

        public ISehirRepository Sehir => _sehirRepository.Value;

        public void Save() =>
            _context.SaveChanges();
    }
}
