using CW8.DTO;
using CW8.Helpers;
using CW8.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CW8.DAL
{

    public class DbService : IDbService
    {
        public readonly IConfiguration _configuration;
        private readonly MyDbContext _context = new MyDbContext();

        public DbService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int AddDoctor(Doctor doctor)
        {
            _context.Doctors.AddAsync(doctor);
            _context.SaveChangesAsync();
            return 0;
        }

        public int DeleteDoctor(int Id)
        {
            _context.Doctors.Remove(_context.Doctors.Where(x => x.IdDoctor==Id).FirstOrDefault());
            _context.SaveChangesAsync();
            return 0;
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _context.Doctors.ToList();
        }

        public Prescription GetPrescription(int Id)
        {
            Prescription prescription = _context.Prescriptions.Where(x => x.IdPrescription == Id).FirstOrDefault();
            prescription.Doctor = _context.Doctors.Where(x => x.IdDoctor == prescription.IdDoctor).FirstOrDefault();
            prescription.Patient = _context.Patients.Where(x => x.IdPatient == prescription.IdPatient).FirstOrDefault();
            return prescription;
        }

        public int UpdateDoctor(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChangesAsync();
            return 0;
        }

        public SigningCredentials logUser(LoginRequest request)
        {
            CheckPassword(request);

            

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return creds;

            
        }

        private void CheckPassword(LoginRequest request)
        {
            if(_context.Users.Where(x => x.Login.Equals(request.Login)).Count() == 0)
            {
                throw new Exception("There is no user with that nickname in database");
            }
            var user = _context.Users.Where(x => x.Login.Equals(request.Login)).FirstOrDefault();
            if (!user.Password.Equals(request.Password))
            {
                throw new Exception("Wrong Password");
            }
        }

        public void registerUser(RegisterRequest model)
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
        }

        public SymmetricSecurityKey getSSKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
        }

        public void handleRefreshToken(User user)
        {
            user.RefreshToken = SecurityHelpers.GenerateRefreshToken();
            user.RefreshTokenExp = DateTime.Now.AddDays(1);
            _context.SaveChanges();

        }

        public string getLoginFromToken(string token)
        {
            return SecurityHelpers.GetUserIdFromAccessToken(token.Replace("Bearer ", ""), _configuration["SecretKey"]);
        }

        public User validateLoginRequest(LoginRequest loginRequest)
        {
            User user = _context.Users.Where(u => u.Login == loginRequest.Login).FirstOrDefault();

            string passwordHas = user.Password;
            string curHashedPassword = SecurityHelpers.GetHashedPasswordWithSalt(loginRequest.Password, user.Salt);

            if (!passwordHas.Equals(curHashedPassword))
            {
                throw new Exception($"User {loginRequest.Login}, has entered incorrect password");
            }
            return user;
        }

        public User validateRefreshToken(RefreshTokenRequest refreshToken)
        {
            User user = _context.Users.Where(u => u.RefreshToken == refreshToken.RefreshToken).FirstOrDefault();
            if (user == null)
            {
                throw new SecurityTokenException("Invalid refresh token");
            }

            if (user.RefreshTokenExp < DateTime.Now)
            {
                throw new SecurityTokenException("Refresh token expired");
            }

            return user;
        }
    }
}
