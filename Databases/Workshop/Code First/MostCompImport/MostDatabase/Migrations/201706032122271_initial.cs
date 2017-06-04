namespace MostDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Laptops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Laptop_Id = c.Int(),
                        Tablet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Laptops", t => t.Laptop_Id)
                .ForeignKey("dbo.Tablets", t => t.Tablet_Id)
                .Index(t => t.Laptop_Id)
                .Index(t => t.Tablet_Id);
            
            CreateTable(
                "dbo.Tablets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "Tablet_Id", "dbo.Tablets");
            DropForeignKey("dbo.Categories", "Laptop_Id", "dbo.Laptops");
            DropIndex("dbo.Categories", new[] { "Tablet_Id" });
            DropIndex("dbo.Categories", new[] { "Laptop_Id" });
            DropTable("dbo.Tablets");
            DropTable("dbo.Categories");
            DropTable("dbo.Laptops");
        }
    }
}
