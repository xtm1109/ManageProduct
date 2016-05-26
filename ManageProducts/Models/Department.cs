using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManageProducts.Models {
    public class Department {
        public int DepartmentId { get; set; }

        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}