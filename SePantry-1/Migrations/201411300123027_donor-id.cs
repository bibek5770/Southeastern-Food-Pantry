namespace SePantry_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class donorid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Active_Product", "donor_id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Active_Product", "donor_id");
        }
    }
}
