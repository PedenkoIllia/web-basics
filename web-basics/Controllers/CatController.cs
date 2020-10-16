using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using web_basics.business.Domains;

namespace web_basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {
        CatService _catService;

        public CatController(IConfiguration configuration) 
        {
            _catService = new CatService(configuration);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cats = _catService.Get();
            return Ok(cats);
        }
    }
}
