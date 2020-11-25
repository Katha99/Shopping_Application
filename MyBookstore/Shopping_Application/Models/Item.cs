
// Model for the items in the shopping cart

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace netzkern.MyBookstore.UI.Web.Mvc.Models
{
    public class Item
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}