namespace QuanLyDoAnLastest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_Tbl_Teacher2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "GuideStudent", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "GuideStudent", c => c.Int(nullable: false));
        }
    }
}
