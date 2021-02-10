using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using netzkern.MyBookstore.Data.EF;
using netzkern.MyBookstore.Model;

namespace netzkern.MyBookstore.BusinessLogic
{
    public class ProductLogic
    {
        public void CreateProduct(string titel, decimal price, string photo, string content, int numberOfPages, Author author, int authorId)
        {
            Product data = new Product
            {
                Title = titel,
                Price = price,
                Photo = photo,
                Content = content,
                NumberOfPages = numberOfPages,
                Author = author,
                AuthorId = authorId
            };

            using (EfContext efContext = new EfContext())
            {              
                efContext.Products.Add(data);
                efContext.SaveChanges();
            }
        }

        public List<Product> LoadProducts()
        {
            using (EfContext efContext = new EfContext())
            {
                List<Product> productsList = efContext.Products.Select(x => x).ToList();
                return productsList;
            }
        }

        public List<Product> LoadSortedProducts(string row)
        {
            using (EfContext efContext = new EfContext())
            {
                if (row == "Titel ASC")
                {
                    List<Product> productsList = efContext.Products.Select(x => x).OrderBy(x => x.Title).ToList();
                    return productsList;
                }
                else if (row == "Titel DESC")
                {
                    List<Product> productsList = efContext.Products.Select(x => x).OrderByDescending(x => x.Title).ToList();
                    return productsList;
                }
                else if (row == "Price ASC")
                {
                    List<Product> productsList = efContext.Products.Select(x => x).OrderBy(x => x.Price).ToList();
                    return productsList;
                }
                else if (row == "Price DESC")
                {
                    List<Product> productsList = efContext.Products.Select(x => x).OrderByDescending(x => x.Price).ToList();
                    return productsList;
                }
                else return null;
            }
        }

        public Product LoadOneProduct(int id)
        {
            using (EfContext efContext = new EfContext())
            {
                Product product = efContext.Products.Find(id);
                return product;
            }
        }
    }
}
