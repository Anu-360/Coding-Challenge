using OrderManagementSystem.Model;
using OrderManagementSystem.Repository;
using OrderManagementSystem.Service;
using OrderManagementSystem.Constants;
using OrderManagementSystem.Utility;
using System.Linq.Expressions;
using OrderManagementSystem.Exceptions;


namespace OrderManagementSystem.OrderManagement
{
    internal class OrderManagementApp
    {
        readonly IOrderService orderService;
        public OrderManagementApp()
        {
            orderService = new OrderService();
        }


        public void Run()
        {
            Console.WriteLine("Welcome to the Order Management System!");
            while (true)
            {
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Create Product");
                Console.WriteLine("3. Cancel Order");
                Console.WriteLine("4. Get All Products");
                Console.WriteLine("5. Get Order by User");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an Operation: ");

                int userinput = Convert.ToInt32(Console.ReadLine());

                switch (userinput)
                {
                    case 1:
                        try
                        {

                            Console.WriteLine("Enter User Id:");
                            Console.WriteLine("Should start from 20");
                            int userid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter User Name:");
                            string username = Console.ReadLine();
                            Console.WriteLine("Enter Password: ");
                            string password = Console.ReadLine();
                            Console.WriteLine("Enter the role type");
                            string input = Console.ReadLine();
                            RoleType Roletype;
                            if (Enum.TryParse(input, true, out Roletype))
                            {
                                User user = new User(userid, username, password, Roletype);
                                List<Product> products = new List<Product>();
                                orderService.createOrder(user, products);
                                Console.WriteLine("Order Created Successfully!");
                            }
                        }
                        catch (OrderNotFoundException ex)
                        {
                            Console.WriteLine($"Order not found : {ex.Message}");
                        }


                        break;
                    case 2:
                        try
                        {

                            Console.WriteLine("Enter User Id:");
                            Console.WriteLine("Should start from 20");
                            int userid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Product Id:");
                            Console.WriteLine("Should start from 01");
                            int productid = Convert.ToInt32(Console.ReadLine());
                            orderService.cancelOrder(userid,productid);
                            
                        }
                        catch (OrderNotFoundException ex)
                        {
                            Console.WriteLine($"Order not found : {ex.Message}");
                        }

                        break;
                    case 3:
                        try
                        {

                            Console.WriteLine("Enter Product Id:");
                            Console.WriteLine("Should start from 01");
                            int productid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Product Name:");
                            string productname = Console.ReadLine();
                            Console.WriteLine("Enter product description: ");
                            string description = Console.ReadLine();
                            Console.WriteLine("Enter price:");
                            double price = Convert.ToDouble(Console.ReadLine());    
                            Console.WriteLine("Enter quantity in stock:");
                            int quantity= Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the user id");
                            int userid= Convert.ToInt32(Console.ReadLine());
                           
                               
                                User user = new User();
                                Product product = new Product();
                                orderService.createProduct(user,product);
                                Console.WriteLine("Product Created Successfully!");
                            
                        }
                        catch (OrderNotFoundException ex)
                        {
                            Console.WriteLine($"Order not found : {ex.Message}");
                        }
                        break;
                    case 4:

                        //List<Product> allProducts = orderService.GetAllProducts();
                        //foreach (Product product in allProducts)
                        //{
                        //    Console.WriteLine($"{product.ProductId}: {product.ProductName}\n{product.Description}\n ${product.Price}\n{product.QuantityInStock} in stock \nType: {product.Type}");
                        //}
                        //break;
                    case 5:
                        try
                        {
                            Console.WriteLine("Enter User Id:");
                            Console.WriteLine("Should start from 20");
                            int userId = Convert.ToInt32(Console.ReadLine());

                            User user = new User() { UserId = userId };
                            orderService.getOrderByUser(user);
                        }
                        catch(UserNotFoundException ex)
                        {
                            Console.WriteLine($"User id invalid {ex.Message}");
                        }
                        break;

                       
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Thank You for Visiting!");
                        break;
                }
            }


        }
    }
}

    
    

