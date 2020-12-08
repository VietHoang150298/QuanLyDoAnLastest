namespace QuanLyDoAnLastest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_tbl2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        ClassCode = c.String(),
                        ClassName = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        SpecializationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassId)
                .ForeignKey("dbo.Specializations", t => t.SpecializationId, cascadeDelete: true)
                .Index(t => t.SpecializationId);
            
            CreateTable(
                "dbo.Specializations",
                c => new
                    {
                        SpecializationId = c.Int(nullable: false, identity: true),
                        SpecializationName = c.String(maxLength: 50),
                        Address = c.String(),
                        PhoneNumber = c.String(maxLength: 20),
                        IsDelete = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        IndustryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SpecializationId)
                .ForeignKey("dbo.Industries", t => t.IndustryId, cascadeDelete: true)
                .Index(t => t.IndustryId);
            
            CreateTable(
                "dbo.Industries",
                c => new
                    {
                        IndustryId = c.Int(nullable: false, identity: true),
                        IndustryName = c.String(maxLength: 50),
                        IsDelete = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IndustryId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(maxLength: 50),
                        Email = c.String(),
                        Address = c.String(maxLength: 255),
                        PhoneNumber = c.String(maxLength: 20),
                        IsDelete = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        FacultyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: true)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        FacultyId = c.Int(nullable: false, identity: true),
                        FacultyName = c.String(maxLength: 50),
                        Email = c.String(),
                        Address = c.String(maxLength: 255),
                        PhoneNumber = c.String(maxLength: 20),
                        IsDelete = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FacultyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "SpecializationId", "dbo.Specializations");
            DropForeignKey("dbo.Specializations", "IndustryId", "dbo.Industries");
            DropForeignKey("dbo.Industries", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "FacultyId", "dbo.Faculties");
            DropIndex("dbo.Departments", new[] { "FacultyId" });
            DropIndex("dbo.Industries", new[] { "DepartmentId" });
            DropIndex("dbo.Specializations", new[] { "IndustryId" });
            DropIndex("dbo.Classes", new[] { "SpecializationId" });
            DropTable("dbo.Faculties");
            DropTable("dbo.Departments");
            DropTable("dbo.Industries");
            DropTable("dbo.Specializations");
            DropTable("dbo.Classes");
        }
    }
}
