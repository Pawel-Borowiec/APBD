using CW4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CW4.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        const string ConString = "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s18986;Integrated Security=True";

        [HttpGet]
        public IActionResult GetAnimals(string orderBy = "name")
        {

            SqlConnection con = new SqlConnection(ConString);
            SqlCommand com = new SqlCommand();


            com.CommandText = "SELECT * FROM Animal order by " + orderBy;
            com.Connection = con;

            con.Open();

            SqlDataReader dr = com.ExecuteReader();
            var list = new List<Animal>();

            while (dr.Read())
            {
                list.Add(new Animal
                {
                    Name = dr["Name"].ToString(),
                    Description = dr["Description"].ToString(),
                    Category = dr["Category"].ToString(),
                    Area = dr["Area"].ToString()
                });
            }

            con.Dispose();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult AddAnimal(Animal animal)
        {
            SqlConnection con = new SqlConnection(ConString);
            SqlCommand com = new SqlCommand();

            com.CommandText = "INSERT INTO Animal (Name, Description, Category, Area) VALUES('"+animal.Name+ "', '" + animal.Description + "', '" + animal.Category + "', '" + animal.Area + "'); ";
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateAnimal()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteAnimal()
        {
            return Ok();
        }
    }
}
