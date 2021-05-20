using CW8.DAL;
using CW8.DTO;
using CW8.Helpers;
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
    [Authorize]
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private IDbService _service;

        public AccountsController(IDbService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok("Ta końcówka wymaga uwierzytelnienia");
        }

        [AllowAnonymous]
        [HttpGet("anon")]
        public IActionResult GetAnonData()
        {
            return Ok("Jest to końcówka, która nie wymaga uwierzytelnienia");
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult RegisterStudent(RegisterRequest model)
        {
            _service.registerUser(model);

            return Ok($"Zapisano zawodnika o nicku {model.Login}");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            User user = _service.validateLoginRequest(loginRequest);

            Claim[] userclaim = new[]
            {
                new Claim(ClaimTypes.Name, "test"),
                new Claim(ClaimTypes.Role, "user"),
                new Claim(ClaimTypes.Role, "admin"),
            };

            SymmetricSecurityKey key = _service.getSSKey();
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "https://localhost:44353",
                audience: "https://localhost:44353",
                claims: userclaim,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
                );

            _service.handleRefreshToken(user);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                refreshToken = user.RefreshToken
            });
        }
        [AllowAnonymous]
        [HttpPost("refresh")]
        public IActionResult Refresh([FromHeader(Name = "Authorization")] string token, RefreshTokenRequest refreshToken)
        {
            User user = _service.validateRefreshToken(refreshToken);
            var login = _service.getLoginFromToken(token);

            Claim[] userclaim = new[] {
                    new Claim(ClaimTypes.Name, "test"),
                    new Claim(ClaimTypes.Role, "user"),
                    new Claim(ClaimTypes.Role, "admin")
                };

            SymmetricSecurityKey key = _service.getSSKey();

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtToken = new JwtSecurityToken(
                issuer: "https://localhost:44353",
                audience: "https://localhost:44353",
                claims: userclaim,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
            );

            _service.handleRefreshToken(user);

            return Ok(new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                refreshToken = user.RefreshToken
            });

        }
    }
}