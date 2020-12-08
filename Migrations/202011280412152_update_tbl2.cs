namespace QuanLyDoAnLastest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_tbl2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "ClassId", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "ClassId" });
            RenameColumn(table: "dbo.Students", name: "ClassId", newName: "ClassCode");
            DropPrimaryKey("dbo.Classes");
            AlterColumn("dbo.Students", "ClassCode", c => c.String(maxLength: 128));
            AlterColumn("dbo.Classes", "ClassCode", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Classes", "ClassCode");
            CreateIndex("dbo.Students", "ClassCode");
            AddForeignKey("dbo.Students", "ClassCode", "dbo.Classes", "ClassCode");
            DropColumn("dbo.Classes", "ClassId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Classes", "ClassId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Students", "ClassCode", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "ClassCode" });
            DropPrimaryKey("dbo.Classes");
            AlterColumn("dbo.Classes", "ClassCode", c => c.String());
            AlterColumn("dbo.Students", "ClassCode", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Classes", "ClassId");
            RenameColumn(table: "dbo.Students", name: "ClassCode", newName: "ClassId");
            CreateIndex("dbo.Students", "ClassId");
            AddForeignKey("dbo.Students", "ClassId", "dbo.Classes", "ClassId", cascadeDelete: true);
        }
    }
}
