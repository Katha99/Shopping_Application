
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using netzkern.MyBookstore.BusinessLogic;

namespace netzkern.MyBookstore.UI.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProductLogic productLogic = new ProductLogic();                                  
            List<netzkern.MyBookstore.Model.Product> products = new List<netzkern.MyBookstore.Model.Product>();

            products = productLogic.LoadProducts();

            int number = 0, j = 0;
            Random rnd = new Random();                          
            List<int> randomList = new List<int>();               
            List<netzkern.MyBookstore.Model.Product> randProducts = new List<netzkern.MyBookstore.Model.Product>();      

            for(int i = 0; i < 3; i++)                                  
            {
                j = rnd.Next(0, number -1);                            
                if (!randomList.Contains(j)) 
                {
                    randomList.Add(j);            
                    randProducts.Add(products[j]);   
                }
            }
            
            ViewBag.products = randProducts;   
            return View(randProducts);                                  
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";     
            return View();                                            
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";                     

            return View();                                    
        }
    }
}