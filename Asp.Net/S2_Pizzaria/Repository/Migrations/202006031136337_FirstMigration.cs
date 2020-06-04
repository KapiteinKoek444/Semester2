namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        ZipCode = c.String(),
                        HousNr = c.Int(nullable: false),
                        IsEmployee = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
        }
    }
}
