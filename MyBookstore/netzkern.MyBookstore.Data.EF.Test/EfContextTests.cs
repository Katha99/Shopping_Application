using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using System.IO;

using netzkern.MyBookstore.Data.EF;
using netzkern.MyBookstore.Model;

namespace netzkern.MyBookstore.Data.EF.Test
{
    [TestClass]
    public class EfContextTests
    {
        //[TestMethod]
        public void EfContext_Can_create_database()
        {
            // Arrange
            EfContext efContextTest = new EfContext();
            if ( efContextTest.Database.Exists() )
            {
                efContextTest.Database.Delete();
            }

            // Act
            efContextTest.Database.Create();

            // Assert
            Assert.IsTrue(efContextTest.Database.Exists());
        }

        [TestMethod]
        public void EfContext_Crud_Author()
        {
            // Arrange
            Author author = new Author()
            {
                Firstname = $"Max_{Guid.NewGuid()}",
                Lastname = "Mustermann"
            };

            string newFirstname = $"Moritz_{Guid.NewGuid()}";

            // Act
            using (EfContext efContext = new EfContext())
            {
                // Insert
                efContext.Authors.Add(author);
                efContext.SaveChanges();
            }

            using (EfContext efContext = new EfContext())
            {
                // Read ( Inserted )
                Author loadedAuthor = efContext.Authors.Find(author.Id);
                Assert.AreEqual(author.Firstname, loadedAuthor.Firstname);

                // Update
                loadedAuthor.Firstname = newFirstname;
                efContext.SaveChanges();
            }

            using (EfContext efContext = new EfContext())
            {
                // Read Update
                Author loadedAuthor = efContext.Authors.Find(author.Id);
                Assert.AreEqual(loadedAuthor.Firstname, newFirstname);

                // Delete
                efContext.Authors.Remove(loadedAuthor);
                efContext.SaveChanges();
            }

            using (EfContext efContext = new EfContext())
            {
                // Check Delete
                Author loadedAuthor = efContext.Authors.Find(author.Id);
                Assert.IsNull(loadedAuthor);
            }
        }
        [TestMethod]
        public void EfContext_Crud_Product()
        {
            // Arrange
            Product product = new Product()
            {
                Title = $"Ein Titel_{Guid.NewGuid()}",
                Price = 3.99m,
                Photo = "01.jpg",
                Content = "Eine Zusammenfassung eines Buches",
                NumberOfPages = 200
            };

            string newTitle = $"Ein Titel_{Guid.NewGuid()}";

            // Act
            using (EfContext efContext = new EfContext())
            {
                // Insert
                efContext.Products.Add(product);
                efContext.SaveChanges();
            }

            using (EfContext efContext = new EfContext())
            {
                // Read ( Inserted )
                Product loadedProduct = efContext.Products.Find(product.Id);
                Assert.AreEqual(product.Title, loadedProduct.Title);

                // Update
                loadedProduct.Title = newTitle;
                efContext.SaveChanges();
            }

            using (EfContext efContext = new EfContext())
            {
                // Read Update
                Product loadedProduct = efContext.Products.Find(product.Id);
                Assert.AreEqual(loadedProduct.Title, newTitle);

                // Delete
                efContext.Products.Remove(loadedProduct);
                efContext.SaveChanges();
            }

            using (EfContext efContext = new EfContext())
            {
                // Check Delete
                Product loadedProduct = efContext.Products.Find(product.Id);
                Assert.IsNull(loadedProduct);
            }
        }
    }
}
