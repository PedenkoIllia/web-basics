using Microsoft.AspNetCore.Mvc;
using web_basics.business.Domains;
using web_basics.business.ViewModels;

namespace web_basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        DogService _service;

        public DogController(DogService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dogs = _service.Get();
            return Ok(dogs);
        }

        [HttpPost]
        public IActionResult CreateDog([FromBody] DogViewModel dogModel)
        {
            int id = _service.Add(dogModel);
            if (id > 0)
            {
                dogModel.Id = id;
                return Ok(dogModel);
            }
            else
                return BadRequest();
        }
    }
}
