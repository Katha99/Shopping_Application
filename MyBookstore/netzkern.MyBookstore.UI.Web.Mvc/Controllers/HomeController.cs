
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

        public ActionResult Index()
        {                              
            List<Product> products = new List<Product>();
            HomeViewModel model = new HomeViewModel()
            {
                RelatedBookSet = new List<Product>()
            };
            new 
            
            products = this._productService.LoadRelatedProducts(3);
            model.RelatedBookSet = products;

            model.BestsellerBook = this._productService.LoadOneProduct(1009);

            return View(model);                                  
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