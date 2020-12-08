namespace netzkern.MyBookstore.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonAccountEditedToAddress : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "PersonAccountId", "dbo.PersonAccount");
            DropIndex("dbo.Order", new[] { "PersonAccountId" });
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        HouseNumber = c.String(),
                        PostalCode = c.String(),
                        City = c.String(),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Order", "AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Order", "AddressId");
            AddForeignKey("dbo.Order", "AddressId", "dbo.Address", "Id", cascadeDelete: true);
            DropColumn("dbo.Order", "PersonAccountId");
            DropTable("dbo.PersonAccount");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PersonAccount",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        EmailAddress = c.String(),
                        Password = c.String(),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Order", "PersonAccountId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Order", "AddressId", "dbo.Address");
            DropIndex("dbo.Order", new[] { "AddressId" });
            DropColumn("dbo.Order", "AddressId");
            DropTable("dbo.Address");
            CreateIndex("dbo.Order", "PersonAccountId");
            AddForeignKey("dbo.Order", "PersonAccountId", "dbo.PersonAccount", "Id", cascadeDelete: true);
        }
    }
}
