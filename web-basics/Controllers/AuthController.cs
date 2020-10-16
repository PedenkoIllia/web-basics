using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using web_basics.business.Domains;
using web_basics.business.ViewModels;
using web_basics.Common;

namespace web_basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        AccountService _accountService;
        private readonly IOptions<AuthOptions> AuthOptions;

        public AuthController(IConfiguration configuration, IOptions<AuthOptions> authOptions)
        {
            _accountService = new AccountService(configuration);
            AuthOptions = authOptions;
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginViewModel request)
        {
            var user = AuthenticateUser(request.Email, request.Password);

            if (user != null)
            {
                var token = GenerateJWT(user);

                return Ok(new
                {
                    access_token = token
                });
            }

            return Unauthorized();
        }

        public AccountViewModel AuthenticateUser(string email, string password)
        {
            return _accountService.Get().SingleOrDefault(user => user.Email == email && user.Password == password);
        }

        private string GenerateJWT(AccountViewModel user)
        {
            var authParam = this.AuthOptions.Value;

            var securityKey = authParam.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim("role", user.Role.ToString())
            };

            var token = new JwtSecurityToken(
                authParam.Issuer,
                authParam.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParam.TokenLifetime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
