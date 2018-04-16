namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingChangeLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChangeLogs",
                c => new
                    {
                        Version = c.Int(nullable: false, identity: true),
                        TimeTaken = c.Long(nullable: false),
                        SortType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Version)
                .ForeignKey("dbo.SortTypes", t => t.SortType_Id)
                .Index(t => t.SortType_Id);
            
            CreateTable(
                "dbo.SortTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChangeLogs_Values",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position = c.Int(nullable: false),
                        ChangeLog_Version = c.Int(),
                        Value_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChangeLogs", t => t.ChangeLog_Version)
                .ForeignKey("dbo.Values", t => t.Value_Id)
                .Index(t => t.ChangeLog_Version)
                .Index(t => t.Value_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChangeLogs_Values", "Value_Id", "dbo.Values");
            DropForeignKey("dbo.ChangeLogs_Values", "ChangeLog_Version", "dbo.ChangeLogs");
            DropForeignKey("dbo.ChangeLogs", "SortType_Id", "dbo.SortTypes");
            DropIndex("dbo.ChangeLogs_Values", new[] { "Value_Id" });
            DropIndex("dbo.ChangeLogs_Values", new[] { "ChangeLog_Version" });
            DropIndex("dbo.ChangeLogs", new[] { "SortType_Id" });
            DropTable("dbo.ChangeLogs_Values");
            DropTable("dbo.SortTypes");
            DropTable("dbo.ChangeLogs");
        }
    }
}
