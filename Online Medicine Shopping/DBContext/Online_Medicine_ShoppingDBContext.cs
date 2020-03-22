using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Online_Medicine_Shopping.Models;
using System.Data.Entity;

namespace Online_Medicine_Shopping.DBContext
{
    public class Online_Medicine_ShoppingDBContext : DbContext
    {
        public Online_Medicine_ShoppingDBContext() : base("name=Online_Medicine_ShoppingDBContext")
        {
        }

        public DbSet<user_type> user_type { get; set; }

        public DbSet<users> users { get; set; }
    }
}