namespace Demo.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCouches : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Couches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Couches", "TeamId", "dbo.Teams");
            DropIndex("dbo.Couches", new[] { "TeamId" });
            DropTable("dbo.Couches");
        }
    }
}
