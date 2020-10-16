using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using web_basics.business.Domains;
using web_basics.business.ViewModels;

namespace web_basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountsController(IConfiguration configuration)
        {
            _accountService = new AccountService(configuration);
        }

        [HttpGet]
        public IEnumerable<AccountViewModel> GetUsers()
        {
            return _accountService.Get();
        }

        [HttpPost]
        public IActionResult CreateUser(AccountViewModel model)
        {
            model = _accountService.Create(model);
            if (model != null)
                return Ok(model);
            else
                return BadRequest();
        }

        [HttpPut]
        public IActionResult ChangeUser([FromBody] AccountViewModel model)
        {
            model = _accountService.Update(model);
            if (model != null)
                return Ok(model);
            else
                return BadRequest();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            if (_accountService.Delete(id))
                return NoContent();
            else
                return BadRequest();
        }
    }
}
