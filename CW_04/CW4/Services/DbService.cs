using CW4.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CW4.Services
{
    
    public class DbService : IDBService
    {
        private IConfiguration _configuration;

        public DbService (IConfiguration configuration)
        {
            _configuration = configuration;
        }
 

        public int AddAnimal(Animal animal)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb"));
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "INSERT INTO Animal (Name, Description, Category, Area) VALUES(@Name,@Description,@Category,@Area); ";
            com.Parameters.AddWithValue("@Name", animal.Name);
            com.Parameters.AddWithValue("@Description", animal.Description);
            com.Parameters.AddWithValue("@Category", animal.Category);
            com.Parameters.AddWithValue("@Area", animal.Area);
            con.Open();
            com.ExecuteNonQuery();
            con.Dispose();
            return 1;
        }

        public int DeleteAnimal(int Id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb"));
            SqlCommand com = new SqlCommand();


            com.CommandText = "DELETE FROM Animal where IdAnimal=" + Id;
            com.Connection = con;

            con.Open();

            com.ExecuteNonQuery();
            con.Dispose();
            return 1;
        }

        public IEnumerable<Animal> GetAnimals(string orderBy)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb"));
            SqlCommand com = new SqlCommand();


            com.CommandText = "SELECT * FROM Animal order by " + orderBy;
            //com.Parameters.AddWithValue("@orderBy", orderBy);
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
            return list;
        }

        public int UpdateAnimal(Animal animal, int Id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb"));
            SqlCommand com = new SqlCommand();


            com.CommandText = "UPDATE Animal SET Name = @Name, Description = @Description, Category = @Category, Area = @Area WHERE IdAnimal = @Id; ";
            com.Parameters.AddWithValue("@Name", animal.Name);
            com.Parameters.AddWithValue("@Description", animal.Description);
            com.Parameters.AddWithValue("@Category", animal.Category);
            com.Parameters.AddWithValue("@Area", animal.Area);
            com.Parameters.AddWithValue("@Id", Id);
            com.Connection = con;

            con.Open();

            com.ExecuteNonQuery();
            con.Dispose();
            return 1;
        }
    }
}
