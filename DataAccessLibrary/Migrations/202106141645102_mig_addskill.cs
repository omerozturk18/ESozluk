namespace DataAccessLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addskill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillCardId = c.Int(nullable: false, identity: true),
                        SkillName = c.String(maxLength: 50),
                        SkillPercentage = c.String(maxLength: 3),
                        WriterId = c.Int(),
                    })
                .PrimaryKey(t => t.SkillCardId)
                .ForeignKey("dbo.Writers", t => t.WriterId)
                .Index(t => t.WriterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "WriterId", "dbo.Writers");
            DropIndex("dbo.Skills", new[] { "WriterId" });
            DropTable("dbo.Skills");
        }
    }
}
