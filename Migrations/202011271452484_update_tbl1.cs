namespace QuanLyDoAnLastest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_tbl1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Students");
            DropPrimaryKey("dbo.Teachers");
            AlterColumn("dbo.Students", "StudentCode", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Teachers", "TeacherCode", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Students", "StudentCode");
            AddPrimaryKey("dbo.Teachers", "TeacherCode");
            DropColumn("dbo.Students", "StudentId");
            DropColumn("dbo.Teachers", "TeacherId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "TeacherId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Students", "StudentId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Teachers");
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Teachers", "TeacherCode", c => c.String());
            AlterColumn("dbo.Students", "StudentCode", c => c.String());
            AddPrimaryKey("dbo.Teachers", "TeacherId");
            AddPrimaryKey("dbo.Students", "StudentId");
        }
    }
}
