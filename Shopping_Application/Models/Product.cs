using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Shopping_Application.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public double Price { get; set; }
        public string Photo { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }

    public class ProductDBContext : DbContext
    {
        public ProductDBContext()
        { }
        public DbSet<Product> Products { get; set; }
    }

}