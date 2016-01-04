using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matrix.Company.DomainClasses
{
    public class Products : List<Product>
    {
        public object Name;

        public Products()
        {
            this.Add(new Product("D123", "Super Fast Bike", 1000M));
            this.Add(new Product("A356", "Durable Helmet", 123.45M));
            this.Add(new Product("M924", "Soft Bike Seat", 34.99M));
            this.Add(new Product("M9d4", "Soft re Seat", 36.99M));
        }
    }
}