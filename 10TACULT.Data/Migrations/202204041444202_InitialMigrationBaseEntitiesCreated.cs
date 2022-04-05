namespace _10TACULT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrationBaseEntitiesCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clan",
                c => new
                    {
                        ClanID = c.Int(nullable: false, identity: true),
                        ClanName = c.String(nullable: false),
                        ClanDesc = c.String(nullable: false),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Modified = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ClanID);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        GameTitle = c.String(nullable: false),
                        Genre = c.String(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        ESRB = c.String(nullable: false),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.GameID);
            
            CreateTable(
                "dbo.Platform",
                c => new
                    {
                        PlatformID = c.Int(nullable: false, identity: true),
                        PlatformName = c.String(nullable: false),
                        PlatformDeveloper = c.String(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PlatformID);
            
            CreateTable(
                "dbo.Publisher",
                c => new
                    {
                        PublisherID = c.Int(nullable: false, identity: true),
                        PublisherName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PublisherID);
            
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        SessionID = c.Int(nullable: false, identity: true),
                        SessionTitle = c.String(nullable: false),
                        SessionDesc = c.String(nullable: false),
                        SessionDate = c.DateTime(nullable: false),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Modified = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.SessionID);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        TagID = c.Int(nullable: false, identity: true),
                        TagName = c.String(nullable: false),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.TagID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tag");
            DropTable("dbo.Session");
            DropTable("dbo.Publisher");
            DropTable("dbo.Platform");
            DropTable("dbo.Game");
            DropTable("dbo.Clan");
        }
    }
}
