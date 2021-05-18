using CW8.DTO.Requests;
using CW8.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW8.DAL
{
    public interface IDbService
    {
        public IEnumerable<Doctor> GetDoctors();
        public int AddDoctor(Doctor doctor);
        public int DeleteDoctor(int Id);
        public int UpdateDoctor(Doctor doctor);
        public Prescription GetPrescription(int Id);
        public SigningCredentials logUser(LoginRequest request);
    }
}
