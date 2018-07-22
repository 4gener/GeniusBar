namespace GeniusBar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "SYSTEM.Authorizations",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "SYSTEM.Role_Authorization",
                c => new
                    {
                        Role_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Auth_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.Role_ID, t.Auth_ID })
                .ForeignKey("SYSTEM.Authorizations", t => t.Auth_ID, cascadeDelete: true)
                .ForeignKey("SYSTEM.Roles", t => t.Role_ID, cascadeDelete: true)
                .Index(t => t.Role_ID)
                .Index(t => t.Auth_ID);
            
            CreateTable(
                "SYSTEM.Roles",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "SYSTEM.Users",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 60),
                        Role_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("SYSTEM.Roles", t => t.Role_ID, cascadeDelete: true)
                .Index(t => t.Role_ID);
            
            CreateTable(
                "SYSTEM.RecycleOrders",
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
                .ForeignKey("SYSTEM.Users", t => t.Customer_ID, cascadeDelete: true)
                .ForeignKey("SYSTEM.Users", t => t.Engineer_ID, cascadeDelete: true)
                .ForeignKey("SYSTEM.Users", t => t.User_ID)
                .Index(t => t.Customer_ID)
                .Index(t => t.Engineer_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "SYSTEM.RecycleOrder_RecycleEvaluatonChoice",
                c => new
                    {
                        Rec_order_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Rec_eval_choice_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.Rec_order_ID, t.Rec_eval_choice_ID })
                .ForeignKey("SYSTEM.RecycleEvaluationChoices", t => t.Rec_eval_choice_ID, cascadeDelete: true)
                .ForeignKey("SYSTEM.RecycleOrders", t => t.Rec_order_ID, cascadeDelete: true)
                .Index(t => t.Rec_order_ID)
                .Index(t => t.Rec_eval_choice_ID);
            
            CreateTable(
                "SYSTEM.RecycleEvaluationChoices",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Discreet_value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("SYSTEM.RecycleEvaluationCategories", t => t.Category_ID, cascadeDelete: true)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "SYSTEM.RecycleEvaluationCategories",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        TIMG_url = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 200),
                        Model_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("SYSTEM.LaptopModels", t => t.Model_ID, cascadeDelete: true)
                .Index(t => t.Model_ID);
            
            CreateTable(
                "SYSTEM.LaptopModels",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Rec_base_value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TIMG_url = c.String(nullable: false, maxLength: 100),
                        Brand_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("SYSTEM.LaptopBrands", t => t.Brand_ID, cascadeDelete: true)
                .Index(t => t.Brand_ID);
            
            CreateTable(
                "SYSTEM.LaptopBrands",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        TIMG_url = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "SYSTEM.RepairChoices",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Model_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("SYSTEM.LaptopModels", t => t.Model_ID, cascadeDelete: true)
                .ForeignKey("SYSTEM.RepairCategories", t => t.Category_ID, cascadeDelete: true)
                .Index(t => t.Category_ID)
                .Index(t => t.Model_ID);
            
            CreateTable(
                "SYSTEM.RepairCategories",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        TIMG_url = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "SYSTEM.RepairOrder_RepairChoice",
                c => new
                    {
                        Rep_order_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Rep_choice_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => new { t.Rep_order_ID, t.Rep_choice_ID })
                .ForeignKey("SYSTEM.RepairChoices", t => t.Rep_choice_ID, cascadeDelete: true)
                .ForeignKey("SYSTEM.RepairOrders", t => t.Rep_order_ID, cascadeDelete: true)
                .Index(t => t.Rep_order_ID)
                .Index(t => t.Rep_choice_ID);
            
            CreateTable(
                "SYSTEM.RepairOrders",
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
                .ForeignKey("SYSTEM.Coupons", t => t.Coupon_ID, cascadeDelete: true)
                .ForeignKey("SYSTEM.Users", t => t.Customer_ID, cascadeDelete: true)
                .ForeignKey("SYSTEM.Users", t => t.Engineer_ID, cascadeDelete: true)
                .ForeignKey("SYSTEM.Users", t => t.User_ID)
                .Index(t => t.Customer_ID)
                .Index(t => t.Coupon_ID)
                .Index(t => t.Engineer_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "SYSTEM.Coupons",
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
                "SYSTEM.ServiceAddresses",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Loc_name = c.String(nullable: false, maxLength: 200),
                        Loc_detail = c.String(nullable: false, maxLength: 200),
                        Customer_ID = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("SYSTEM.Users", t => t.Customer_ID, cascadeDelete: true)
                .Index(t => t.Customer_ID);
            
            CreateTable(
                "SYSTEM.WebBanners",
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
            DropForeignKey("SYSTEM.ServiceAddresses", "Customer_ID", "SYSTEM.Users");
            DropForeignKey("SYSTEM.Users", "Role_ID", "SYSTEM.Roles");
            DropForeignKey("SYSTEM.RepairOrders", "User_ID", "SYSTEM.Users");
            DropForeignKey("SYSTEM.RecycleOrders", "User_ID", "SYSTEM.Users");
            DropForeignKey("SYSTEM.RecycleOrders", "Engineer_ID", "SYSTEM.Users");
            DropForeignKey("SYSTEM.RecycleOrders", "Customer_ID", "SYSTEM.Users");
            DropForeignKey("SYSTEM.RecycleOrder_RecycleEvaluatonChoice", "Rec_order_ID", "SYSTEM.RecycleOrders");
            DropForeignKey("SYSTEM.RecycleOrder_RecycleEvaluatonChoice", "Rec_eval_choice_ID", "SYSTEM.RecycleEvaluationChoices");
            DropForeignKey("SYSTEM.RecycleEvaluationChoices", "Category_ID", "SYSTEM.RecycleEvaluationCategories");
            DropForeignKey("SYSTEM.RecycleEvaluationCategories", "Model_ID", "SYSTEM.LaptopModels");
            DropForeignKey("SYSTEM.RepairOrders", "Engineer_ID", "SYSTEM.Users");
            DropForeignKey("SYSTEM.RepairOrders", "Customer_ID", "SYSTEM.Users");
            DropForeignKey("SYSTEM.RepairOrder_RepairChoice", "Rep_order_ID", "SYSTEM.RepairOrders");
            DropForeignKey("SYSTEM.RepairOrders", "Coupon_ID", "SYSTEM.Coupons");
            DropForeignKey("SYSTEM.RepairOrder_RepairChoice", "Rep_choice_ID", "SYSTEM.RepairChoices");
            DropForeignKey("SYSTEM.RepairChoices", "Category_ID", "SYSTEM.RepairCategories");
            DropForeignKey("SYSTEM.RepairChoices", "Model_ID", "SYSTEM.LaptopModels");
            DropForeignKey("SYSTEM.LaptopModels", "Brand_ID", "SYSTEM.LaptopBrands");
            DropForeignKey("SYSTEM.Role_Authorization", "Role_ID", "SYSTEM.Roles");
            DropForeignKey("SYSTEM.Role_Authorization", "Auth_ID", "SYSTEM.Authorizations");
            DropIndex("SYSTEM.ServiceAddresses", new[] { "Customer_ID" });
            DropIndex("SYSTEM.RepairOrders", new[] { "User_ID" });
            DropIndex("SYSTEM.RepairOrders", new[] { "Engineer_ID" });
            DropIndex("SYSTEM.RepairOrders", new[] { "Coupon_ID" });
            DropIndex("SYSTEM.RepairOrders", new[] { "Customer_ID" });
            DropIndex("SYSTEM.RepairOrder_RepairChoice", new[] { "Rep_choice_ID" });
            DropIndex("SYSTEM.RepairOrder_RepairChoice", new[] { "Rep_order_ID" });
            DropIndex("SYSTEM.RepairChoices", new[] { "Model_ID" });
            DropIndex("SYSTEM.RepairChoices", new[] { "Category_ID" });
            DropIndex("SYSTEM.LaptopModels", new[] { "Brand_ID" });
            DropIndex("SYSTEM.RecycleEvaluationCategories", new[] { "Model_ID" });
            DropIndex("SYSTEM.RecycleEvaluationChoices", new[] { "Category_ID" });
            DropIndex("SYSTEM.RecycleOrder_RecycleEvaluatonChoice", new[] { "Rec_eval_choice_ID" });
            DropIndex("SYSTEM.RecycleOrder_RecycleEvaluatonChoice", new[] { "Rec_order_ID" });
            DropIndex("SYSTEM.RecycleOrders", new[] { "User_ID" });
            DropIndex("SYSTEM.RecycleOrders", new[] { "Engineer_ID" });
            DropIndex("SYSTEM.RecycleOrders", new[] { "Customer_ID" });
            DropIndex("SYSTEM.Users", new[] { "Role_ID" });
            DropIndex("SYSTEM.Role_Authorization", new[] { "Auth_ID" });
            DropIndex("SYSTEM.Role_Authorization", new[] { "Role_ID" });
            DropTable("SYSTEM.WebBanners");
            DropTable("SYSTEM.ServiceAddresses");
            DropTable("SYSTEM.Coupons");
            DropTable("SYSTEM.RepairOrders");
            DropTable("SYSTEM.RepairOrder_RepairChoice");
            DropTable("SYSTEM.RepairCategories");
            DropTable("SYSTEM.RepairChoices");
            DropTable("SYSTEM.LaptopBrands");
            DropTable("SYSTEM.LaptopModels");
            DropTable("SYSTEM.RecycleEvaluationCategories");
            DropTable("SYSTEM.RecycleEvaluationChoices");
            DropTable("SYSTEM.RecycleOrder_RecycleEvaluatonChoice");
            DropTable("SYSTEM.RecycleOrders");
            DropTable("SYSTEM.Users");
            DropTable("SYSTEM.Roles");
            DropTable("SYSTEM.Role_Authorization");
            DropTable("SYSTEM.Authorizations");
        }
    }
}
