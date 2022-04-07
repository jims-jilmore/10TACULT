namespace _10TACULT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clan",
                c => new
                    {
                        ClanID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        ClanName = c.String(nullable: false),
                        ClanDesc = c.String(nullable: false),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.ClanID)
                .ForeignKey("dbo.ApplicationUser", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
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
                        Clan_ClanID = c.Int(),
                        Session_SessionID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clan", t => t.Clan_ClanID)
                .ForeignKey("dbo.Session", t => t.Session_SessionID)
                .Index(t => t.Clan_ClanID)
                .Index(t => t.Session_SessionID);
            
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
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Developer",
                c => new
                    {
                        DevID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        DevName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DevID)
                .ForeignKey("dbo.ApplicationUser", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        GameTitle = c.String(nullable: false),
                        Genre = c.String(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        ESRB = c.String(nullable: false),
                        PublisherID = c.Int(nullable: false),
                        DevID = c.Int(nullable: false),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.GameID)
                .ForeignKey("dbo.ApplicationUser", t => t.UserID)
                .ForeignKey("dbo.Developer", t => t.DevID, cascadeDelete: true)
                .ForeignKey("dbo.Publisher", t => t.PublisherID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.PublisherID)
                .Index(t => t.DevID);
            
            CreateTable(
                "dbo.Platform",
                c => new
                    {
                        PlatformID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        PlatformName = c.String(nullable: false),
                        PlatformDeveloper = c.String(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.PlatformID)
                .ForeignKey("dbo.ApplicationUser", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Publisher",
                c => new
                    {
                        PublisherID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        PublisherName = c.String(nullable: false),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.PublisherID)
                .ForeignKey("dbo.ApplicationUser", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        TagID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        TagName = c.String(nullable: false),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                        GameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TagID)
                .ForeignKey("dbo.ApplicationUser", t => t.UserID)
                .ForeignKey("dbo.Game", t => t.GameID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.GameID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        SessionID = c.Int(nullable: false, identity: true),
                        SessionTitle = c.String(nullable: false),
                        SessionDesc = c.String(nullable: false),
                        SessionDate = c.DateTime(nullable: false),
                        UserID = c.String(maxLength: 128),
                        GameID = c.Int(nullable: false),
                        ClanID = c.Int(nullable: false),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.SessionID)
                .ForeignKey("dbo.ApplicationUser", t => t.UserID)
                .ForeignKey("dbo.Clan", t => t.ClanID, cascadeDelete: true)
                .ForeignKey("dbo.Game", t => t.GameID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.GameID)
                .Index(t => t.ClanID);
            
            CreateTable(
                "dbo.PlatformGame",
                c => new
                    {
                        Platform_PlatformID = c.Int(nullable: false),
                        Game_GameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Platform_PlatformID, t.Game_GameID })
                .ForeignKey("dbo.Platform", t => t.Platform_PlatformID, cascadeDelete: true)
                .ForeignKey("dbo.Game", t => t.Game_GameID, cascadeDelete: true)
                .Index(t => t.Platform_PlatformID)
                .Index(t => t.Game_GameID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUser", "Session_SessionID", "dbo.Session");
            DropForeignKey("dbo.Session", "GameID", "dbo.Game");
            DropForeignKey("dbo.Session", "ClanID", "dbo.Clan");
            DropForeignKey("dbo.Session", "UserID", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Tag", "GameID", "dbo.Game");
            DropForeignKey("dbo.Tag", "UserID", "dbo.ApplicationUser");
            DropForeignKey("dbo.Game", "PublisherID", "dbo.Publisher");
            DropForeignKey("dbo.Publisher", "UserID", "dbo.ApplicationUser");
            DropForeignKey("dbo.PlatformGame", "Game_GameID", "dbo.Game");
            DropForeignKey("dbo.PlatformGame", "Platform_PlatformID", "dbo.Platform");
            DropForeignKey("dbo.Platform", "UserID", "dbo.ApplicationUser");
            DropForeignKey("dbo.Game", "DevID", "dbo.Developer");
            DropForeignKey("dbo.Game", "UserID", "dbo.ApplicationUser");
            DropForeignKey("dbo.Developer", "UserID", "dbo.ApplicationUser");
            DropForeignKey("dbo.ApplicationUser", "Clan_ClanID", "dbo.Clan");
            DropForeignKey("dbo.Clan", "UserID", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.PlatformGame", new[] { "Game_GameID" });
            DropIndex("dbo.PlatformGame", new[] { "Platform_PlatformID" });
            DropIndex("dbo.Session", new[] { "ClanID" });
            DropIndex("dbo.Session", new[] { "GameID" });
            DropIndex("dbo.Session", new[] { "UserID" });
            DropIndex("dbo.Tag", new[] { "GameID" });
            DropIndex("dbo.Tag", new[] { "UserID" });
            DropIndex("dbo.Publisher", new[] { "UserID" });
            DropIndex("dbo.Platform", new[] { "UserID" });
            DropIndex("dbo.Game", new[] { "DevID" });
            DropIndex("dbo.Game", new[] { "PublisherID" });
            DropIndex("dbo.Game", new[] { "UserID" });
            DropIndex("dbo.Developer", new[] { "UserID" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUser", new[] { "Session_SessionID" });
            DropIndex("dbo.ApplicationUser", new[] { "Clan_ClanID" });
            DropIndex("dbo.Clan", new[] { "UserID" });
            DropTable("dbo.PlatformGame");
            DropTable("dbo.Session");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Tag");
            DropTable("dbo.Publisher");
            DropTable("dbo.Platform");
            DropTable("dbo.Game");
            DropTable("dbo.Developer");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Clan");
        }
    }
}
