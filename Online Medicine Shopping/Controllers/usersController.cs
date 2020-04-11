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
using System.IO;

namespace Online_Medicine_Shopping.Controllers
{
    public class usersController : Controller
    {
             private TemporaryDBContext db = new TemporaryDBContext();
        //*********************************************************************
        //----------Register Functionalities----------------------------
        //This Module is assigned to Amr Salah
        //*********************************************************************
        public ActionResult Register()
        {
            ViewBag.type_id = 2;
            return View();
        }

        // POST: users/Register

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "id,username,password,phone,image,address,type_id=2,fullname,email")] users users)
        {
            if (ModelState.IsValid)
            {
                //for file Posted
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/images/users"), fileName);
                        file.SaveAs(path);
                        users.image = fileName;
                        users.type_id = 2;
                        db.users.Add(users);
                        db.SaveChanges();
                        Session["status"] = true;
                        Session["user_image"] = users.image;
                        Session["user_name"] = users.username;
                        Session["user_id"] = users.id;
                        return RedirectToAction("Profile", new { id = users.id });


                    }

                }
               // return RedirectToAction("Login", new { xusername = users.username, xpassword = users.password });
            }

            ViewBag.type_id = 2;
            Session["status"] = true;
            return View(users);
            
        }

        //*********************************************************************
        //----------Login Functionalities----------------------------
        //This Module is assigned to Basant Atef
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
                SessionData(true, xusername, user.FirstOrDefault().id, user.FirstOrDefault().email, user.FirstOrDefault().type_id);

                Session["status"] = true;
                Session["user_full_name"] = user.FirstOrDefault().fullname;
                Session["phone_number"] = user.FirstOrDefault().phone;
                Session["user_image"] = user.FirstOrDefault().image;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid User Name Or Password");
                return View();
            }
            
        }

        //*********************************************************************
        //----------Logout Functionalities----------------------------
        //This Module is assigned to Ahmed Reshad
        //*********************************************************************
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
            Session["type_id"] = type;
        }
        //*********************************************************************
        //----------User Profile Functionalities----------------------------
        //This Module is assigned to Mohamed Hussein
        //*********************************************************************
        public new ActionResult Profile(int id)
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
        //*********************************************************************
        //----------Edit Profile Functionalities----------------------------
        //This Module is assigned to Ahmed Abdel Fatah
        //*********************************************************************

        public ActionResult EditProfile(int? id)
        {
            if (Session["user_id"].Equals(id))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                users users = db.users.Find(id);
                if (users == null)
                {
                    return HttpNotFound();
                }
                ViewBag.type_id = new SelectList(db.user_type, "type_id", "type_name", users.type_id);
                return View(users);
            }

            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile([Bind(Include = "id,username,password,image,phone,address,type_id,fullname,email")] users users)
        {
            var account = db.users.SingleOrDefault(e => e.id == users.id);
            if (ModelState.IsValid)
            {
                //for file Posted
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/images/users"), fileName);
                        file.SaveAs(path);

                        account.image = fileName;
                        account.username = users.username;
                        account.password = users.password;
                        account.phone = users.phone;
                        account.address = users.address;
                        Session["user_image"] = fileName;
                        account.fullname = users.fullname;
                        account.email = users.email;
                        db.Entry(account).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Profile", new { id = users.id });
                    }

                }
                else
                {
                    account.image = users.image;
                    account.username = users.username;
                    account.password = users.password;
                    account.phone = users.phone;
                    account.address = users.address;
                    Session["user_image"] = users.image;
                    account.fullname = users.fullname;
                    account.email = users.email;
                    db.Entry(account).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Profile", new { id = users.id });
                }
            }
          
            account.image = (string)Session["user_image"];
            account.username = users.username;
            account.password = users.password;
            account.phone = users.phone;
            account.address = users.address;
            Session["user_image"] = account.image;
            account.fullname = users.fullname;
            account.email = users.email;
            db.Entry(account).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Profile", new { id = users.id });
        }
        //*********************************************************************
        //----------Edit Profile Functionalities----------------------------
        //This Module is assigned to Ahmed Shokry
        //*********************************************************************
        public ActionResult DeleteProfile(int? id)
        {
            if (Session["user_id"].Equals(id))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                users user = db.users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }

            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("DeleteProfile")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProfile(int id)
        {
            users user = db.users.Find(id);
            db.users.Remove(user);
            db.SaveChanges();
            Session.Abandon();
            return RedirectToAction("Register");

        }

        // GET: users
        public ActionResult list_of_users()
        {
            if ((int)Session["type_id"] == 1)
            {
                var users = db.users.Include(u => u.user_type);
                return View(users.ToList());
            }
            else { return HttpNotFound(); }
        }
        

        }  



    }


