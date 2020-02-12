namespace NinjaDomain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClanName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ninjas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ServedInOniwaban = c.Boolean(nullable: false),
                        ClanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Clans", t => t.ClanId, cascadeDelete: true)
                .Index(t => t.ClanId);
            
            CreateTable(
                "dbo.NinjaEquiptments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        Ninja_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ninjas", t => t.Ninja_id, cascadeDelete: true)
                .Index(t => t.Ninja_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NinjaEquiptments", "Ninja_id", "dbo.Ninjas");
            DropForeignKey("dbo.Ninjas", "ClanId", "dbo.Clans");
            DropIndex("dbo.NinjaEquiptments", new[] { "Ninja_id" });
            DropIndex("dbo.Ninjas", new[] { "ClanId" });
            DropTable("dbo.NinjaEquiptments");
            DropTable("dbo.Ninjas");
            DropTable("dbo.Clans");
        }
    }
}
