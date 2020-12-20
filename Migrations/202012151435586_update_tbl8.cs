namespace QuanLyDoAnLastest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_tbl8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubjectStudents",
                c => new
                    {
                        SubStuCode = c.String(nullable: false, maxLength: 128),
                        SubStuName = c.String(),
                        IsFinal = c.Boolean(),
                    })
                .PrimaryKey(t => t.SubStuCode);
            
            AddColumn("dbo.Enrollment", "SubStuCode", c => c.String(maxLength: 128));
            CreateIndex("dbo.Enrollment", "SubStuCode");
            AddForeignKey("dbo.Enrollment", "SubStuCode", "dbo.SubjectStudents", "SubStuCode");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollment", "SubStuCode", "dbo.SubjectStudents");
            DropIndex("dbo.Enrollment", new[] { "SubStuCode" });
            DropColumn("dbo.Enrollment", "SubStuCode");
            DropTable("dbo.SubjectStudents");
        }
    }
}
