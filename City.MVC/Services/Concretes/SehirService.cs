using City.MVC.Models;
using City.MVC.Services.Abstracts;

namespace City.MVC.Services.Concretes
{
    public class SehirService: ISehirService
    {
        private readonly IHttpService httpService;

        public SehirService(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<Sehir> CreateOneSehir(Sehir sehir)
        {
            try
            {
                var result = await httpService.Post<List<Sehir>>("Sehirler", sehir);

                return sehir;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Sehir>> GetAllSehirler()
        {
            try
            {
                var result = await httpService.Get<List<Sehir>>("Sehirler");
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Sehir> GetOneSehir(int id)
        {
            try
            {
                var result = await httpService.Get<Sehir>($"Sehirler/{id}");
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> DeleteOneSehir(int id)
        {
            try
            {
                var result = await httpService.Delete<int>($"Sehirler/{id}");
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Sehir> UpdateOneSehir(int id, SehirDto sehirDto)
        {
            try
            {
                var result = await httpService.Put<Sehir>($"Sehirler/{id}",sehirDto);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
