namespace FishTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catch",
                c => new
                    {
                        CatchId = c.Int(nullable: false, identity: true),
                        SpeciesId = c.Int(nullable: false),
                        Length = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        CatchDate = c.DateTime(nullable: false),
                        LureId = c.Int(nullable: false),
                        Location = c.String(),
                        WeatherType = c.Int(nullable: false),
                        Temperature = c.Double(nullable: false),
                        AnglerId = c.Guid(nullable: false),
                        Brand_LureId = c.Int(),
                    })
                .PrimaryKey(t => t.CatchId)
                .ForeignKey("dbo.Lure", t => t.Brand_LureId)
                .ForeignKey("dbo.FishSpecies", t => t.SpeciesId, cascadeDelete: true)
                .ForeignKey("dbo.Lure", t => t.LureId, cascadeDelete: true)
                .Index(t => t.SpeciesId)
                .Index(t => t.LureId)
                .Index(t => t.Brand_LureId);
            
            CreateTable(
                "dbo.Lure",
                c => new
                    {
                        LureId = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Name = c.String(),
                        Color = c.String(),
                        TypeOfLure = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LureId);
            
            CreateTable(
                "dbo.FishSpecies",
                c => new
                    {
                        SpeciesId = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        AverageLength = c.Double(nullable: false),
                        AverageWeight = c.Double(nullable: false),
                        Description = c.String(nullable: false),
                        PreferredLures = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SpeciesId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Catch", "LureId", "dbo.Lure");
            DropForeignKey("dbo.Catch", "SpeciesId", "dbo.FishSpecies");
            DropForeignKey("dbo.Catch", "Brand_LureId", "dbo.Lure");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Catch", new[] { "Brand_LureId" });
            DropIndex("dbo.Catch", new[] { "LureId" });
            DropIndex("dbo.Catch", new[] { "SpeciesId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.FishSpecies");
            DropTable("dbo.Lure");
            DropTable("dbo.Catch");
        }
    }
}
