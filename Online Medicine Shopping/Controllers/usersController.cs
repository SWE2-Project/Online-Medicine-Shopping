using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using Online_Medicine_Shopping.DBContext;
using Online_Medicine_Shopping.Models;

namespace Online_Medicine_Shopping.Controllers
{
    public class usersController : Controller
    {
        private TemporaryDBContext db = new TemporaryDBContext();
        // GET: users/Register
        public ActionResult Register()
        {
            ViewBag.type_id = 2;
            return View();
        }

        // POST: users/Register
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "id,username,password,phone,address,type_id=2,fullname,email")] users users)
        {
            if (ModelState.IsValid)
            {
                users.type_id = 2;
                db.users.Add(users);
                db.SaveChanges();
                Session["status"] = true;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.type_id = 2;
            return View(users);
        }

        //*********************************************************************
        //----------Login Functionalities----------------------------
        //*********************************************************************

        //[HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(string xusername, string xpassword)
        {
            var user = db.users.Where(e => e.username == xusername && e.password == xpassword);

            if (!String.IsNullOrEmpty(xusername) && !String.IsNullOrEmpty(xpassword) && user.Any())
            {
                FormsAuthentication.SetAuthCookie(xusername, false);
                SessionData(true, xusername, user.SingleOrDefault().id, user.SingleOrDefault().email, user.SingleOrDefault().type_id);
                ViewBag.id = user.SingleOrDefault().id;
                Session["status"] = true;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid User Name Or Password");
                return View();
            }
            
        }

        /// <summary>
        /// Logout Functionalities
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            //clear the current session
            Session.Abandon();
            return RedirectToAction("Index", "Home");

        }
        /// <summary>
        /// SESSION DATA SAVED By These FUNCTION
        /// </summary>
        /// <returns></returns>
        public void SessionData(bool status, string username, int id, string email, int type)
        {
            Session["status"] = status;
            Session["user_name"] = username;
            Session["user_id"] = id;
            Session["user_email"] = email;
            Session["type"] = type;
        }
        //*********************************************************************
        //----------User Profile Functionalities----------------------------
        //*********************************************************************
        public ActionResult Profile(int? id)
        {
            if (Session["user_id"].Equals(id))
            {
                var user = db.users.Where(e => e.id == id).Include(e => e.user_type).SingleOrDefault();
                ViewBag.type = user.user_type.type_name;
                return View(user);
            }

            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


        }




    }

}