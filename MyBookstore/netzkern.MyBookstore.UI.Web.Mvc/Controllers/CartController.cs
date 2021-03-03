
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using netzkern.MyBookstore.BusinessLogic;
using netzkern.MyBookstore.Model;

namespace netzkern.MyBookstore.UI.Web.Mvc.Controllers
{
    public class CartController : Controller                              
    {
        ProductService _productService;

        public CartController()
        {
            _productService = new ProductService();
        }

        public ActionResult Index()                                 
        {
            return View();
        }

        public ActionResult Buy(int id)                         
        {
           Product product =  _productService.LoadOneProduct(id);

            if (Session["cart"] == null)
            {
                List<CartItem> cart = new List<CartItem>();
                cart.Add(new CartItem { Product = product, Quantity = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<CartItem> cart = (List<CartItem>)Session["cart"];
                int index = isExist(id);                                       
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new CartItem { Product = product, Quantity = 1 });   
                }
                Session["cart"] = cart;                             
            }
            return RedirectToAction("Index");  
        }

        public ActionResult Remove(int id)                                 
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            int index = isExist(id);             
            cart.RemoveAt(index);    
            Session["cart"] = cart;   
            return RedirectToAction("Index"); 
        }

        private int isExist(int id)              
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];                   
            for( int i = 0; i < cart.Count; i++ )       
            {
                if (cart[i].Product.Id == id)
                    return i;
            }
            return -1;
        }
    }
}