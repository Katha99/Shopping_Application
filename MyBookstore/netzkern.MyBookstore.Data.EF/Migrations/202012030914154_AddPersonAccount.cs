namespace netzkern.MyBookstore.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonAccount : DbMigration
    {
        public override void Up()
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
            CreateIndex("dbo.Order", "PersonAccountId");
            AddForeignKey("dbo.Order", "PersonAccountId", "dbo.PersonAccount", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "PersonAccountId", "dbo.PersonAccount");
            DropIndex("dbo.Order", new[] { "PersonAccountId" });
            DropColumn("dbo.Order", "PersonAccountId");
            DropTable("dbo.PersonAccount");
        }
    }
}
