namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingCurrentSortDirectionNotHaveANotNullSortType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CurrentSortDirection", "SortType_Id", "dbo.SortTypes");
            DropIndex("dbo.CurrentSortDirection", new[] { "SortType_Id" });
            AlterColumn("dbo.CurrentSortDirection", "SortType_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.CurrentSortDirection", "SortType_Id");
            AddForeignKey("dbo.CurrentSortDirection", "SortType_Id", "dbo.SortTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CurrentSortDirection", "SortType_Id", "dbo.SortTypes");
            DropIndex("dbo.CurrentSortDirection", new[] { "SortType_Id" });
            AlterColumn("dbo.CurrentSortDirection", "SortType_Id", c => c.Int());
            CreateIndex("dbo.CurrentSortDirection", "SortType_Id");
            AddForeignKey("dbo.CurrentSortDirection", "SortType_Id", "dbo.SortTypes", "Id");
        }
    }
}
