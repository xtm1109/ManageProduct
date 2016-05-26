namespace ManageProducts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Thumbnail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Thumbnail",
                c => new
                    {
                        ThumbnailId = c.Int(nullable: false),
                        Name = c.String(),
                        Content = c.Binary(),
                        ContentType = c.String(),
                    })
                .PrimaryKey(t => t.ThumbnailId)
                .ForeignKey("dbo.Item", t => t.ThumbnailId)
                .Index(t => t.ThumbnailId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Thumbnail", "ThumbnailId", "dbo.Item");
            DropIndex("dbo.Thumbnail", new[] { "ThumbnailId" });
            DropTable("dbo.Thumbnail");
        }
    }
}
