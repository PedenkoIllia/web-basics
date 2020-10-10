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
            if (_service.Add(dogModel))
                return Ok();
            else
                return BadRequest();
        }
    }
}
