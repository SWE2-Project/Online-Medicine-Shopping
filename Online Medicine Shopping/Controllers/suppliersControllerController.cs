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
    public class suppliersController : Controller
    {
        private OMSDBContext db = new OMSDBContext();

        // GET: suppliers
        public ActionResult Index()
        {
            return View(db.suppliers.ToList());
        }


        // GET: suppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,location,email")] supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.suppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

       



       

       
    }
}
