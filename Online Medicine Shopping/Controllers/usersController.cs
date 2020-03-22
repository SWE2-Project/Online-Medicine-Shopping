using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Online_Medicine_Shopping.DBContext;
using Online_Medicine_Shopping.Models;

namespace Online_Medicine_Shopping.Controllers
{
    public class usersController : Controller
    {
        private Online_Medicine_ShoppingDBContext db = new Online_Medicine_ShoppingDBContext();
      
        // GET: users/Register
        public ActionResult Register()
        {
            ViewBag.type_id =2;
            return View();
        }

        // POST: users/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "id,username,password,phone,address,type_id=2,fullname,email")] users users)
        {
            if (ModelState.IsValid)
            {
                users.type_id = 2;
                db.users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Profile",new { id=users.id});
            }

            ViewBag.type_id = 2;
            return View(users);
        }

       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
