
// A controller for interactions with the home page

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
        // GET: the home page with three random recommendations
        public ActionResult Index()
        {
            var data = LoadProduct();                                   // Einer var wird das Return-Ergebnis der Funktion LoadProduct des ProductProcessors zugewiesen
            List<Product> products = new List<Product>();               // Eine Liste des Typs Product namens products wird deklariert

            int number = 0, j = 0;
            foreach (var row in data)                                   
            {
                number++;
                products.Add(new Product                                // der Liste products wird ein neues Product hinzugefügt mit folgenden Daten
                {
                    Id = row.Id,
                    Titel = row.Titel,
                    Price = row.Price,
                    Photo = row.Photo,
                    Content = row.Content,
                    Author = row.Author
                });
            }

            Random rnd = new Random();                                  // Ein Objekt des Typs Random wird deklariert
            List<int> randomList = new List<int>();                     // Eine Liste des Typs int namens randomList wird deklariert
            List<Product> randProducts = new List<Product>();           // Eine Liste des Typs Product namens randProducts wird deklariert 

            for(int i = 0; i < 3; i++)                                  
            {
                j = rnd.Next(0, number -1);                             // die Next Funktion, die durch das Objekt rnd aufgerufen wird, gibt eine nicht negative Zufallszahl zwischen dem angegebenen Bereich zurück und weist sie j zu 
                if (!randomList.Contains(j))                            // Wenn die Liste randomList den Wert von j beinhaltet:
                {
                    randomList.Add(j);                                  // Füge der randomList den Inhalt von j hinzu
                    randProducts.Add(products[j]);                      // Füge der randProducts Liste den Inhalt der Liste products an der j-ten Stelle hinzu
                }
            }
            
            ViewBag.products = randProducts;                            // Weise die randProducts Liste dem ViewBag hinzu unter dem Namen products
            return View(randProducts);                                  
        }

        // GET: the About page
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";     // Der ViewBag wird unter dem Namen Message ein String hinzugefügt

            return View();                                              // gibt die HTML Seite About zurück
        }

        // GET: the contact page
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";                     // Der ViewBag wird unter dem Namen Message ein String hinzugefügt

            return View();                                              // gibt die HTML Seite Contact zurück
        }
    }
}