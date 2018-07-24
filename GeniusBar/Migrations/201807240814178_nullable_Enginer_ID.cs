namespace GeniusBar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable_Enginer_ID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("GENIUSBAR.RepairOrders", "Coupon_ID", "GENIUSBAR.Coupons");
            DropForeignKey("GENIUSBAR.RepairOrders", "Engineer_ID", "GENIUSBAR.Users");
            DropIndex("GENIUSBAR.RepairOrders", new[] { "Coupon_ID" });
            DropIndex("GENIUSBAR.RepairOrders", new[] { "Engineer_ID" });
            AlterColumn("GENIUSBAR.RepairOrders", "Coupon_ID", c => c.Decimal(precision: 10, scale: 0));
            AlterColumn("GENIUSBAR.RepairOrders", "Engineer_ID", c => c.Decimal(precision: 10, scale: 0));
            CreateIndex("GENIUSBAR.RepairOrders", "Coupon_ID");
            CreateIndex("GENIUSBAR.RepairOrders", "Engineer_ID");
            AddForeignKey("GENIUSBAR.RepairOrders", "Coupon_ID", "GENIUSBAR.Coupons", "ID");
            AddForeignKey("GENIUSBAR.RepairOrders", "Engineer_ID", "GENIUSBAR.Users", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("GENIUSBAR.RepairOrders", "Engineer_ID", "GENIUSBAR.Users");
            DropForeignKey("GENIUSBAR.RepairOrders", "Coupon_ID", "GENIUSBAR.Coupons");
            DropIndex("GENIUSBAR.RepairOrders", new[] { "Engineer_ID" });
            DropIndex("GENIUSBAR.RepairOrders", new[] { "Coupon_ID" });
            AlterColumn("GENIUSBAR.RepairOrders", "Engineer_ID", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            AlterColumn("GENIUSBAR.RepairOrders", "Coupon_ID", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            CreateIndex("GENIUSBAR.RepairOrders", "Engineer_ID");
            CreateIndex("GENIUSBAR.RepairOrders", "Coupon_ID");
            AddForeignKey("GENIUSBAR.RepairOrders", "Engineer_ID", "GENIUSBAR.Users", "ID", cascadeDelete: true);
            AddForeignKey("GENIUSBAR.RepairOrders", "Coupon_ID", "GENIUSBAR.Coupons", "ID", cascadeDelete: true);
        }
    }
}
