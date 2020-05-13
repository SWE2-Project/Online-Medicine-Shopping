namespace Online_Medicine_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class temoraryMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categories",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    name = c.String(),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.products",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    name = c.String(),
                    price = c.Single(nullable: false),
                    quantity = c.Int(nullable: false),
                    category_id = c.Int(nullable: false),
                    supplier_id = c.Int(nullable: false),
                    descrition = c.String(),
                    image = c.String(),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.categories", t => t.category_id, cascadeDelete: true)
                .ForeignKey("dbo.suppliers", t => t.supplier_id, cascadeDelete: true)
                .Index(t => t.category_id)
                .Index(t => t.supplier_id);

            CreateTable(
                "dbo.suppliers",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    name = c.String(),
                    location = c.String(),
                    email = c.String(nullable: false),
                })
                .PrimaryKey(t => t.id);
            CreateTable(
                "dbo.user_type",
                c => new
                    {
                        type_id = c.Int(nullable: false, identity: true),
                        type_name = c.String(),
                    })
                .PrimaryKey(t => t.type_id);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 20),
                        password = c.String(nullable: false, maxLength: 25),
                        phone = c.String(nullable: false),
                        address = c.String(nullable: false),
                        type_id = c.Int(nullable: false),
                        fullname = c.String(nullable: false, maxLength: 20),
                        email = c.String(nullable: false),
                        image = c.String(nullable: false,defaultValue:"unknown.png")

                })



                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.user_type", t => t.type_id, cascadeDelete: true)
                .Index(t => t.type_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.users", "type_id", "dbo.user_type");
            DropForeignKey("dbo.products", "supplier_id", "dbo.suppliers");
            DropForeignKey("dbo.products", "category_id", "dbo.categories");
            DropIndex("dbo.users", new[] { "type_id" });
            DropIndex("dbo.products", new[] { "supplier_id" });
            DropIndex("dbo.products", new[] { "category_id" });
            DropTable("dbo.users");
            DropTable("dbo.user_type");
            DropTable("dbo.suppliers");
            DropTable("dbo.products");
            DropTable("dbo.categories");
        }
    }
}
