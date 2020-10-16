using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using web_basics.business.Domains;
using web_basics.business.ViewModels;

namespace web_basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private CatService _catService;
        private OwnerService _ownerService;

        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public OwnerController(IConfiguration configuration)
        {
            _catService = new CatService(configuration);
            _ownerService = new OwnerService(configuration);
        }

        [HttpGet]
        [Authorize (Roles = "User")]
        public IActionResult GetPets()
        {
            if (!_ownerService.Get().Any(owner => owner.UserId == UserId))
            {
                return Ok(Enumerable.Empty<CatViewModel>());
            }

            var catsOwner = _ownerService.Get().Where(owner => owner.UserId == UserId);
            var cats = _catService.Get().Where(cat => catsOwner.Any(owner => owner.CatId == cat.Id));

            return Ok(cats);
        }
    }
}
