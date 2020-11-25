
// A controller for interacting with products

using netzkern.MyBookstore.UI.Web.Mvc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using static netzkern.MyBookstore.Data.EF.Logic.ProductProcessor;


namespace netzkern.MyBookstore.UI.Web.Mvc.Controllers
{
    public class ProductController : Controller
    {
        // GET: View on a sorted productlist
        public ActionResult Index( string typeSort = "Titel ASC" )
        {
            var data = LoadSortedProduct( typeSort );                   // die Funktion LoadSortedProduct aus dem ProductProcessor wird aufgerufen und ihr wird der Wert von typeSort übergeben. Der Rückgabewert wird der Variable data zugeordnet
            List<Product> products = new List<Product>();               // Eine Liste des Typs Product namens products wird deklariert

            foreach (var row in data)
            {
                products.Add(new Product                                // Der Liste products wird ein neues Product hinzugefügt mit folgenden Daten
                {
                    Id = row.Id,
                    Titel = row.Titel,
                    Price = row.Price,
                    Photo = row.Photo,
                    Content = row.Content,
                    Author = row.Author
                });
            }
            ViewBag.products = products;                                // Dem ViewBag wird unter dem Namen products die Liste products hinzugefügt
            return View(products);                                      // gibt die HTML Seite Index zurück mit products als Übergabewert
        }

        // GET: View on a singel product
        public ActionResult DetailView(int id)
        {
            var data = LoadOneProduct(id);                              //  Einer var wird das Return-Ergebnis der Funktion LoadOneProduct des ProductProcessors zugewiesen, wobei der Funktion der Parameter id übergeben wird.
            Product product = new Product                               // Ein Product wird deklariert und ihm Daten zugewiesen
            {
                Id = data.First().Id,
                Titel = data.First().Titel,
                Price = data.First().Price,
                Photo = data.First().Photo,
                Content = data.First().Content,
                Author = data.First().Author
            };

            ViewBag.product = product;                                  // Dem ViewBag wird unter dem Namen product das Objekt product zugewiesen
            return View(product);                                       // gibt die HTML Seite DetailView zurück mit dem Parameter product
        }
    }
}