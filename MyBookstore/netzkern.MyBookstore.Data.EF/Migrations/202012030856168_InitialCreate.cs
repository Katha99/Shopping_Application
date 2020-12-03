namespace netzkern.MyBookstore.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Photo = c.String(),
                        Content = c.String(),
                        NumberOfPages = c.Int(nullable: false),
                        AuthorId = c.Int(),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Author", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderProduct",
                c => new
                    {
                        ProductRefId = c.Int(nullable: false),
                        OrderRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductRefId, t.OrderRefId })
                .ForeignKey("dbo.Product", t => t.ProductRefId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderRefId, cascadeDelete: true)
                .Index(t => t.ProductRefId)
                .Index(t => t.OrderRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderProduct", "OrderRefId", "dbo.Order");
            DropForeignKey("dbo.OrderProduct", "ProductRefId", "dbo.Product");
            DropForeignKey("dbo.Product", "AuthorId", "dbo.Author");
            DropIndex("dbo.OrderProduct", new[] { "OrderRefId" });
            DropIndex("dbo.OrderProduct", new[] { "ProductRefId" });
            DropIndex("dbo.Product", new[] { "AuthorId" });
            DropTable("dbo.OrderProduct");
            DropTable("dbo.Order");
            DropTable("dbo.Product");
            DropTable("dbo.Author");
        }
    }
}
