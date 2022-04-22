namespace Real_Time_Commenting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDbClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        CaseID = c.Int(nullable: false),
                        ProductName = c.String(),
                        Subject = c.String(),
                        PriorityID = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                        DateCreated = c.DateTime(),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CaseID)
                .ForeignKey("dbo.Priotrities", t => t.PriorityID, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusID, cascadeDelete: true)
                .Index(t => t.PriorityID)
                .Index(t => t.StatusID);
            
            CreateTable(
                "dbo.Priotrities",
                c => new
                    {
                        PriorityID = c.Int(nullable: false, identity: true),
                        PriorityName = c.String(),
                    })
                .PrimaryKey(t => t.PriorityID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        StatusName = c.String(),
                    })
                .PrimaryKey(t => t.StatusID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, storeType: "ntext"),
                        CommentDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CaseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cases", "StatusID", "dbo.Status");
            DropForeignKey("dbo.Cases", "PriorityID", "dbo.Priotrities");
            DropIndex("dbo.Cases", new[] { "StatusID" });
            DropIndex("dbo.Cases", new[] { "PriorityID" });
            DropTable("dbo.Comments");
            DropTable("dbo.Status");
            DropTable("dbo.Priotrities");
            DropTable("dbo.Cases");
        }
    }
}
