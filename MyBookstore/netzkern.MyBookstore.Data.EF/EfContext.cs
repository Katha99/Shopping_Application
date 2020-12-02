using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using netzkern.MyBookstore.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace netzkern.MyBookstore.Data.EF
{
    public class EfContext : DbContext
    {
        public EfContext() : base("name=MyBookstoreConnectionString")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Author> Authors { get; set; }
        #region "function"
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            #region Product
            modelBuilder.Entity<Product>().HasKey(x => x.Id);

            modelBuilder.Entity<Product>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Product>()
                .HasOptional<Author>(x => x.Author)
                .WithMany(y => y.Products)
                .HasForeignKey<int?>( x => x.AuthorId );
            #endregion

            #region Author
            modelBuilder.Entity<Author>().HasKey(x => x.Id);
            modelBuilder.Entity<Author>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            #endregion

        }
        #endregion

    }
}
