namespace QuanLyDoAnLastest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_tbl4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Specializations", "Address");
            DropColumn("dbo.Specializations", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Specializations", "PhoneNumber", c => c.String(maxLength: 20));
            AddColumn("dbo.Specializations", "Address", c => c.String());
        }
    }
}
