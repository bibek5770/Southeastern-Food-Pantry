namespace SePantry_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class barcodefield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Active_Product", "product_code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Active_Product", "product_code");
        }
    }
}
