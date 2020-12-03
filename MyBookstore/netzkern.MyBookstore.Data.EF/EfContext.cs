using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using netzkern.MyBookstore.Model;

namespace netzkern.MyBookstore.Data.EF
{
    public class EfContext : DbContext
    {
        public EfContext() : base("name=MyBookstoreConnectionString")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PersonAccount> PersonAccounts { get; set; }


        #region "function"
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            #region Product
            modelBuilder.Entity<Product>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Product>()
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Product>()
                .HasOptional<Author>(x => x.Author)
                .WithMany(y => y.Products)
                .HasForeignKey<int?>( x => x.AuthorId );

            modelBuilder.Entity<Product>()
                .HasMany<Order>(x => x.Orders)
                .WithMany(y => y.Products)
                .Map(xy =>
                       {
                           xy.MapLeftKey("ProductRefId");
                           xy.MapRightKey("OrderRefId");
                           xy.ToTable("OrderProduct");
                       });
            #endregion

            #region Author
            modelBuilder.Entity<Author>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Author>()
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            #endregion

        }
        #endregion

    }
}
