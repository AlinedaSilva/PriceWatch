namespace PriceWatch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PriceWatchEntry",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceIndicator = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PriceWatchViewModel",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        ProductName = c.String(),
                        ProductDescription = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(),
                        LastPrice = c.Decimal(precision: 18, scale: 2),
                        PriceIndicatorGlyphicon = c.String(),
                        PriceIndicatorBgColor = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PriceWatchEntryViewModel",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceIndicator = c.Int(nullable: false),
                        PriceWatchViewModel_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PriceWatchViewModel", t => t.PriceWatchViewModel_Id)
                .Index(t => t.PriceWatchViewModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PriceWatchEntryViewModel", "PriceWatchViewModel_Id", "dbo.PriceWatchViewModel");
            DropIndex("dbo.PriceWatchEntryViewModel", new[] { "PriceWatchViewModel_Id" });
            DropTable("dbo.PriceWatchEntryViewModel");
            DropTable("dbo.PriceWatchViewModel");
            DropTable("dbo.PriceWatchEntry");
        }
    }
}
