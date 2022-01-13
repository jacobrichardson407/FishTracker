namespace FishTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Catch", "Brand_LureId", "dbo.Lure");
            DropForeignKey("dbo.Catch", "LureId", "dbo.Lure");
            DropIndex("dbo.Catch", new[] { "LureId" });
            DropIndex("dbo.Catch", new[] { "Brand_LureId" });
            AddColumn("dbo.Lure", "LureBrand", c => c.String());
            AddColumn("dbo.Lure", "LureName", c => c.String());
            AddColumn("dbo.Lure", "AnglerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Lure", "Catch_CatchId", c => c.Int());
            AddColumn("dbo.Lure", "Catch_CatchId1", c => c.Int());
            AddColumn("dbo.FishSpecies", "AnglerId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Lure", "Catch_CatchId");
            CreateIndex("dbo.Lure", "Catch_CatchId1");
            AddForeignKey("dbo.Lure", "Catch_CatchId", "dbo.Catch", "CatchId");
            AddForeignKey("dbo.Lure", "Catch_CatchId1", "dbo.Catch", "CatchId");
            DropColumn("dbo.Catch", "LureId");
            DropColumn("dbo.Catch", "Brand_LureId");
            DropColumn("dbo.Lure", "Brand");
            DropColumn("dbo.Lure", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lure", "Name", c => c.String());
            AddColumn("dbo.Lure", "Brand", c => c.String());
            AddColumn("dbo.Catch", "Brand_LureId", c => c.Int());
            AddColumn("dbo.Catch", "LureId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Lure", "Catch_CatchId1", "dbo.Catch");
            DropForeignKey("dbo.Lure", "Catch_CatchId", "dbo.Catch");
            DropIndex("dbo.Lure", new[] { "Catch_CatchId1" });
            DropIndex("dbo.Lure", new[] { "Catch_CatchId" });
            DropColumn("dbo.FishSpecies", "AnglerId");
            DropColumn("dbo.Lure", "Catch_CatchId1");
            DropColumn("dbo.Lure", "Catch_CatchId");
            DropColumn("dbo.Lure", "AnglerId");
            DropColumn("dbo.Lure", "LureName");
            DropColumn("dbo.Lure", "LureBrand");
            CreateIndex("dbo.Catch", "Brand_LureId");
            CreateIndex("dbo.Catch", "LureId");
            AddForeignKey("dbo.Catch", "LureId", "dbo.Lure", "LureId", cascadeDelete: true);
            AddForeignKey("dbo.Catch", "Brand_LureId", "dbo.Lure", "LureId");
        }
    }
}
