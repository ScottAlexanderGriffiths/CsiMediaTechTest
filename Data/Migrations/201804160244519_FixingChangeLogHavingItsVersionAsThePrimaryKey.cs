namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingChangeLogHavingItsVersionAsThePrimaryKey : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ChangeLogs_Values");
            DropTable("dbo.ChangeLogs");

            CreateTable(
                "dbo.ChangeLogs",
                c => new
                {
                    Id = c.Int(nullable: false, identity:true),
                    Version = c.Int(nullable: false),
                    TimeTaken = c.Long(nullable: false),
                    SortType_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SortTypes", t => t.SortType_Id)
                .Index(t => t.SortType_Id);

            CreateTable(
                "dbo.ChangeLogs_Values",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Position = c.Int(nullable: false),
                    ChangeLog_Id = c.Int(),
                    Value_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChangeLogs", t => t.ChangeLog_Id)
                .ForeignKey("dbo.Values", t => t.Value_Id)
                .Index(t => t.ChangeLog_Id)
                .Index(t => t.Value_Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.ChangeLogs_Values");
            DropTable("dbo.ChangeLogs");

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
    }
}
