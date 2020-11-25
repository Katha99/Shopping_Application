namespace Shopping_Application.Migrations
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titel = c.String(),
                        Price = c.Double(nullable: false),
                        Photo = c.String(),
                        Content = c.String(),
                        Author = c.String()
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        ConfirmEmail = c.String(),
                        Password = c.String(),
                        ConfirmPassword = c.String()
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.Persons");
        }
    }
}
