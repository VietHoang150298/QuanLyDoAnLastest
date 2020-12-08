namespace QuanLyDoAnLastest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_tbl6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Teachers", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Subjects", "LastUpdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subjects", "LastUpdate");
            DropColumn("dbo.Teachers", "LastUpdate");
            DropColumn("dbo.Students", "LastUpdate");
        }
    }
}
