
// A controller for interacting with the cart

using Shopping_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using static DataLibrary.Logic.ProductProcessor;

namespace Shopping_Application.Controllers
{
    public class CartController : Controller
    {
        // GET: Index View ( view for shopping cart )
        public ActionResult Index()
        {
            return View();
        }

        // function for adding a product to the cart
        public ActionResult Buy(int id)
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

            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = product, Quantity = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = product, Quantity = 1 });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");
        }

        // function for removing a product from the cart
        public ActionResult Remove(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

        // funtion for looking through the cart to see if there already is a product with the same index
        // if so: return the index
        private int isExist(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for( int i = 0; i < cart.Count; i++ )
            {
                if (cart[i].Product.Id == id)
                    return i;
            }
            return -1;
        }
    }
}