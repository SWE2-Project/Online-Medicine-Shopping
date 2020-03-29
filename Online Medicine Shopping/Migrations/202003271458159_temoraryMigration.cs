namespace Online_Medicine_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class temoraryMigration : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.user_type", t => t.type_id, cascadeDelete: true)
                .Index(t => t.type_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.users", "type_id", "dbo.user_type");
            DropIndex("dbo.users", new[] { "type_id" });
            DropTable("dbo.users");
            DropTable("dbo.user_type");
        }
    }
}
