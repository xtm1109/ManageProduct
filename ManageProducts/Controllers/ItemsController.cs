using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ManageProducts.Models;

namespace ManageProducts.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: Items
        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.Department);

            return View(items.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,CreatedDate,Price,DepartmentId,Thumbnail")] Item item, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid) {
                /* If statement for checking Thumbnail 
                 * Also add Thumbnail to its database
                 */
                if (upload != null && upload.ContentLength > 0) { // User uploads an image
                    var thumbnail = new Thumbnail {
                        Name = System.IO.Path.GetFileName(upload.FileName), // Thumbnail has the same name with the image
                        ContentType = upload.ContentType                        
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream)) {
                        thumbnail.Content = reader.ReadBytes(upload.ContentLength); // Read image as array of bytes
                    }
                    item.Thumbnail = thumbnail; // Set navigational property of Item
                }                
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", item.DepartmentId);
            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Retrieve Item with its Thumbnail
            Item item = db.Items.Include(i => i.Thumbnail).SingleOrDefault(i => i.ItemId == id);

            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", item.DepartmentId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,Name,CreatedDate,Price,DepartmentId")] Item item, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid) {
                /*
                 * Query for the item again because
                 * POST only passes data that presents in the web form (data in Bind)
                 * Without querying the item again, navigation virtual property will be null
                 * In this case, Thumbnail of the item will be null if the item is not queried
                 */
                item = db.Items.Find(item.ItemId);

                /* The following If statement is for checking Thumbnail 
                 * Also add Thumbnail to its database
                 */
                if (upload != null && upload.ContentLength > 0) { // User uploads an image
                    // If Item already has a Thumbnail,
                    // remove the old one
                    if (item.Thumbnail != null) {
                        db.Thumbnails.Remove(item.Thumbnail);
                    }

                    var thumbnail = new Thumbnail {
                        Name = System.IO.Path.GetFileName(upload.FileName), // Thumbnail has the same name with the image
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream)) {
                        thumbnail.Content = reader.ReadBytes(upload.ContentLength); // Read image as array of bytes
                    }
                    item.Thumbnail = thumbnail; // Set navigational property of Item
                }
                
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", item.DepartmentId);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);

            // If Item has a Thumbnail, remove Thumbnail first
            if (item.Thumbnail != null) {
                db.Thumbnails.Remove(item.Thumbnail);
            }

            // Delete Item
            db.Items.Remove(item);
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
