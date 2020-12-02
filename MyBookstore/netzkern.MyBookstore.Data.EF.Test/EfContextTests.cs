using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using netzkern.MyBookstore.Data.EF;

namespace netzkern.MyBookstore.Data.EF.Test
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
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
    }
}
