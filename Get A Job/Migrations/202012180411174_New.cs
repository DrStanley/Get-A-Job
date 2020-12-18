namespace Get_A_Job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        OtherNames = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        State = c.String(),
                        CV = c.Binary(),
                        NameCV = c.String(),
                        NameLetter = c.String(),
                        Phonenumber = c.String(),
                        Letter = c.Binary(),
                        DateCreated = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                        JobID = c.Int(nullable: false),
                        jobOffers_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobOffers", t => t.jobOffers_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.jobOffers_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applications", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Applications", "jobOffers_Id", "dbo.JobOffers");
            DropIndex("dbo.Applications", new[] { "jobOffers_Id" });
            DropIndex("dbo.Applications", new[] { "UserId" });
            DropTable("dbo.Applications");
        }
    }
}
