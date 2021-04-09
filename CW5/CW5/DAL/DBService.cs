using CW5.Model;
using CW5.Requests;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CW5.DAL
{
    public class DBService : IDBService
    {

        private IConfiguration _configuration;

        public DBService (IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public int AddProducts(OrderRequest request)
        {
            List<Product> products = GetAllProducts().ToList();
            List<Warehouse> warehouses = getAllWarehouses().ToList();
            if(!(validateIdProductExistance(request.IdProduct,products) && validateIdWarehouseExistance(request.IdWarehouse, warehouses))){
                return 2;
            }
            if (validateOrder(request).Equals(0))
            {
                return 3;
            }
            Order order = GetOrder(request);

            return 1;



        }

        public Boolean isOrderExecuted(OrderRequest request)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb"));
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "SELECT * FROM Product_Warehouse WHERE IdOrder = @IdOrder";
            //com.Parameters.AddWithValue("@IdOrder", request.IdOrder);
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            int count = int.Parse(dr["Result"].ToString());

            con.Dispose();
            return true;
        }
        public int validateOrder(OrderRequest request)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb"));
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "SELECT COUNT(*) as Result FROM \"Order\" WHERE IdProduct = @Id and Amount = @Amount";
            com.Parameters.AddWithValue("@Id", request.IdProduct);
            com.Parameters.AddWithValue("@Amount", request.Amount);
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            int count = int.Parse(dr["Result"].ToString());
            
            con.Dispose();
            return count;
        }
        public Order GetOrder(OrderRequest request)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb"));
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "SELECT * as Result FROM \"Order\" WHERE IdProduct = @Id and Amount = @Amount";
            com.Parameters.AddWithValue("@Id", request.IdProduct);
            com.Parameters.AddWithValue("@Amount", request.Amount);
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();

            Order order = new Order
                {
                    IdOrder = int.Parse(dr["IdOrder"].ToString()),
                    IdProduct = int.Parse(dr["IdProduct"].ToString()),
                    Amount = int.Parse(dr["Amount"].ToString()),
                    CreateAt = DateTime.Parse(dr["CreateAt"].ToString())
                };

            return order;
        }
        public Boolean validateIdProductExistance(int id, List<Product> list)
        {
            foreach (Product x in list)
            {
                if (x.IdProduct.Equals(id))
                {
                    return true;
                }
            }
            return false;
        }
        public Boolean validateIdWarehouseExistance(int id, List<Warehouse> list)
        {
            foreach (Warehouse x in list)
            {
                if (x.IdWarehouse.Equals(id))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb"));
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "SELECT * FROM dbo.Product";
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            var list = new List<Product>();
            while (dr.Read())
            {
                list.Add(new Product
                {
                    IdProduct = int.Parse(dr["IdProduct"].ToString()),
                    Name = dr["Name"].ToString(),
                    Description = dr["Description"].ToString(),
                    Price = double.Parse(dr["Price"].ToString())
                }) ;
            }

            con.Dispose();
            return list;
        }

        public IEnumerable<Warehouse> getAllWarehouses()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb"));
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "SELECT * FROM dbo.Warehouse";
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            var list = new List<Warehouse>();
            while (dr.Read())
            {
                list.Add(new Warehouse
                {
                    IdWarehouse = int.Parse(dr["IdWarehouse"].ToString()),
                    Name = dr["Name"].ToString(),
                    Address = dr["Address"].ToString()
                });
            }

            con.Dispose();
            return list;
        }
    }
}
