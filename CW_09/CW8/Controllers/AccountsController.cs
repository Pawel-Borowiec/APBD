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
            MyDbContext context = new MyDbContext();
            User user = context.Users.Where(u => u.Login == loginRequest.Login).FirstOrDefault();

            string passwordHas = user.Password;
            string curHashedPassword = SecurityHelpers.GetHashedPasswordWithSalt(loginRequest.Password, user.Salt);

            if (!passwordHas.Equals(curHashedPassword))
            {
                throw new Exception($"User {loginRequest.Login}, has entered incorrect password");
            }

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
            MyDbContext _context = new MyDbContext();
            User user = _context.Users.Where(u => u.RefreshToken == refreshToken.RefreshToken).FirstOrDefault();
            if (user == null)
            {
                throw new SecurityTokenException("Invalid refresh token");
            }

            if (user.RefreshTokenExp < DateTime.Now)
            {
                throw new SecurityTokenException("Refresh token expired");
            }

            var login = _service.getLoginFromToken(token);

            Claim[] userclaim = new[] {
                    new Claim(ClaimTypes.Name, "pgago"),
                    new Claim(ClaimTypes.Role, "user"),
                    new Claim(ClaimTypes.Role, "admin")
                };

            SymmetricSecurityKey key = _service.getSSKey();

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtToken = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: userclaim,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
            );

            user.RefreshToken = SecurityHelpers.GenerateRefreshToken();
            user.RefreshTokenExp = DateTime.Now.AddDays(1);
            _context.SaveChanges();

            return Ok(new
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                refreshToken = user.RefreshToken
            });

        }
    }
}

/*
 * SigningCredentials creds =_service.logUser(loginRequest);
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


/////////////////////
///
private readonly MyDbContext _context;
        private readonly IConfiguration _configuration;


        public AccountsController(MyDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult RegisterStudent(RegisterRequest model)
        {
            var hashedPasswordAndSalt = SecurityHelpers.GetHashedPasswordAndSalt(model.Password);

            var user = new User()
            {
                Email = model.Email,
                Login = model.Login,
                Password = hashedPasswordAndSalt.Item1,
                Salt = hashedPasswordAndSalt.Item2,
                RefreshToken = SecurityHelpers.GenerateRefreshToken(),
                RefreshTokenExp = DateTime.Now.AddDays(1)
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(@"Zapisano zawodnika o nicku {user.Login}");
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
            MyDbContext context = new MyDbContext();
            User user = context.Users.Where(u => u.Login == loginRequest.Login).FirstOrDefault();

            string passwordHas = user.Password;
            string curHashedPassword = "";

              //  if(passwordHas != curHashedPassword)
               // {
                //    return Unauthorized();
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
                issuer: "https://localhost:44353",
                audience: "https://localhost:44353",
                claims: userclaim,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
                );

                //refresh token

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                refreshToken = "refresh_token"
            });

        }
 */
