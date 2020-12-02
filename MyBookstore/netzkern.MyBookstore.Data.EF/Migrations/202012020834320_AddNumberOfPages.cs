namespace netzkern.MyBookstore.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberOfPages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "NumberOfPages", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "NumberOfPages");
        }
    }
}
