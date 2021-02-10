
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using netzkern.MyBookstore.BusinessLogic;


namespace netzkern.MyBookstore.UI.Web.Mvc.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index( string typeSort = "Titel ASC" )
        {
            ProductLogic productLogic = new ProductLogic();
            List<netzkern.MyBookstore.Model.Product> products = new List<netzkern.MyBookstore.Model.Product>();

            products = productLogic.LoadSortedProducts(typeSort);

            ViewBag.products = products;                                
            return View(products);                   
        }

        public ActionResult DetailView(int id)
        {
            ProductLogic productLogic = new ProductLogic();
            netzkern.MyBookstore.Model.Product product = new netzkern.MyBookstore.Model.Product();

            product = productLogic.LoadOneProduct(id);

            ViewBag.product = product;                                  
            return View(product);                                       
        }
    }
}