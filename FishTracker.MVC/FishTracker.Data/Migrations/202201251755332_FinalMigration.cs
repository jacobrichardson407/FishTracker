namespace FishTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Catch", "LureId", "dbo.Lure");
            DropIndex("dbo.Catch", new[] { "LureId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Catch", "LureId");
            AddForeignKey("dbo.Catch", "LureId", "dbo.Lure", "LureId", cascadeDelete: true);
        }
    }
}
