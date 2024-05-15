using Microsoft.Data.SqlClient;
using OrderManagementSystem.Model;
using OrderManagementSystem.Constants;

namespace OrderManagementSystem.Repository
{
    internal class OrderManagementRepository:IOrderManagementRepository
    {

        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public OrderManagementRepository()
        {
            sqlConnection = new SqlConnection("Server=OBLIVIATE7;Database=Order_Management_System;Trusted_Connection=True");
            cmd = new SqlCommand();
        }
        public bool createOrder(User user, List<Product> products)
        {
            
           
            foreach (Product product in products)
            {
                cmd.CommandText = "INSERT INTO Order(productId,userId)VALUES(@userid,@productid)";
                cmd.Parameters.AddWithValue("@productid", product.ProductId);
                cmd.Parameters.AddWithValue("@userId", user.UserId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                cmd.ExecuteNonQuery();

            }
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;


        }
        public bool cancelOrder(int userId, int orderId)
        {
            cmd.CommandText = "DELETE FROM Order WHERE userId=@userid AND orderId=@orderid";
            cmd.Parameters.AddWithValue("@userid", userId);
            cmd.Parameters.AddWithValue("@orderid",orderId);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;

        }

        public bool createProduct(User user, Product product)
        {
            cmd.CommandText = "Insert INTO Product(productId,productName,description,price,quantityInstock,type,UserId)VALUES(@productid,@productname,@description,@price,@quantity,@type,@userid)";
            cmd.Parameters.AddWithValue("@productid",product.ProductId);
            cmd.Parameters.AddWithValue("@productname",product.ProductName);
            cmd.Parameters.AddWithValue("@description",product.Description);
            cmd.Parameters.AddWithValue("@price",product.Price);
            cmd.Parameters.AddWithValue("@quantity",product.QuantityInStock);
            cmd.Parameters.AddWithValue("@type", product.Type);
            cmd.Parameters.AddWithValue("@userid",user.UserId);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;

        }
        //public List<Product > getAllProducts()
        //{
        //    List<Product> products = new List<Product>();


        //    cmd.CommandText = "SELECT * FROM Product";
        //    cmd.Connection = sqlConnection;

        //    sqlConnection.Open();
        //    using (var reader = cmd.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            Product product = new Product();
        //            {

        //                ProductName= (string)reader["productName"],
        //                Description = (string)reader["description"],
        //                Price= (double)reader["price"],
        //                QuantityInStock = (string)reader["quantityInStock"],
        //                Type = (OrderManagementSystem.Constants.ProductType)reader["type"]


        //            };
        //            products.Add(product);
        //        }
        //    }
        //    return products;
        //}
        public List<Product> getOrderByUser(User user)
        {
            List<Product> products = new List<Product>();
            cmd.CommandText = "SELECT p.* FROM Product p INNER JOIN Order o ON p.productId = o.productId WHERE o.userId = @userId";
            cmd.Parameters.AddWithValue("@userId", user.UserId);
            cmd.Connection = sqlConnection;

            sqlConnection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product();
                    {
                        Console.WriteLine($"Product ID: {reader["productId"]}");
                        Console.WriteLine($"Product Name: {reader["productName"]}");
                        Console.WriteLine($"Description: {reader["description"]}");
                        Console.WriteLine($"Price: {reader["price"]}");
                        Console.WriteLine($"Quantity in Stock: {reader["quantityInStock"]}");
                        Console.WriteLine($"Type: {reader["type"]}");
                        Console.WriteLine();
                    }
                    products.Add(product);
                }
            }
            return products;
          

        }


    }
}

    
    

