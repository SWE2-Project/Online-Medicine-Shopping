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
            context.SaveChanges();
            context.users.AddOrUpdate(
                e => e.id,
                new Models.users {  username = "DonnaHall123", password = "Donna123456789", phone = "012222222", address = "test", type_id = 1, fullname = "Donna Hall", email = "Donna@gmail.com" ,image="admin.png"},
                new Models.users {  username = "JhonSmith222", password = "jhon123456789", phone = "012222222", address = "test", type_id = 1, fullname = "Jhon Smith Adam", email = "jhon@gmail.com", image = "f2.jpg" },
                new Models.users {  username = "PeterAdam555", password = "peter123456789", phone = "012222222", address = "test", type_id = 2, fullname = "Peter Adam", email = "peter@gmail.com", image = "customer.png" }

                );
                context.SaveChanges();
            context.categories.AddOrUpdate(
                     p => p.id,
                     new Models.category { id = 1, name = "FLU" },
                     new Models.category { id = 2, name = "Eczema Treatment" }
                                  );
            context.SaveChanges();
            context.suppliers.AddOrUpdate(
                      p => p.id,
                      new Models.supplier { id = 1, name = "JGGP", location = "Italy", email = "JGGP@gmail.com" },
                      new Models.supplier { id = 2, name = "ELMotahedh", location = "Egypt", email = "ELMotahedh@gmail.com" },
                      new Models.supplier { id = 3, name = "Pure", location = "USA", email = "pure@gmail.com" }
                                   );
            context.SaveChanges();
            context.product.AddOrUpdate(
                p => p.id,
                new Models.product { id = 1, name = "Walgreens Ephrine Nose Drops", price = 50, quantity = 5, category_id = 1, supplier_id = 1, descrition = " Relieves nasal congestion• Helps decongest sinus passages • Fast acting", image = "valgreen.jpg" },
                 new Models.product { id = 2, name = "Walgreens Wal-Tussin Chest Congestion", price = 30, quantity = 5, category_id = 1, supplier_id = 2, descrition = "•Loosens and thins bronchial secretions •Helps make coughs more productive br • Non - drowsy and alcohol - free", image = "walgreen.jpg" },
                  new Models.product { id = 3, name = "Walgreens Mucus Relief Chest Congestion Immediate-Release Tablets", price = 40, quantity = 5, category_id = 1, supplier_id = 1, descrition = "• Helps loosen phlegm • Makes coughs more productive • Easy to swallow", image = "wal.jpg" },
                   new Models.product { id = 4, name = "Walgreens Wal-Phed PE Nasal Decongestant Tablets", price = 20, quantity = 5, category_id = 1, supplier_id = 2, descrition = "• Relieves sinus congestion & pressure • For nasal congestion • Non - drowsy", image = "walphed.jpg" },
                    new Models.product { id = 5, name = "Walgreens Wal-Four Nasal Decongestant Spray", price = 20, quantity = 5, category_id = 1, supplier_id = 3, descrition = "• For dry nasal membranes • Pharmacist recommended • Gluten free", image = "walfour.jpg" },
                     new Models.product { id = 6, name = "Dermarest Eczema Medicated Lotion Fragrance Free", price = 10, quantity = 5, category_id = 2, supplier_id = 2, descrition = "• Temporary relieves itching • For rashes due to eczema • Non - greasy & dermatologist tested", image = "demra.jfif" },
                      new Models.product { id = 7, name = "Aveeno Active Naturals Eczema Therapy Hand", price = 5, quantity = 5, category_id = 2, supplier_id = 1, descrition = "This breakthrough hand cream helps to improve the 4 symptoms of eczema - itch", image = "download.jfif" },
                      new Models.product { id = 8, name = "Natralia Eczema & Psoriasis Cream", price = 500, quantity = 5, category_id = 2, supplier_id = 2, descrition = "Relief of skin irritation • Aids itching redness, flaking & scaling • Fortified with traditional herbs", image = "natrilla.jfif" },
                      new Models.product { id = 9, name = "Aveeno Eczema Care Itch Relief Balm", price = 29, quantity = 5, category_id = 2, supplier_id = 3, descrition = "	11 ounces of eczema therapy relief itch relief balm Provides immediate and long-lasting itch", image = "aveeno.jfif" }




                );
            context.SaveChanges();
        }
    }
}
