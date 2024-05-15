using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementSystem.Constants;

namespace OrderManagementSystem.Model
{
    internal class Product
    {
        static int  productId=01;
        string productName;
        string description;
        double price;
        int quantityInStock;
        ProductType type;

        public int ProductId
        {
            get { return productId; }
            private set { productId = value; }
        }
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public int QuantityInStock
        {
            get { return quantityInStock; }
            set { quantityInStock = value; }
        }
        public ProductType Type
        {
            get { return type; }
            set { type = value; }
        }

        public Product()
        {

        }
        public Product(string productname,string description,double price, int quantityInStock, ProductType type)
        {
            productId++;
            ProductId=productId;
            ProductName=productname;
            Description=description;
            Price=price;
            QuantityInStock=quantityInStock;
            Type=type;
        }
    }
}
