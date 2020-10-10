using Microsoft.AspNetCore.Mvc;
using web_basics.business.Domains;

namespace web_basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {
        CatService _service;

        public CatController(CatService service) 
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cats = _service.Get();
            return Ok(cats);
        }
    }
}
