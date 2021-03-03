using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netzkern.MyBookstore.BusinessLogic;
using netzkern.MyBookstore.Model;

namespace netzkern.MyBookstore.UI.Konsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductService productService = new ProductService();

            Console.WriteLine("Test Fuction productService.LoadRelatedProducts(5)");
            List<Product> productList = productService.LoadRelatedProducts(5);

            foreach (var product in productList)
            {
                Console.WriteLine("Produkt Titel: " + product.Title);
                Console.WriteLine("Produkt ID: " + product.Id);
                Console.WriteLine("____________________________");
            }

            Console.WriteLine("");
            Console.WriteLine("Test Fuction productService.LoadRelatedProducts(10)");
            productList = productService.LoadRelatedProducts(10);

            foreach (var product in productList)
            {
                Console.WriteLine("Produkt Titel: " + product.Title);
                Console.WriteLine("Produkt ID: " + product.Id);
                Console.WriteLine("____________________________");
            }

            Console.WriteLine("");
            Console.WriteLine("Test Fuction productService.LoadRelatedProducts(0)");
            try
            {
                productList = productService.LoadRelatedProducts(0);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            foreach (var product in productList)
            {
                Console.WriteLine("Produkt Titel: " + product.Title);
                Console.WriteLine("Produkt ID: " + product.Id);
                Console.WriteLine("____________________________");
            }

            Console.WriteLine("");
            Console.WriteLine("Test Fuction productService.LoadRelatedProducts(-1)");
            productList = productService.LoadRelatedProducts(-1);

            foreach (var product in productList)
            {
                Console.WriteLine("Produkt Titel: " + product.Title);
                Console.WriteLine("Produkt ID: " + product.Id);
                Console.WriteLine("____________________________");
            }

            Console.ReadKey();
        }
    }
}
