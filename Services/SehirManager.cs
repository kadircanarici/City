using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;


namespace Services
{
    public class SehirManager : ISehirService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;

        public SehirManager(IRepositoryManager manager, ILoggerService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        public Sehir CreateOneSehir(Sehir sehir)
        {
            _manager.Sehir.CreateOneSehir(sehir);
            _manager.Save();
            _logger.LogInfo($"{sehir.Id} {sehir.SehirAdi} {sehir.UlkeAdi} basarıyla eklendi");
            return sehir;
        }

        public void DeleteOneSehir(int id, bool trackChanges)
        {
            var entity = _manager
                .Sehir
                .GetOneSehirById(id, trackChanges);
            if (entity is null)
            {
                string message = $"{id} id'li sehir silmeye çalışılırken bulunamadı.";
                _logger.LogWarning(message);
                throw new Exception(message); 
            }
                

            _manager
                .Sehir
                .DeleteOneSehir(entity);
            _manager.Save();
            _logger.LogInfo($"{id} id'li sehir basarıyla silindi");
        }

        public IEnumerable<Sehir> GetAllSehirler(bool trackChanges)
        {
            return _manager
                .Sehir
                .GetAllSehirler(trackChanges);
        }

        public Sehir GetOneSehirById(int id, bool trackChanges)
        {
            return _manager
                .Sehir
                .GetOneSehirById(id, trackChanges);
        }

        public void UpdateOneSehir(int id, Sehir sehir, bool trackChanges)
        {
            var entity = _manager
                .Sehir
                .GetOneSehirById(id, trackChanges);
            if (entity is null)
            {
                string message = $"{id} id'li sehir bulunamadı.";
                _logger.LogWarning(message);
                throw new Exception(message);
            }
                
            if (sehir is null)
                throw new ArgumentNullException(nameof(sehir));

            entity.SehirAdi = sehir.SehirAdi;
            entity.UlkeAdi = sehir.UlkeAdi;
            _manager
                .Sehir
                .Update(entity);
            _manager.Save();
            _logger.LogInfo($"{id} {sehir.SehirAdi} {sehir.UlkeAdi} basarıyla güncellendi");
        }
    }
}
