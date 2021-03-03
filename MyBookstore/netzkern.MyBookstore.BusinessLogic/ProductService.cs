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
    public class ProductService
    {
        public List<Product> LoadProducts()
        {
            return this._LoadProducts();
        }

        public List<Product> LoadRelatedProducts( int count )
        {
            if (count < 1)
                throw new ArgumentException();

            return _GetCountXRandomProducts(count);
        }

        private List<Product> _GetCountXRandomProducts(int count)
        {
            List<Product> productsList = this._LoadProducts();
            List<Product> randomProductsList = new List<Product>();
            Random random = new Random();

            if (_ListContainsElements(productsList))
            {
                List<int> randomList = new List<int>();
                int randomIndex = 0;
                int maxCounter = productsList.Count();

                while (randomList.Count < count && randomList.Count < productsList.Count)
                {
                    randomIndex = _GenerateRandomNumber(maxCounter, random);
                    
                    if (_NotListContains(randomIndex, randomList))
                    {
                        randomList.Add(randomIndex);
                        randomProductsList.Add(productsList[randomIndex]);
                    }
                }
            }

            return randomProductsList;
        }

        private bool _NotListContains(int randomIndex, List<int> randomList)
        {
            return (!randomList.Contains(randomIndex));
        }

        private int _GenerateRandomNumber(int maxValue, Random random)
        {
            return random.Next(0, maxValue);;
        }

        private bool _ListContainsElements(List<Product> list)
        {
            return list != null && list.Any();
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

        private List<Product> _LoadProducts()
        {
            using (EfContext efContext = new EfContext())
            {
                List<Product> productsList = efContext.Products.Select(x => x).ToList();
                return productsList;
            }
        }
    }
}
