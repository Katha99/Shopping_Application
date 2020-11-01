using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping_Application.Models;
using DataLibrary;
using static DataLibrary.Logic.ProductProcessor;

namespace Shopping_Application.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var data = LoadProduct();
            List<Product> products = new List<Product>();

            int number = 0, j = 0;
            foreach (var row in data)
            {
                number++;
                products.Add(new Product
                {
                    Id = row.Id,
                    Titel = row.Titel,
                    Price = row.Price,
                    Photo = row.Photo,
                    Content = row.Content,
                    Author = row.Author
                });
            }

            Random rnd = new Random();
            List<int> randomList = new List<int>();
            List<Product> randProducts = new List<Product>();

            for(int i = 0; i < 3; i++)
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

        public ActionResult SignUp()
        {
            ViewBag.Message = "The sign up page.";

            return View();
        }
    }
}