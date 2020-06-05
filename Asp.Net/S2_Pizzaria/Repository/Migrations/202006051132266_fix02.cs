namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix02 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ingredients", "Pizza_IngredientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredients", "Pizza_IngredientId", c => c.Guid(nullable: false));
        }
    }
}
