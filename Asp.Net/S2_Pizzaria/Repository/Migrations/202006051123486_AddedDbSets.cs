namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDbSets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bottom",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SauceId = c.Guid(nullable: false),
                        PizzaId = c.Guid(nullable: false),
                        Surface = c.Double(nullable: false),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Thick = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Pizza_IngredientId = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        SpicyGrade = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        IsVegetarian = c.Boolean(),
                        IsVegan = c.Boolean(),
                        IsHalal = c.Boolean(),
                        ContainsLactose = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderRuleId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderRule",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderId = c.Guid(nullable: false),
                        PizzaId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pizza_Ingredient",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PizzaId = c.Guid(nullable: false),
                        IngriedientId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pizza",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BottomId = c.Guid(nullable: false),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        OrderRule_Id = c.Guid(),
                        PizzaIngredient_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderRule", t => t.OrderRule_Id)
                .ForeignKey("dbo.Pizza_Ingredient", t => t.PizzaIngredient_Id)
                .Index(t => t.OrderRule_Id)
                .Index(t => t.PizzaIngredient_Id);
            
            CreateTable(
                "dbo.Sauce",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BottomId = c.Guid(nullable: false),
                        Name = c.String(),
                        IsSpicy = c.Boolean(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.User", "OrderId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pizza", "PizzaIngredient_Id", "dbo.Pizza_Ingredient");
            DropForeignKey("dbo.Pizza", "OrderRule_Id", "dbo.OrderRule");
            DropIndex("dbo.Pizza", new[] { "PizzaIngredient_Id" });
            DropIndex("dbo.Pizza", new[] { "OrderRule_Id" });
            DropColumn("dbo.User", "OrderId");
            DropTable("dbo.Sauce");
            DropTable("dbo.Pizza");
            DropTable("dbo.Pizza_Ingredient");
            DropTable("dbo.OrderRule");
            DropTable("dbo.Order");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Bottom");
        }
    }
}
