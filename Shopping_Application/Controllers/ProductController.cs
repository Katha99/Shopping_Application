using Shopping_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Shopping_Application.Controllers
{
    public class ProductController : Controller
    {
        private ProductDBContext db = new ProductDBContext();

        // GET: Product
        public ActionResult Index()
        {
            var products = from e in db.Products
                           orderby e.Id
                           select e;
            ViewBag.products = products;
            return View(products);
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