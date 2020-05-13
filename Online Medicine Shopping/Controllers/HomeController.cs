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
    public class HomeController : Controller
    {


        private TemporaryDBContext db = new TemporaryDBContext();
        public ActionResult Index()
        {
            var product = from m in db.product
                          select m;
            ViewBag.categoryName = from m in db.categories
                                   select m;
            Session["category"] = from m in db.categories
                                  select m;
            return View(product);



        }
    }
}