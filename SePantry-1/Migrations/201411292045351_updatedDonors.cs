namespace SePantry_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedDonors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        EmailAddress = c.String(),
                        DateRegistered = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.DonorModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DonorModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        EmailAddress = c.String(),
                        Date = c.DateTime(nullable: false),
                        category = c.String(nullable: false),
                        title = c.String(nullable: false),
                        isCanned = c.Boolean(nullable: false),
                        product_code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Donors");
        }
    }
}
