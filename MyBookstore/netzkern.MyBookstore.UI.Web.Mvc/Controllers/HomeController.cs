
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using netzkern.MyBookstore.BusinessLogic;
using netzkern.MyBookstore.Model;
using netzkern.MyBookstore.UI.Web.Mvc.ViewModels;

namespace netzkern.MyBookstore.UI.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        ProductService _productService;
        public HomeController()
        {
            _productService = new ProductService();
        }

            {
                j = rnd.Next(0, number -1);                            
                if (!randomList.Contains(j)) 
                {
                    randomList.Add(j);            
                    randProducts.Add(products[j]);   
                }
            }
            
            ViewBag.products = randProducts;   
            return View(randProducts);                                  
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";     
            return View();                                            
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";                     

            return View();                                    
        }
    }
}