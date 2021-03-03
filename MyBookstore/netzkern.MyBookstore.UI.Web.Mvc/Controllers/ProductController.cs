
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using netzkern.MyBookstore.BusinessLogic;
using netzkern.MyBookstore.Model;

namespace netzkern.MyBookstore.UI.Web.Mvc.Controllers
{
    public class ProductController : Controller
    {
        ProductService _productService;

        public ProductController()
        {
            _productService = new ProductService();
        }

        public ActionResult Index( string typeSort = "Titel ASC" )
        {
            List<Product> products = _productService.LoadSortedProducts(typeSort);

            ViewBag.products = products;                                
            return View(products);                   
        }

        public ActionResult DetailView(int id)
        {
            Product product = _productService.LoadOneProduct(id);

            ViewBag.product = product;                                  
            return View(product);                                       
        }
    }
}