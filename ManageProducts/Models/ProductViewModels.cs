using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManageProducts.Models {
    public class AddDepartmentViewModel {
        [Required]
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }
    }

    public class AddItemViewModel {
        [Required]
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }

        [Display(Name = "Ngày sản xuất")]
        public DateTime CreatedDate { get; set; }
    }

    public class BrowseViewModel {
        public IList<Item> Items { get; set; }
    }
}