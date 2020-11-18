using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
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
