namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ingredients", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredients", "Quantity", c => c.Int(nullable: false));
        }
    }
}
