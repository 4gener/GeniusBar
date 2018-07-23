namespace GeniusBar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "GENIUSBAR.Authorizations",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "GENIUSBAR.Role_Authorization",
                c => new
                    {
                        Role_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Auth_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.Role_ID, t.Auth_ID })
                .ForeignKey("GENIUSBAR.Authorizations", t => t.Auth_ID, cascadeDelete: true)
                .ForeignKey("GENIUSBAR.Roles", t => t.Role_ID, cascadeDelete: true)
                .Index(t => t.Role_ID)
                .Index(t => t.Auth_ID);
            
            CreateTable(
                "GENIUSBAR.Roles",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "GENIUSBAR.Users",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 60),
                        Role_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("GENIUSBAR.Roles", t => t.Role_ID, cascadeDelete: true)
                .Index(t => t.Role_ID);
            
            CreateTable(
                "GENIUSBAR.RecycleOrders",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Create_time = c.DateTime(nullable: false),
                        Service_time = c.DateTime(nullable: false),
                        Customer_note = c.String(maxLength: 300),
                        Staff_note = c.String(maxLength: 300),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        State = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Loc_name = c.String(nullable: false, maxLength: 200),
                        Loc_detail = c.String(nullable: false, maxLength: 200),
                        Customer_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Engineer_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        User_ID = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("GENIUSBAR.Users", t => t.Customer_ID, cascadeDelete: true)
                .ForeignKey("GENIUSBAR.Users", t => t.Engineer_ID, cascadeDelete: true)
                .ForeignKey("GENIUSBAR.Users", t => t.User_ID)
                .Index(t => t.Customer_ID)
                .Index(t => t.Engineer_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "GENIUSBAR.RecycleOrder_RecycleEvaluatonChoice",
                c => new
                    {
                        Rec_order_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Rec_eval_choice_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.Rec_order_ID, t.Rec_eval_choice_ID })
                .ForeignKey("GENIUSBAR.RecycleEvaluationChoices", t => t.Rec_eval_choice_ID, cascadeDelete: true)
                .ForeignKey("GENIUSBAR.RecycleOrders", t => t.Rec_order_ID, cascadeDelete: true)
                .Index(t => t.Rec_order_ID)
                .Index(t => t.Rec_eval_choice_ID);
            
            CreateTable(
                "GENIUSBAR.RecycleEvaluationChoices",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Discreet_value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("GENIUSBAR.RecycleEvaluationCategories", t => t.Category_ID, cascadeDelete: true)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "GENIUSBAR.RecycleEvaluationCategories",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        TIMG_url = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 200),
                        Model_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("GENIUSBAR.LaptopModels", t => t.Model_ID, cascadeDelete: true)
                .Index(t => t.Model_ID);
            
            CreateTable(
                "GENIUSBAR.LaptopModels",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Rec_base_value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TIMG_url = c.String(nullable: false, maxLength: 100),
                        Brand_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("GENIUSBAR.LaptopBrands", t => t.Brand_ID, cascadeDelete: true)
                .Index(t => t.Brand_ID);
            
            CreateTable(
                "GENIUSBAR.LaptopBrands",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        TIMG_url = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "GENIUSBAR.RepairChoices",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Model_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("GENIUSBAR.LaptopModels", t => t.Model_ID, cascadeDelete: true)
                .ForeignKey("GENIUSBAR.RepairCategories", t => t.Category_ID, cascadeDelete: true)
                .Index(t => t.Category_ID)
                .Index(t => t.Model_ID);
            
            CreateTable(
                "GENIUSBAR.RepairCategories",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        TIMG_url = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "GENIUSBAR.RepairOrder_RepairChoice",
                c => new
                    {
                        Rep_order_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Rep_choice_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.Rep_order_ID, t.Rep_choice_ID })
                .ForeignKey("GENIUSBAR.RepairChoices", t => t.Rep_choice_ID, cascadeDelete: true)
                .ForeignKey("GENIUSBAR.RepairOrders", t => t.Rep_order_ID, cascadeDelete: true)
                .Index(t => t.Rep_order_ID)
                .Index(t => t.Rep_choice_ID);
            
            CreateTable(
                "GENIUSBAR.RepairOrders",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Create_time = c.DateTime(nullable: false),
                        Service_time = c.DateTime(nullable: false),
                        Customer_note = c.String(maxLength: 300),
                        Staff_note = c.String(maxLength: 300),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        State = c.Decimal(nullable: false, precision: 3, scale: 0),
                        Loc_name = c.String(nullable: false, maxLength: 200),
                        Loc_detail = c.String(nullable: false, maxLength: 200),
                        Customer_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Coupon_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Engineer_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        User_ID = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("GENIUSBAR.Coupons", t => t.Coupon_ID, cascadeDelete: true)
                .ForeignKey("GENIUSBAR.Users", t => t.Customer_ID, cascadeDelete: true)
                .ForeignKey("GENIUSBAR.Users", t => t.Engineer_ID, cascadeDelete: true)
                .ForeignKey("GENIUSBAR.Users", t => t.User_ID)
                .Index(t => t.Customer_ID)
                .Index(t => t.Coupon_ID)
                .Index(t => t.Engineer_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "GENIUSBAR.Coupons",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Type = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        State = c.Decimal(nullable: false, precision: 3, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "GENIUSBAR.ServiceAddresses",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Loc_name = c.String(nullable: false, maxLength: 200),
                        Loc_detail = c.String(nullable: false, maxLength: 200),
                        Customer_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("GENIUSBAR.Users", t => t.Customer_ID, cascadeDelete: true)
                .Index(t => t.Customer_ID);
            
            CreateTable(
                "GENIUSBAR.WebBanners",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Image = c.String(nullable: false, maxLength: 100),
                        If_show = c.Decimal(nullable: false, precision: 1, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("GENIUSBAR.ServiceAddresses", "Customer_ID", "GENIUSBAR.Users");
            DropForeignKey("GENIUSBAR.Users", "Role_ID", "GENIUSBAR.Roles");
            DropForeignKey("GENIUSBAR.RepairOrders", "User_ID", "GENIUSBAR.Users");
            DropForeignKey("GENIUSBAR.RecycleOrders", "User_ID", "GENIUSBAR.Users");
            DropForeignKey("GENIUSBAR.RecycleOrders", "Engineer_ID", "GENIUSBAR.Users");
            DropForeignKey("GENIUSBAR.RecycleOrders", "Customer_ID", "GENIUSBAR.Users");
            DropForeignKey("GENIUSBAR.RecycleOrder_RecycleEvaluatonChoice", "Rec_order_ID", "GENIUSBAR.RecycleOrders");
            DropForeignKey("GENIUSBAR.RecycleOrder_RecycleEvaluatonChoice", "Rec_eval_choice_ID", "GENIUSBAR.RecycleEvaluationChoices");
            DropForeignKey("GENIUSBAR.RecycleEvaluationChoices", "Category_ID", "GENIUSBAR.RecycleEvaluationCategories");
            DropForeignKey("GENIUSBAR.RecycleEvaluationCategories", "Model_ID", "GENIUSBAR.LaptopModels");
            DropForeignKey("GENIUSBAR.RepairOrders", "Engineer_ID", "GENIUSBAR.Users");
            DropForeignKey("GENIUSBAR.RepairOrders", "Customer_ID", "GENIUSBAR.Users");
            DropForeignKey("GENIUSBAR.RepairOrder_RepairChoice", "Rep_order_ID", "GENIUSBAR.RepairOrders");
            DropForeignKey("GENIUSBAR.RepairOrders", "Coupon_ID", "GENIUSBAR.Coupons");
            DropForeignKey("GENIUSBAR.RepairOrder_RepairChoice", "Rep_choice_ID", "GENIUSBAR.RepairChoices");
            DropForeignKey("GENIUSBAR.RepairChoices", "Category_ID", "GENIUSBAR.RepairCategories");
            DropForeignKey("GENIUSBAR.RepairChoices", "Model_ID", "GENIUSBAR.LaptopModels");
            DropForeignKey("GENIUSBAR.LaptopModels", "Brand_ID", "GENIUSBAR.LaptopBrands");
            DropForeignKey("GENIUSBAR.Role_Authorization", "Role_ID", "GENIUSBAR.Roles");
            DropForeignKey("GENIUSBAR.Role_Authorization", "Auth_ID", "GENIUSBAR.Authorizations");
            DropIndex("GENIUSBAR.ServiceAddresses", new[] { "Customer_ID" });
            DropIndex("GENIUSBAR.RepairOrders", new[] { "User_ID" });
            DropIndex("GENIUSBAR.RepairOrders", new[] { "Engineer_ID" });
            DropIndex("GENIUSBAR.RepairOrders", new[] { "Coupon_ID" });
            DropIndex("GENIUSBAR.RepairOrders", new[] { "Customer_ID" });
            DropIndex("GENIUSBAR.RepairOrder_RepairChoice", new[] { "Rep_choice_ID" });
            DropIndex("GENIUSBAR.RepairOrder_RepairChoice", new[] { "Rep_order_ID" });
            DropIndex("GENIUSBAR.RepairChoices", new[] { "Model_ID" });
            DropIndex("GENIUSBAR.RepairChoices", new[] { "Category_ID" });
            DropIndex("GENIUSBAR.LaptopModels", new[] { "Brand_ID" });
            DropIndex("GENIUSBAR.RecycleEvaluationCategories", new[] { "Model_ID" });
            DropIndex("GENIUSBAR.RecycleEvaluationChoices", new[] { "Category_ID" });
            DropIndex("GENIUSBAR.RecycleOrder_RecycleEvaluatonChoice", new[] { "Rec_eval_choice_ID" });
            DropIndex("GENIUSBAR.RecycleOrder_RecycleEvaluatonChoice", new[] { "Rec_order_ID" });
            DropIndex("GENIUSBAR.RecycleOrders", new[] { "User_ID" });
            DropIndex("GENIUSBAR.RecycleOrders", new[] { "Engineer_ID" });
            DropIndex("GENIUSBAR.RecycleOrders", new[] { "Customer_ID" });
            DropIndex("GENIUSBAR.Users", new[] { "Role_ID" });
            DropIndex("GENIUSBAR.Role_Authorization", new[] { "Auth_ID" });
            DropIndex("GENIUSBAR.Role_Authorization", new[] { "Role_ID" });
            DropTable("GENIUSBAR.WebBanners");
            DropTable("GENIUSBAR.ServiceAddresses");
            DropTable("GENIUSBAR.Coupons");
            DropTable("GENIUSBAR.RepairOrders");
            DropTable("GENIUSBAR.RepairOrder_RepairChoice");
            DropTable("GENIUSBAR.RepairCategories");
            DropTable("GENIUSBAR.RepairChoices");
            DropTable("GENIUSBAR.LaptopBrands");
            DropTable("GENIUSBAR.LaptopModels");
            DropTable("GENIUSBAR.RecycleEvaluationCategories");
            DropTable("GENIUSBAR.RecycleEvaluationChoices");
            DropTable("GENIUSBAR.RecycleOrder_RecycleEvaluatonChoice");
            DropTable("GENIUSBAR.RecycleOrders");
            DropTable("GENIUSBAR.Users");
            DropTable("GENIUSBAR.Roles");
            DropTable("GENIUSBAR.Role_Authorization");
            DropTable("GENIUSBAR.Authorizations");
        }
    }
}
