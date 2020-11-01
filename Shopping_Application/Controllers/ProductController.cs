
// A controller for interacting with products

using Shopping_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using static DataLibrary.Logic.ProductProcessor;


namespace Shopping_Application.Controllers
{
    public class ProductController : Controller
    {
        // GET: View on a sorted productlist
        public ActionResult Index( string typeSort = "Titel ASC" )
        {
            var data = LoadSortedProduct( typeSort );
            List<Product> products = new List<Product>();

            foreach (var row in data)
            {
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
            ViewBag.products = products;
            return View(products);
        }

        // GET: View on a singel product
        public ActionResult DetailView(int id)
        {
            var data = LoadOneProduct(id);
            Product product = new Product
            {
                Id = data.First().Id,
                Titel = data.First().Titel,
                Price = data.First().Price,
                Photo = data.First().Photo,
                Content = data.First().Content,
                Author = data.First().Author
            };

            ViewBag.product = product;
            return View(product);
        }
    }
}