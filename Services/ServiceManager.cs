using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ISehirService> _sehirService;
        public ServiceManager(IRepositoryManager repositoryManager,ILoggerService logger)
        {
            _sehirService = new Lazy<ISehirService>(() => new SehirManager(repositoryManager,logger));
        }
        public ISehirService SehirService => _sehirService.Value;
    }
}
