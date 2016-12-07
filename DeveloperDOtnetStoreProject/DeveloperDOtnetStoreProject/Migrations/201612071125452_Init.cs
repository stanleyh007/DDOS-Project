namespace DeveloperDOtnetStoreProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "UserModel_Id", "dbo.UserModels");
            DropIndex("dbo.AspNetUsers", new[] { "UserModel_Id" });
            AddColumn("dbo.PurchaseModels", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.WishListModels", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "PostalCode", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "City", c => c.String(nullable: false));
            CreateIndex("dbo.PurchaseModels", "ApplicationUser_Id");
            CreateIndex("dbo.WishListModels", "ApplicationUser_Id");
            AddForeignKey("dbo.PurchaseModels", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.WishListModels", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "UserModel_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserModel_Id", c => c.Int());
            DropForeignKey("dbo.WishListModels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PurchaseModels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.WishListModels", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.PurchaseModels", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "PostalCode");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.WishListModels", "ApplicationUser_Id");
            DropColumn("dbo.PurchaseModels", "ApplicationUser_Id");
            CreateIndex("dbo.AspNetUsers", "UserModel_Id");
            AddForeignKey("dbo.AspNetUsers", "UserModel_Id", "dbo.UserModels", "Id");
        }
    }
}
