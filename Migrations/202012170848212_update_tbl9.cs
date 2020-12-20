namespace QuanLyDoAnLastest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_tbl9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubjectStudents", "IsAccept", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubjectStudents", "IsAccept");
        }
    }
}
