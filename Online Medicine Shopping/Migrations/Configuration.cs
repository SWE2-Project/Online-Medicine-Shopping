namespace Online_Medicine_Shopping.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Online_Medicine_Shopping.DBContext.TemporaryDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Online_Medicine_Shopping.DBContext.TemporaryDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            context.user_type.AddOrUpdate(
              p => p.type_id,
              new Models.user_type { type_id = 1, type_name = "admin" },
              new Models.user_type { type_id = 2, type_name = "customer" }
            );
            context.users.AddOrUpdate(
                e => e.id,
                new Models.users {  username = "DonnaHall123", password = "Donna123456789", phone = "012222222", address = "test", type_id = 1, fullname = "Donna Hall", email = "Donna@gmail.com" ,image="admin.png"},
                new Models.users {  username = "JhonSmith222", password = "jhon123456789", phone = "012222222", address = "test", type_id = 1, fullname = "Jhon Smith Adam", email = "jhon@gmail.com", image = "f2.jpg" },
                new Models.users {  username = "PeterAdam555", password = "peter123456789", phone = "012222222", address = "test", type_id = 2, fullname = "Peter Adam", email = "peter@gmail.com", image = "customer.png" }

                );
        }
    }
}
