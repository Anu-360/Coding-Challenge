using OrderManagementSystem.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Model
{
    internal class Clothing:Product
    {
        string size;
        string color;

        public string Size
        {
            get { return size; }
            set { size = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public Clothing(string size,string color, string productname, string description, double price, int quantityInStock, ProductType type) :base(productname,description,price,quantityInStock,type)
        { 
            Size = size;
            Color = color;
        }
    }
}
