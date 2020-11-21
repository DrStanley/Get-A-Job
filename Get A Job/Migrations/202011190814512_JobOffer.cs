namespace Get_A_Job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobOffer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position = c.String(),
                        Title = c.String(),
                        AplicationDetails = c.String(),
                        State = c.String(),
                        NoOfApplicant = c.Int(nullable: false),
                        Deadline = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOffers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.JobOffers", new[] { "UserId" });
            DropTable("dbo.JobOffers");
        }
    }
}
