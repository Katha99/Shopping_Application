using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            #region Author Test
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
            #endregion
        }
    }
}
