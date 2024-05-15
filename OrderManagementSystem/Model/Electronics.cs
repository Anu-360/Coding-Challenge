using OrderManagementSystem.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Model
{
    internal class Electronics : Product
    {
        string brand;
        int warrantyPeriod;

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public int Warrantyperiod
        {
            get { return warrantyPeriod; }
            set { warrantyPeriod = value; }
        }

        public Electronics(string brand,int warrantyperiod,string productname, string description, double price, int quantityInStock, ProductType type) : base(productname, description, price, quantityInStock, type)
        {
            Brand= brand;
            Warrantyperiod= warrantyperiod;
        }
    }
}
