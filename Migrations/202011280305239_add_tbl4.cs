namespace QuanLyDoAnLastest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_tbl4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Teachers", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Students", new[] { "AccountId" });
            DropIndex("dbo.Teachers", new[] { "AccountId" });
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            AddColumn("dbo.Accounts", "StudentCode", c => c.String(maxLength: 128));
            AddColumn("dbo.Accounts", "TeacherCode", c => c.String(maxLength: 128));
            CreateIndex("dbo.Accounts", "StudentCode");
            CreateIndex("dbo.Accounts", "TeacherCode");
            AddForeignKey("dbo.Accounts", "StudentCode", "dbo.Students", "StudentCode");
            AddForeignKey("dbo.Accounts", "TeacherCode", "dbo.Teachers", "TeacherCode");
            DropColumn("dbo.Students", "AccountId");
            DropColumn("dbo.Teachers", "AccountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "AccountId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "AccountId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Accounts", "TeacherCode", "dbo.Teachers");
            DropForeignKey("dbo.Accounts", "StudentCode", "dbo.Students");
            DropIndex("dbo.Accounts", new[] { "TeacherCode" });
            DropIndex("dbo.Accounts", new[] { "StudentCode" });
            DropColumn("dbo.Accounts", "TeacherCode");
            DropColumn("dbo.Accounts", "StudentCode");
            DropTable("dbo.Subjects");
            CreateIndex("dbo.Teachers", "AccountId");
            CreateIndex("dbo.Students", "AccountId");
            AddForeignKey("dbo.Teachers", "AccountId", "dbo.Accounts", "AccountId", cascadeDelete: true);
            AddForeignKey("dbo.Students", "AccountId", "dbo.Accounts", "AccountId", cascadeDelete: true);
        }
    }
}
