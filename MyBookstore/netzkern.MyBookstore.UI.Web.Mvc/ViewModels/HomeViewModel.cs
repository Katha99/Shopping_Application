using netzkern.MyBookstore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace netzkern.MyBookstore.UI.Web.Mvc.ViewModels
{
    public class HomeViewModel
    {
        public Product BestsellerBook { get; set; }
        public IEnumerable<Product> RelatedBookSet { get; set; }
    }
}