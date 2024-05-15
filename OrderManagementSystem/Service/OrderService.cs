using Microsoft.Data.SqlClient;
using OrderManagementSystem.Model;
using OrderManagementSystem.Repository;


namespace OrderManagementSystem.Service
{
    internal class OrderService:IOrderService
    {
        readonly IOrderManagementRepository repository;
        public OrderService()
        {
            repository = new OrderManagementRepository();
        }

        public bool createOrder(User user, List<Product> products)
        {
           
            bool newOrder = repository.createOrder(user, products);
            if (newOrder )
            {
                Console.WriteLine("Order created successfully!");
            }
            else
            {
                throw new Exception("Order creation failed!");
            }
            return newOrder;
        }

        public bool cancelOrder(int userId, int orderId)
        {
            bool cancel=repository.cancelOrder(userId, orderId);
            if (cancel)
            {
                Console.WriteLine("Order Cancelled Successfully!");
            }
            else
            {
                throw new Exception("Order cannot be cancelled");
            }
            return cancel;
        }
        public bool createProduct(User user, Product product)
        {
            bool newproduct=repository.createProduct(user, product);
            if (true)
            {
                Console.WriteLine("Product created Successfully!");
            }
            else
            {
                throw new Exception("Invalid input data");
            }
            return newproduct;  
        }
        //public List<Product> getAllProducts()
        //{
        //    if (true)
        //    {
        //        Console.WriteLine("All the products");
        //    }
        //    else
        //    {
        //        throw new Exception("Product not found!");
        //    }
        //    return repository.getAllProducts();
        //}
        public List<Product> getOrderByUser(User user)
        {
            List<Product> orderedProducts = repository.getOrderByUser(user);

            if (orderedProducts.Count > 0)
            {
                Console.WriteLine("Products ordered by user:");
               
            }
            else
            {
                Console.WriteLine("No products ordered by the user");
            }
            return orderedProducts;
        }
    }





    }

