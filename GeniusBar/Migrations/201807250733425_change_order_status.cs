namespace GeniusBar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_order_status : DbMigration
    {
        public override void Up()
        {
            AlterColumn("GENIUSBAR.RepairOrders", "State", c => c.Decimal(nullable: false, precision: 10, scale: 0));
        }
        
        public override void Down()
        {
            AlterColumn("GENIUSBAR.RepairOrders", "State", c => c.Decimal(nullable: false, precision: 3, scale: 0));
        }
    }
}
