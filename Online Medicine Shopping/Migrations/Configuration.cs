namespace Online_Medicine_Shopping.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Online_Medicine_Shopping.DBContext.Online_Medicine_ShoppingDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Online_Medicine_Shopping.DBContext.Online_Medicine_ShoppingDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.user_type.AddOrUpdate(
                p=>p.type_id,
                new Models.user_type {type_id=1,type_name="Admin"},
                new Models.user_type { type_id = 2, type_name = "Customer" }
                );
            context.users.AddOrUpdate(
                p=>p.id,
                new Models.users { id = 1, username = "DonnaHall123",password="qwertyuiop123456",phone="01255555555555",address="test",type_id=1,fullname="Donna Hall",email="Donna@gmail.com"}

                );
        }
    }
}
