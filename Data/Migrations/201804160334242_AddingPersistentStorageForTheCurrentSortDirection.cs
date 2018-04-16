namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingPersistentStorageForTheCurrentSortDirection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CurrentSortDirection",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SortType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SortTypes", t => t.SortType_Id)
                .Index(t => t.SortType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CurrentSortDirection", "SortType_Id", "dbo.SortTypes");
            DropIndex("dbo.CurrentSortDirection", new[] { "SortType_Id" });
            DropTable("dbo.CurrentSortDirection");
        }
    }
}
