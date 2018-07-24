namespace GeniusBar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable_recycle_orders : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("GENIUSBAR.RecycleOrders", "Engineer_ID", "GENIUSBAR.Users");
            DropIndex("GENIUSBAR.RecycleOrders", new[] { "Engineer_ID" });
            AlterColumn("GENIUSBAR.RecycleOrders", "Engineer_ID", c => c.Decimal(precision: 10, scale: 0));
            CreateIndex("GENIUSBAR.RecycleOrders", "Engineer_ID");
            AddForeignKey("GENIUSBAR.RecycleOrders", "Engineer_ID", "GENIUSBAR.Users", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("GENIUSBAR.RecycleOrders", "Engineer_ID", "GENIUSBAR.Users");
            DropIndex("GENIUSBAR.RecycleOrders", new[] { "Engineer_ID" });
            AlterColumn("GENIUSBAR.RecycleOrders", "Engineer_ID", c => c.Decimal(nullable: false, precision: 10, scale: 0));
            CreateIndex("GENIUSBAR.RecycleOrders", "Engineer_ID");
            AddForeignKey("GENIUSBAR.RecycleOrders", "Engineer_ID", "GENIUSBAR.Users", "ID", cascadeDelete: true);
        }
    }
}
