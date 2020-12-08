namespace QuanLyDoAnLastest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_tbl5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        EnrollmentId = c.Int(nullable: false, identity: true),
                        StudentCode = c.String(maxLength: 128),
                        TeacherCode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EnrollmentId)
                .ForeignKey("dbo.Students", t => t.StudentCode)
                .ForeignKey("dbo.Teachers", t => t.TeacherCode)
                .Index(t => t.StudentCode)
                .Index(t => t.TeacherCode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollment", "TeacherCode", "dbo.Teachers");
            DropForeignKey("dbo.Enrollment", "StudentCode", "dbo.Students");
            DropIndex("dbo.Enrollment", new[] { "TeacherCode" });
            DropIndex("dbo.Enrollment", new[] { "StudentCode" });
            DropTable("dbo.Enrollment");
        }
    }
}
