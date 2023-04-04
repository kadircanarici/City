using Repositories.EFCore;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.Contracts;

namespace City.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SehirlerController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public SehirlerController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllSehirler()
        {
            try
            {
                var sehirler = _manager
                    .SehirService
                    .GetAllSehirler(false);

                return Ok(sehirler);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneSehir([FromRoute(Name="id")] int id)
        {
            try
            {
                var sehir = _manager
               .SehirService
               .GetOneSehirById(id, false);
               

                if (sehir is null)
                    return NotFound(); //404

                return Ok(sehir);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }    
        }

        [HttpPost]
        public IActionResult CreateOneSehir([FromBody]Sehir sehir)
        {
            try
            {
                if (sehir is null)
                    return BadRequest(); //400

                _manager
                    .SehirService
                    .CreateOneSehir(sehir);

                return StatusCode(201, sehir);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneSehir([FromRoute(Name ="id")] int id, [FromBody] Sehir sehir )
        {
            try
            {
                if (sehir is null)
                    return BadRequest(); //400

                _manager
                    .SehirService
                    .UpdateOneSehir(id, sehir, true);

                return NoContent(); //204
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneSehir([FromRoute(Name = "id")] int id)
        {
            try
            {
                _manager
                    .SehirService
                    .DeleteOneSehir(id,false);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
