namespace GeniusBar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("GENIUSBAR.Users", "COOKIE", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("GENIUSBAR.Users", "COOKIE", c => c.String());
        }
    }
}
