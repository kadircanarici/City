using City.MVC.Models;
using City.MVC.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace City.MVC.Controllers
{
    public class SehirlerController : Controller
    {
        private readonly ISehirService sehirService;

        public SehirlerController(ISehirService sehirService)
        {
            this.sehirService = sehirService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllSehirler()
        {
            var sehirler = sehirService.GetAllSehirler().Result;
            return Json(new { data= sehirler });
        }
        public IActionResult CreateOneSehir(Sehir sehir)
        {
            sehirService.CreateOneSehir(sehir);
            return Json(sehir);
        }
        public IActionResult GetOneSehir(int id)
        {
            var sehir = sehirService.GetOneSehir(id).Result;
            return Json(sehir);
        }
        public IActionResult UpdateOneSehir(int id, SehirDto sehirDto)
        {
            SehirDto entity = new SehirDto(); //= sehirService.GetOneSehir(id).Result;
            //entity.Id = 0;
            entity.SehirAdi = sehirDto.SehirAdi;
            entity.UlkeAdi = sehirDto.UlkeAdi;

            sehirService.UpdateOneSehir(id,entity);
            return Json(entity);


        }
        public IActionResult DeleteOneSehir(int id)
        {
            var result = sehirService.DeleteOneSehir(id).Result;
            return Json(result);
        }
    }
}
