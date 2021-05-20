using CW8.DAL;
using CW8.DTO.Requests;
using CW8.Models;
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

        private readonly IDbService _service;


        public AccountsController(IDbService service)
        {
            _service = service;
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
        [HttpGet("users")]
        public IActionResult getAllUsers()
        {
            string g = null;
            g.ToLower();
            MyDbContext context = new MyDbContext();
            return Ok(context.Users.ToList());
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            SigningCredentials creds =_service.logUser(loginRequest);
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

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "https://localhost:44353",
                audience: "https://localhost:44353",
                claims: userclaim,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
                );

            //generate refresh token

            //keya 32 bity

            //login response z access tokenem



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
