namespace QuanLyDoAnLastest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_tbl5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "PhoneNumber", c => c.String());
            AddColumn("dbo.Teachers", "Position", c => c.String());
            AddColumn("dbo.Teachers", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "PhoneNumber");
            DropColumn("dbo.Teachers", "Position");
            DropColumn("dbo.Students", "PhoneNumber");
        }
    }
}
