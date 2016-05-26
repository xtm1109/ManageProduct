using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManageProducts.Models {
    public class Thumbnail {
        [ForeignKey("Item")] // Add property that ThumbnailId is FK of Item
        public int ThumbnailId { get; set; }

        public string Name { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }

        // Configure 1-to-1 relationship with Item
        public virtual Item Item { get; set; }
    }
}