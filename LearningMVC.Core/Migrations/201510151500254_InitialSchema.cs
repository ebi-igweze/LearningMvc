namespace LearningMVC.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                {
                    RoleID = c.Int(nullable: false, identity: true),
                    Name = c.String()
                })
                .PrimaryKey(t => t.RoleID);

            CreateTable(
                "dbo.UserRoles",
                c => new
                {
                    UserRoleID = c.Int(nullable: false, identity: true),
                    UserID = c.Int(nullable: false),
                    RoleID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.UserRoleID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.RoleID);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    UserID = c.Int(nullable: false, identity: true),
                    Email = c.String(),
                    Password = c.String(),
                })
                .PrimaryKey(t => t.UserID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleID", "dbo.Roles");
            DropIndex("dbo.UserRoles", new[] { "RoleID" });
            DropIndex("dbo.UserRoles", new[] { "UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
        }
    }
}
