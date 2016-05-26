using ManageProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ManageProducts.Controllers {
    public class BrowseItemController : Controller {
        private ProductContext db = new ProductContext();

        public ActionResult Index(string dpmtName) {
            // Query for the requested Department
            var query = from dpmt in db.Departments
                        where dpmt.Name.Equals(dpmtName)
                        select dpmt;

            // Get the requested Department
            var get_dpmt = query.FirstOrDefault();

            if (get_dpmt != null) { // The requested Department is existed
                // Get all items in the requested Department
                var items = from i in db.Items
                            where i.DepartmentId == get_dpmt.DepartmentId
                            select i;

                return View(get_dpmt);
            }

            return View();
        }

        public ActionResult ViewDetail(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Retrieve Item with its Thumbnail
            Item item = db.Items.Include(i => i.Thumbnail).SingleOrDefault(i => i.ItemId == id);
            
            if (item == null) {
                return HttpNotFound();
            }
            return View(item);
        }
    }
}