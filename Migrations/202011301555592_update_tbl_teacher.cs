namespace QuanLyDoAnLastest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_tbl_teacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "GuideStudent", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "GuideStudent");
        }
    }
}
