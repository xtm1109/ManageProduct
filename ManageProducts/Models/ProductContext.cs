using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ManageProducts.Models {
    public class ProductContext : DbContext {
        public DbSet<Item> Items { get; set; }
        public DbSet<Thumbnail> Thumbnails { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // To create table with singular names

            modelBuilder.Entity<Item>()
                .HasOptional(i => i.Thumbnail) // Thumbnail property is optional for Item
                .WithRequired(t => t.Item); // Item property is required for Thumbnail
        }
    }
}