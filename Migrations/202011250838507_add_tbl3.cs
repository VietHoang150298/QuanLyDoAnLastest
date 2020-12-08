namespace QuanLyDoAnLastest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_tbl3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentCode = c.String(),
                        StudentName = c.String(),
                        Note = c.String(),
                        ClassId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .Index(t => t.ClassId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        TeacherCode = c.String(),
                        TeacherName = c.String(),
                        Note = c.String(),
                        SpecializationId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Specializations", t => t.SpecializationId, cascadeDelete: true)
                .Index(t => t.SpecializationId)
                .Index(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "SpecializationId", "dbo.Specializations");
            DropForeignKey("dbo.Teachers", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Students", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Students", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Teachers", new[] { "AccountId" });
            DropIndex("dbo.Teachers", new[] { "SpecializationId" });
            DropIndex("dbo.Students", new[] { "AccountId" });
            DropIndex("dbo.Students", new[] { "ClassId" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
        }
    }
}
