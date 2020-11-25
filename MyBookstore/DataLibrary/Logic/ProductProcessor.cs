
using System.Collections.Generic;

using netzkern.MyBookstore.Data.EF.DataAccess;
using netzkern.MyBookstore.Data.EF.Models;

namespace netzkern.MyBookstore.Data.EF.Logic
{
    public static class ProductProcessor
    {
        public static int CreateProduct(string titel, decimal price, string photo, string content, string author)
        {
            Product data = new Product
            {
                Titel = titel,
                Price = price,
                Photo = photo,
                Content = content,
                Author = author
            };

            string sql = @"insert into dbo.Products (Titel, Price, Photo, Content, Author)
                            values (@Titel, @Price, @Photo, @Content, @Author);";


            return SQLDataAccess.SaveData(sql, data);
        }

        public static List<Product> LoadProduct()
        {
            string sql = @"select Id, Titel, Price, Photo, Content, Author
                            from dbo.Products;";
            return SQLDataAccess.LoadData<Product>(sql);
        }

        public static List<Product> LoadSortedProduct(string row)
        {
            string sql = @"select Id, Titel, Price, Photo, Content, Author
                            from dbo.Products" + 
                            " order by " + row +";";
            return SQLDataAccess.LoadData<Product>(sql);
        }

        public static List<Product> LoadOneProduct(int id)
        {
            string sql = @"select Id, Titel, Price, Photo, Content, Author
                            from dbo.Products" +
                            " where " + id + " = Id;";
            return SQLDataAccess.LoadData<Product>(sql);
        }
    }
}

