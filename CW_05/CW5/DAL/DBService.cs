using CW5.Model;
using CW5.Requests;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CW5.DAL
{
    //TODO
    // Async do procedury i insertów do bazy
    public class DBService : IDBService
    {

        private IConfiguration _configuration;

        public DBService (IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //Dodanie z użyciem procedury
        public int AddWithProcedure(OrderRequest request)
        {
            using var con = new SqlConnection(_configuration.GetConnectionString("ProductionDb"));
            using var com = new SqlCommand("AddProductToWarehouse", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@IdProduct", request.IdProduct);
            com.Parameters.AddWithValue("@IdWarehouse", request.IdWarehouse);
            com.Parameters.AddWithValue("@Amount", request.Amount);
            com.Parameters.AddWithValue("@CreatedAt", request.CreateAt);

            con.Open();
            //DbTransaction dbTransaction = await con.BeginTransactionAsync();
            //com.Transaction = (SqlTransaction)dbTransaction;

            com.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        public int AddProducts(OrderRequest request)
        {
            
            // Sprawdzenie czy w bazie istnieje hurtowania i produkt o podanym Id. W sumie lepiej byłoby to zrobić po stronie bazy 
            List<Product> products = GetAllProducts().ToList();
            List<Warehouse> warehouses = getAllWarehouses().ToList();
            if(!(validateIdProductExistance(request.IdProduct,products) && validateIdWarehouseExistance(request.IdWarehouse, warehouses))){
                throw new Exception("Nie instnieje produkt badz hurtownia o takim id");
            }
            // Sprawdzenie czy w bazie istnieje Order z takim samym amount i Id product
            if (validateOrder(request).Equals(0))
            {
                throw new Exception("Nie ma zamówienia");
            }
            Order order = GetOrder(request);
            // Sprawdzenie czy dane zamówienie zostało już zrealizowane
            if (checkIsOrderRealized(order) != 0)
            {
                throw new Exception("Zadanie zostało już zrealizowane");
            }
            // Ustawienie FulfilledAt na dzień dzisiejszy w podanym zamówieniu
            UpdateFullfilledAt(order);
            // Dodanie nowego rekordu do tabeli Product_Warehouse
            return AddNewRecordInProductWarehouse(order, request, GetProduct(order.IdProduct, products));



        }
        public Product GetProduct(int id, List<Product> list)
        {
            foreach (Product x in list)
            {
                if (x.IdProduct.Equals(id))
                {
                    return x;
                }
            }
            return null;
        }
        public int AddNewRecordInProductWarehouse(Order order, OrderRequest orderRequest, Product product)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb"));
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "INSERT INTO Product_Warehouse (IdWarehouse,IdProduct,IdOrder,Amount,Price,CreatedAt)" +
                "VALUES (@IdWarehouse,@IdProduct,@IdOrder,@Amount,@Price,@CreatedAt);";
            com.Parameters.AddWithValue("@IdWarehouse", orderRequest.IdWarehouse);
            com.Parameters.AddWithValue("@IdProduct", order.IdProduct);
            com.Parameters.AddWithValue("@IdOrder", order.IdOrder);
            com.Parameters.AddWithValue("@Amount", order.Amount);
            com.Parameters.AddWithValue("@Price", (order.Amount*product.Price));
            com.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
            con.Open();
            com.ExecuteNonQuery();
            con.Dispose();

            return returnNewPrimaryKey();
        }
        public int returnNewPrimaryKey()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb"));
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "select top 1 IdProductWarehouse as Id from Product_Warehouse order by CreatedAt";
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            int id = int.Parse(dr["Id"].ToString());

            con.Dispose();
            return id;
        }
        public void UpdateFullfilledAt(Order order)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb"));
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "UPDATE \"Order\" SET" +
                " IdProduct = @IdProduct," +
                " Amount = @Amount," +
                " CreatedAt = @CreatedAt," +
                " FulfilledAt = @FulfilledAt" +
                " WHERE IdOrder = @IdOrder;";
            com.Parameters.AddWithValue("@Amount", order.Amount);
            com.Parameters.AddWithValue("@CreatedAt", order.CreateAt);
            com.Parameters.AddWithValue("@FulfilledAt", DateTime.Now);
            com.Parameters.AddWithValue("@IdOrder", order.IdOrder);
            com.Parameters.AddWithValue("@IdProduct", order.IdProduct);
            com.Connection = con;

            con.Open();

            com.ExecuteNonQuery();
            con.Dispose();
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

        public int checkIsOrderRealized(Order order)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb"));
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "SELECT COUNT(*) as result from dbo.Product_Warehouse WHERE idOrder=@Id";
            com.Parameters.AddWithValue("@Id", order.IdOrder);
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
            com.CommandText = "SELECT top 1 * FROM \"Order\" WHERE IdProduct = @Id and Amount = @Amount";
            com.Parameters.AddWithValue("@Id", request.IdProduct);
            com.Parameters.AddWithValue("@Amount", request.Amount);
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();

            Order order = new Order
                {
                    IdOrder = int.Parse(dr["IdOrder"].ToString()),
                    IdProduct = int.Parse(dr["IdProduct"].ToString()),
                    Amount = int.Parse(dr["Amount"].ToString()),
                    CreateAt = DateTime.Parse(dr["CreatedAt"].ToString())
                };

            return order;
        }
        //Sprawdzenie czy produkt o podanym id istnieje
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
        //Sprawdzenie czy hurtownia o podanym id istnieje
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
