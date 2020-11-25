
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace netzkern.MyBookstore.UI.Web.Mvc.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public decimal Price { get; set; }
        public string Photo { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }

}