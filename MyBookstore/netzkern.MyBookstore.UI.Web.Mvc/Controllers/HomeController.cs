
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using netzkern.MyBookstore.BusinessLogic;
using netzkern.MyBookstore.Model;
using netzkern.MyBookstore.UI.Web.Mvc.ViewModels;
using AutoMapper;

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
            HomeViewModel model = new HomeViewModel()
            {
                RelatedBookSet = new List<Product>()
            };

            var products = this._productService.LoadRelatedProducts(3);
            var bestsellerBook = this._productService.LoadOneProduct(1009);

            if (products != null)
            {
                model = Mapper.Map<IEnumerable<Product>, HomeViewModel>(products);
            }
            if (bestsellerBook != null)
            {
                Mapper.Map(bestsellerBook, model);
            }

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