namespace FishTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Catch", "SpeciesId", "dbo.FishSpecies");
            DropIndex("dbo.Catch", new[] { "SpeciesId" });
            AddColumn("dbo.Catch", "FishSpecies_SpeciesId", c => c.Int());
            CreateIndex("dbo.Catch", "FishSpecies_SpeciesId");
            AddForeignKey("dbo.Catch", "FishSpecies_SpeciesId", "dbo.FishSpecies", "SpeciesId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Catch", "FishSpecies_SpeciesId", "dbo.FishSpecies");
            DropIndex("dbo.Catch", new[] { "FishSpecies_SpeciesId" });
            DropColumn("dbo.Catch", "FishSpecies_SpeciesId");
            CreateIndex("dbo.Catch", "SpeciesId");
            AddForeignKey("dbo.Catch", "SpeciesId", "dbo.FishSpecies", "SpeciesId", cascadeDelete: true);
        }
    }
}
