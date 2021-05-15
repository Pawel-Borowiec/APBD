using CW8.DTO.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CW8.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly IConfiguration _configuration;


        public AccountsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok("Private");
        }
        [AllowAnonymous]
        [HttpGet("anon")]
        public IActionResult GetAnonData()
        {
            return Ok("Public");
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            //AppUser user = .context.Users.Tolist.First();
            // if(user==null)
            // return NotFound();
            // }

            Claim[] userclaim = new[]
            {
                new Claim(ClaimTypes.Name, "test"),
                new Claim(ClaimTypes.Role, "user"),
                new Claim(ClaimTypes.Role, "admin"),
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "https://localhost:5000",
                audience: "https://localhost:5000",
                claims: userclaim,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
                );
            // tu powinien być refresh token
            // 54 minuta
            return Ok(new
                {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                refreshToken = "refresh_token"
                });
        }
    }
}
