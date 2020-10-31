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
        // GET: Product
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


            /*// GET: Product/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: Product/Create
            [HttpPost]
            public ActionResult Create(Product product)
            {
                try
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }

            // GET: Product/Edit/5
            public ActionResult Edit(int id)
            {
                var product = db.Products.Single(m => m.Id == id);
                return View(product);
            }

            // POST: Employee/Edit/5
            [HttpPost]
            public ActionResult Edit(int id, FormCollection collection)
            {
                try
                {
                    var product = db.Products.Single(m => m.Id == id);
                    if (TryUpdateModel(product))
                    {
                        //To Do:- database code
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    return View(product);
                }
                catch
                {
                    return View();
                }
            }*/
        }
}