using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManageProducts.Models {
    public class Item {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [Display(Name = "Ngày sản xuất")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Giá")]
        public float Price { get; set; }

        // Configure 1-to-many relationship with Department
        [Display(Name = "Danh mục")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        // Configure 1-to-1 relationship with Thumbnail
        [Display(Name = "Hình ảnh")]
        public virtual Thumbnail Thumbnail { get; set; }
    }
}