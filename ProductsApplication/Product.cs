using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ProductsApplication
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public DateTime LastUpdateDateTimeStamp { get; set; }
        public static  List<Product> GetProducts()
        {
            var products = new List<Product>();
            using (var dbContext = new Product_DBContext())
            {
                var conn = new SqlConnection(App.Configuration.ConnectionString);
                conn.Open();
                DataSet dataset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("select * from dbo.Product", conn);
                adapter.Fill(dataset);
                conn.Close();              
                if (dataset.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in dataset.Tables[0].Rows)
                    {
                         var p = new Product
                        {
                            Id = (int)row["id"],
                            Name = row["Name"].ToString(),
                            Category = row["Category"].ToString(),
                            Price = decimal.Parse(row["Price"].ToString()),
                            LastUpdateDateTimeStamp = DateTime.Parse(row["LastUpdateDateTimeStamp"].ToString())
                        };
                        products.Add(p);
                    }
                }
                
            }
            return products;
        }
        public static int  AddProduct(CreateProduct createProduct)
        {
        using (var dbContext = new Product_DBContext())
            {
                var conn = new SqlConnection(App.Configuration.ConnectionString);
                conn.Open();
                SqlCommand command = new SqlCommand("insert into dbo.Product values (@Name, @Category,@Price,@date)", conn);
                command.Parameters.Add(new SqlParameter("Name", createProduct.Name));
                command.Parameters.Add(new SqlParameter("Category", createProduct.Category));
                command.Parameters.Add(new SqlParameter("Price", createProduct.Price));
                command.Parameters.Add(new SqlParameter("date", DateTime.UtcNow.ToString("MM-dd-yyyy")));
                var addedrecords= command.ExecuteNonQuery();
                conn.Close();
                return addedrecords;


            }
        }

        public static int DeleteProduct(string name)
        {
            using (var dbcontect= new Product_DBContext())
            {
                var conn = new SqlConnection(App.Configuration.ConnectionString);
                conn.Open();
                SqlCommand command = new SqlCommand("delete from dbo.Product where Name=@Name", conn);
                command.Parameters.Add(new SqlParameter("Name", name));
               var rowsAffected= command.ExecuteNonQuery();
                conn.Close();
                return rowsAffected;
                  
            }
        }


        public static int  UpdateProduct(UpdateProduct updateproduct)
        {
            using (var dbcontect = new Product_DBContext())
            {
                

                
                    var conn = new SqlConnection(App.Configuration.ConnectionString);
                    conn.Open();
                    SqlCommand command = new SqlCommand("update dbo.Product set Name=@Name, Price=@Price, Category=@Category where Id=@Id", conn);
                    command.Parameters.Add(new SqlParameter("Name", updateproduct.Name));
                    command.Parameters.Add(new SqlParameter("Price", updateproduct.Price));
                    command.Parameters.Add(new SqlParameter("Category", updateproduct.Category));
                    command.Parameters.Add(new SqlParameter("Id", updateproduct.Id));
                    var rowsAffected = command.ExecuteNonQuery();
                    conn.Close();
                    return rowsAffected;
                

            }
        }
    }


public class CreateProduct
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
    public class UpdateProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
