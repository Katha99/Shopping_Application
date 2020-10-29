using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopping_Application.Models
{
    public class ProductModel
    {
        private List<Product> products;

        public ProductModel()
        {
            this.products = new List<Product>()
            {
                new Product
                {
                    Id = "1",
                    Name = "Product1",
                    Price = 10,
                    Photo = "product1.jpg"
                },
                new Product
                {
                    Id = "2",
                    Name = "Product2",
                    Price = 20,
                    Photo = "product2.jpg"
                },
                new Product
                {
                    Id = "3",
                    Name = "Product3",
                    Price = 15,
                    Photo = "product3.jpg"
                }
            };
        }

        public List<Product> findAll()
        {
            return this.products;
        }

        public Product find(string id)
        {
            return this.products.Single(p => p.Id.Equals(id));
        }
    }
}