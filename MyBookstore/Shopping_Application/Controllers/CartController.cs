
// A controller for interacting with the cart

//Einbindung von außenstehenden Code-Paketen
using Shopping_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using static DataLibrary.Logic.ProductProcessor;

namespace Shopping_Application.Controllers                                      // Definition des namespaces um Konflikte mit Objekten mit demselben Namen aus anderen namespaces zu vermeiden
{
    public class CartController : Controller                                    // Definierung einer Klasse die von der Klasse Controller erbt
    {
        // GET: Index View ( view for shopping cart )
        public ActionResult Index()                                             // Definierung einer Funktion Index, die bei Aufruf die HTML-Seite Index zurück gibt.
        {
            return View();
        }

        // function for adding a product to the cart
        public ActionResult Buy(int id)                                         // Definierung einer Funktion, die einen int Parameter übergeben bekommt
        {
            var data = LoadOneProduct(id);                                      // Einer var wird das Return-Ergebnis der Funktion LoadOneProduct des ProductProcessors zugewiesen, wobei der Funktion der Parameter id übergeben wird.
            Product product = new Product                                       // Es wird eon Objekt Produkt instanziert, welches Daten zugewiesen bekommt
            {
                Id = data.First().Id,
                Titel = data.First().Titel,
                Price = data.First().Price,
                Photo = data.First().Photo,
                Content = data.First().Content,
                Author = data.First().Author
            };

            if (Session["cart"] == null)                                        // wenn das Session-Objekt namens "cart" == 0, also leer ist:
            {
                List<Item> cart = new List<Item>();                             // erstelle eine neue Liste des Typs Item namens cart
                cart.Add(new Item { Product = product, Quantity = 1 });         // Füge ein neues Objekt der Liste hinzu mit den genannten Daten
                Session["cart"] = cart;                                         // Weise dem Session-Objekt namens cart die Liste zu
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];                  // Erstelle eine Liste des Typs Item namens cart und weise ihr den Inhalt des Objekts aus der Session namens cart zu, jedoch explizit typisiert als Liste des Obejkts Item
                int index = isExist(id);                                        // rufe die Funktion isExist auf, übergebe ihr den Parameter id und weise den Rückgabewert der Funktion der neu deklarierten int Variable index zu.
                if (index != -1)
                {
                    cart[index].Quantity++;                                     
                }
                else
                {
                    cart.Add(new Item { Product = product, Quantity = 1 });     // Füge ein neues Objekt der Liste hinzu des Typs Item mit folgenden Daten
                }
                Session["cart"] = cart;                                         // Weise dem Session-Objekt namens cart die Liste cart zu.
            }
            return RedirectToAction("Index");                                   // Aufruf der Index Funktion des Cart Controllers
        }

        // function for removing a product from the cart
        public ActionResult Remove(int id)                                      // Definierung einer Funktion Remove, die einen int Parameter übergeben bekommt
        {
            List<Item> cart = (List<Item>)Session["cart"];                      // Erstelle eine Liste des Typs Item namens cart und weise ihr den Inhalt des Objekts aus der Session namens cart zu, jedoch explizit typisiert als Liste des Obejkts Item
            int index = isExist(id);                                            // rufe die Funktion isExist auf, übergebe ihr den Parameter id und weise den Rückgabewert der Funktion der neu deklarierten int Variable index zu.
            cart.RemoveAt(index);                                               // Entferen ein Objekt in der Liste cart an der Stelle index
            Session["cart"] = cart;                                             // Weise dem Session-Objekt namens cart die Liste zu
            return RedirectToAction("Index");                                   // Aufruf der Index Funktion des Cart Controllers
        }

        // funtion for looking through the cart to see if there already is a product with the same index
        // if so: return the index
        private int isExist(int id)                                             // Definierung einer Funktion, die einen Parameter int übergeben bekommt
        {
            List<Item> cart = (List<Item>)Session["cart"];                      // Erstelle eine Liste des Typs Item namens cart und weise ihr den Inhalt des Objekts aus der Session namens cart zu, jedoch explizit typisiert als Liste des Obejkts Item
            for( int i = 0; i < cart.Count; i++ )       
            {
                if (cart[i].Product.Id == id)
                    return i;
            }
            return -1;
        }
    }
}