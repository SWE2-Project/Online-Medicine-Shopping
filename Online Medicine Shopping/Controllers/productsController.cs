using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.IO;
using System.Web.Mvc;
using Online_Medicine_Shopping.DBContext;
using Online_Medicine_Shopping.Models;

namespace Online_Medicine_Shopping.Controllers
{
    public class productsController : Controller
    {
        private TemporaryDBContext db = new TemporaryDBContext();
        public ActionResult SearchResult(string medicine_name)
        {
            var product = from m in db.product
                          select m;

            if (!String.IsNullOrEmpty(medicine_name))
            {
                product = product.Where(s => s.name.Contains(medicine_name) || s.category.name.Contains(medicine_name) || s.Supplier.name.Contains(medicine_name));

                ViewBag.categoryName = from m in db.categories
                                       select m;
                return View(product);
            }
            else if (String.IsNullOrEmpty(medicine_name))
            {
                return View();
            }
            return View();


        }
         

        // GET: products/Create
        public ActionResult Create()
        {


            ViewBag.category_id = new SelectList(db.categories, "id", "name");
            ViewBag.supplier_id = new SelectList(db.suppliers, "id", "name");
            return View();

        }

        // POST: products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,price,quantity,category_id,supplier_id,descrition,image")] product product)
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
                        var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);
                        file.SaveAs(path);
                        product.image = fileName;
                        db.product.Add(product);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                }
            }

            ViewBag.category_id = new SelectList(db.categories, "id", "name", product.category_id);
            ViewBag.supplier_id = new SelectList(db.suppliers, "id", "name", product.supplier_id);
            return View(product);
        }
        public ActionResult Index()
        {
            if ((int)Session["type_id"] == 1)
            {
                var product = db.product.Include(p => p.category);
                return View(product.ToList());
            }
            else { return HttpNotFound(); }
        }
        // GET: products/Details/5
        public ActionResult Details(int? id)
        {
            if ((int)Session["type_id"] == 1)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                product product = db.product.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
            else { return HttpNotFound(); }
        }
        // GET: products/Edit/5
        public ActionResult Edit(int? id)
        {
            if ((int)Session["type_id"] == 1)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                product product = db.product.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                ViewBag.category_id = new SelectList(db.categories, "id", "name", product.category_id);
                return View(product);
            }
            else { return HttpNotFound(); }
        }

        // POST: products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,price,quantity,category_id,descrition,image")] product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(db.categories, "id", "name", product.category_id);
            return View(product);
        }

        // GET: products/Delete/5
        public ActionResult Delete(int? id)
        {
            if ((int)Session["type_id"] == 1)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                product product = db.product.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
            else { return HttpNotFound(); }
        }

        // POST: products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product product = db.product.Find(id);
            db.product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
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