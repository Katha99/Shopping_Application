﻿
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using netzkern.MyBookstore.UI.Web.Mvc.Models;


namespace netzkern.MyBookstore.UI.Web.Mvc.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index( string typeSort = "Titel ASC" )
        {
            var data = netzkern.MyBookstore.Data.EF.Logic.ProductProcessor.LoadSortedProduct( typeSort );                   
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

        public ActionResult DetailView(int id)
        {
            var data = netzkern.MyBookstore.Data.EF.Logic.ProductProcessor.LoadOneProduct(id);    
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