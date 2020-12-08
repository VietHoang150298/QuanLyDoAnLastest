namespace QuanLyDoAnLastest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_tbl1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        Email = c.String(unicode: false),
                        Password = c.String(),
                        RoleId = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 20),
                        RoleName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "RoleId", "dbo.Roles");
            DropIndex("dbo.Accounts", new[] { "RoleId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Accounts");
        }
    }
}
