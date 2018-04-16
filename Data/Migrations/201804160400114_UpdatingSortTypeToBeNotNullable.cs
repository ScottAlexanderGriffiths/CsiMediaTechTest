namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingSortTypeToBeNotNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChangeLogs", "SortType_Id", "dbo.SortTypes");
            DropIndex("dbo.ChangeLogs", new[] { "SortType_Id" });
            AlterColumn("dbo.ChangeLogs", "SortType_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ChangeLogs", "SortType_Id");
            AddForeignKey("dbo.ChangeLogs", "SortType_Id", "dbo.SortTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChangeLogs", "SortType_Id", "dbo.SortTypes");
            DropIndex("dbo.ChangeLogs", new[] { "SortType_Id" });
            AlterColumn("dbo.ChangeLogs", "SortType_Id", c => c.Int());
            CreateIndex("dbo.ChangeLogs", "SortType_Id");
            AddForeignKey("dbo.ChangeLogs", "SortType_Id", "dbo.SortTypes", "Id");
        }
    }
}
