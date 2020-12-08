namespace QuanLyDoAnLastest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_tbl : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Classes", "CreateDate");
            DropColumn("dbo.Specializations", "CreateDate");
            DropColumn("dbo.Industries", "CreateDate");
            DropColumn("dbo.Departments", "CreateDate");
            DropColumn("dbo.Faculties", "CreateDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Faculties", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Departments", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Industries", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Specializations", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Classes", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
