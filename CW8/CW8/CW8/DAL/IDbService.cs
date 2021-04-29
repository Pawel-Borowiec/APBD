using CW8.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public int DeleteDoctor(Doctor doctor);
        public int UpdateDoctor(Doctor doctorm int Id);
    }
}
