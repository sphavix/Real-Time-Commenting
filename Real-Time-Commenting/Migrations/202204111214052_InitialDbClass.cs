namespace Real_Time_Commenting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDbClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Priotrities", "Case_CaseID", c => c.Int());
            AddColumn("dbo.Status", "Case_CaseID", c => c.Int());
            AlterColumn("dbo.Cases", "ProductName", c => c.String());
            AlterColumn("dbo.Cases", "Subject", c => c.String());
            AlterColumn("dbo.Cases", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Cases", "Description", c => c.String());
            AlterColumn("dbo.Priotrities", "PriorityName", c => c.String());
            AlterColumn("dbo.Status", "StatusName", c => c.String());
            CreateIndex("dbo.Priotrities", "Case_CaseID");
            CreateIndex("dbo.Status", "Case_CaseID");
            AddForeignKey("dbo.Priotrities", "Case_CaseID", "dbo.Cases", "CaseID");
            AddForeignKey("dbo.Status", "Case_CaseID", "dbo.Cases", "CaseID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Status", "Case_CaseID", "dbo.Cases");
            DropForeignKey("dbo.Priotrities", "Case_CaseID", "dbo.Cases");
            DropIndex("dbo.Status", new[] { "Case_CaseID" });
            DropIndex("dbo.Priotrities", new[] { "Case_CaseID" });
            AlterColumn("dbo.Status", "StatusName", c => c.String(nullable: false));
            AlterColumn("dbo.Priotrities", "PriorityName", c => c.String(nullable: false));
            AlterColumn("dbo.Cases", "Description", c => c.String(nullable: false, storeType: "ntext"));
            AlterColumn("dbo.Cases", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Cases", "Subject", c => c.String(nullable: false));
            AlterColumn("dbo.Cases", "ProductName", c => c.String(nullable: false));
            DropColumn("dbo.Status", "Case_CaseID");
            DropColumn("dbo.Priotrities", "Case_CaseID");
        }
    }
}
