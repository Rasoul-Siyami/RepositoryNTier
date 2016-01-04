using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matrix.Company.DomainClasses
{
    public class Product
    {
        public Product(string productNumber, string name, decimal price)
        {
            Name = name;
            Price = price;
            ProductNumber = productNumber;
        }

        public string ProductNumber { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}