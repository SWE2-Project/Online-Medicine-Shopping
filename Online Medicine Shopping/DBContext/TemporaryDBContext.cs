using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Online_Medicine_Shopping.Models;
namespace Online_Medicine_Shopping.DBContext
{
    public class TemporaryDBContext : DbContext
    {
        public TemporaryDBContext() : base("name=TemporaryDBContext")
        {
        }

        public DbSet<user_type> user_type { get; set; }

        public DbSet<users> users { get; set; }

        public DbSet<product> product { get; set; }
        public DbSet<supplier> suppliers { get; set; }

        public DbSet<category> categories { get; set; }

    }
}