
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using netzkern.MyBookstore.UI.Web.Mvc.Models;

namespace netzkern.MyBookstore.UI.Web.Mvc.Controllers
{
    public class CartController : Controller                              
    {
        public ActionResult Index()                                 
        {
            return View();
        }

        public ActionResult Buy(int id)                         
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

        public ActionResult Remove(int id)                                 
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);             
            cart.RemoveAt(index);    
            Session["cart"] = cart;   
            return RedirectToAction("Index"); 
        }

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