using ManageProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageProducts.Controllers
{
    public class ThumbnailController : Controller {
        private ProductContext db = new ProductContext();

        // GET: Thumbnail
        public ActionResult Index(int id) {
            var thumbnailToRetrieve = db.Thumbnails.Find(id);
            // Return an image as FileResult
            return File(thumbnailToRetrieve.Content, thumbnailToRetrieve.ContentType);
        }
    }
}