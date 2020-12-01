using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using netzkern.MyBookstore.Model;

namespace netzkern.MyBookstore.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Author> Authors { get; set; }
        #region "function"
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Product> ()
            //    .hasKey(x=>x.Id)
            //    .Property(x=>x.Id).
        }
        #endregion
    }
}
