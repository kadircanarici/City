using City.MVC.Models;

namespace City.MVC.Services.Abstracts
{
    public interface ISehirService
    {
        Task<List<Sehir>> GetAllSehirler();
        Task<Sehir> GetOneSehir(int id);
        Task<Sehir> CreateOneSehir(Sehir sehir);
        Task<Sehir> UpdateOneSehir(int id, SehirDto sehirDto);
        Task<int> DeleteOneSehir(int id);
    }
}
