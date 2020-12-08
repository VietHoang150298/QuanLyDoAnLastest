namespace QuanLyDoAnLastest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_tbl7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enrollment", "LastUpdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Enrollment", "LastUpdate");
        }
    }
}
