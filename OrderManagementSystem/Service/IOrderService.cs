using OrderManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Service
{
    internal interface IOrderService
    {
        bool createOrder(User user, List<Product> products);
        bool cancelOrder(int userId, int orderId);
        bool createProduct(User user, Product product);

        //List<Product> getAllProducts();
        List<Product> getOrderByUser(User user);
    }
}
