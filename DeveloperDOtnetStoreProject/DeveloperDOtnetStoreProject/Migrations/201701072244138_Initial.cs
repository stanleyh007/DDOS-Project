namespace DeveloperDOtnetStoreProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasketProductModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BasketModelId = c.Int(nullable: false),
                        Pieces = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Product_ProductModelId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductModels", t => t.Product_ProductModelId)
                .ForeignKey("dbo.BasketModels", t => t.BasketModelId, cascadeDelete: true)
                .Index(t => t.BasketModelId)
                .Index(t => t.Product_ProductModelId);
            
            CreateTable(
                "dbo.ProductModels",
                c => new
                    {
                        ProductModelId = c.Int(nullable: false, identity: true),
                        NameHeader = c.String(),
                        NameDescription = c.String(),
                        Price = c.Double(nullable: false),
                        QuantityStorage = c.Int(nullable: false),
                        CategoryHModelId = c.Int(nullable: false),
                        CategoryHeaderModel_CategoryHeaderModelId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductModelId)
                .ForeignKey("dbo.CategoryHeaderModels", t => t.CategoryHeaderModel_CategoryHeaderModelId)
                .Index(t => t.CategoryHeaderModel_CategoryHeaderModelId);
            
            CreateTable(
                "dbo.CategoryHeaderModels",
                c => new
                    {
                        CategoryHeaderModelId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryHeaderModelId);
            
            CreateTable(
                "dbo.CostumerReviewModels",
                c => new
                    {
                        CostumerReviewModelId = c.Int(nullable: false, identity: true),
                        Review = c.String(),
                        StarsRating = c.Double(nullable: false),
                        UserModelId_Id = c.String(maxLength: 128),
                        ProductModel_ProductModelId = c.Int(),
                    })
                .PrimaryKey(t => t.CostumerReviewModelId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserModelId_Id)
                .ForeignKey("dbo.ProductModels", t => t.ProductModel_ProductModelId)
                .Index(t => t.UserModelId_Id)
                .Index(t => t.ProductModel_ProductModelId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        PostalCode = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PurchaseModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ProductModelId_ProductModelId = c.Int(),
                        ProductNameHeader_ProductModelId = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductModels", t => t.ProductModelId_ProductModelId)
                .ForeignKey("dbo.ProductModels", t => t.ProductNameHeader_ProductModelId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ProductModelId_ProductModelId)
                .Index(t => t.ProductNameHeader_ProductModelId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.WishListModels",
                c => new
                    {
                        WishListModelId = c.Int(nullable: false, identity: true),
                        ProductModelId_ProductModelId = c.Int(),
                        UserModelId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.WishListModelId)
                .ForeignKey("dbo.ProductModels", t => t.ProductModelId_ProductModelId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserModelId_Id)
                .Index(t => t.ProductModelId_ProductModelId)
                .Index(t => t.UserModelId_Id);
            
            CreateTable(
                "dbo.BasketModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        orderTotal = c.Double(nullable: false),
                        pieces = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryModels",
                c => new
                    {
                        CategoryModelId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CategoryHeaderModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryModelId);
            
            CreateTable(
                "dbo.CategoryItemModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HeaderName = c.String(),
                        CategoryModelId = c.Int(nullable: false),
                        ItemName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryModels", t => t.CategoryModelId, cascadeDelete: true)
                .Index(t => t.CategoryModelId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CategoryItemModels", "CategoryModelId", "dbo.CategoryModels");
            DropForeignKey("dbo.BasketProductModels", "BasketModelId", "dbo.BasketModels");
            DropForeignKey("dbo.BasketProductModels", "Product_ProductModelId", "dbo.ProductModels");
            DropForeignKey("dbo.CostumerReviewModels", "ProductModel_ProductModelId", "dbo.ProductModels");
            DropForeignKey("dbo.CostumerReviewModels", "UserModelId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.WishListModels", "UserModelId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.WishListModels", "ProductModelId_ProductModelId", "dbo.ProductModels");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PurchaseModels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PurchaseModels", "ProductNameHeader_ProductModelId", "dbo.ProductModels");
            DropForeignKey("dbo.PurchaseModels", "ProductModelId_ProductModelId", "dbo.ProductModels");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductModels", "CategoryHeaderModel_CategoryHeaderModelId", "dbo.CategoryHeaderModels");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.CategoryItemModels", new[] { "CategoryModelId" });
            DropIndex("dbo.WishListModels", new[] { "UserModelId_Id" });
            DropIndex("dbo.WishListModels", new[] { "ProductModelId_ProductModelId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.PurchaseModels", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.PurchaseModels", new[] { "ProductNameHeader_ProductModelId" });
            DropIndex("dbo.PurchaseModels", new[] { "ProductModelId_ProductModelId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.CostumerReviewModels", new[] { "ProductModel_ProductModelId" });
            DropIndex("dbo.CostumerReviewModels", new[] { "UserModelId_Id" });
            DropIndex("dbo.ProductModels", new[] { "CategoryHeaderModel_CategoryHeaderModelId" });
            DropIndex("dbo.BasketProductModels", new[] { "Product_ProductModelId" });
            DropIndex("dbo.BasketProductModels", new[] { "BasketModelId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.CategoryItemModels");
            DropTable("dbo.CategoryModels");
            DropTable("dbo.BasketModels");
            DropTable("dbo.WishListModels");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.PurchaseModels");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.CostumerReviewModels");
            DropTable("dbo.CategoryHeaderModels");
            DropTable("dbo.ProductModels");
            DropTable("dbo.BasketProductModels");
        }
    }
}
