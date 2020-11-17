namespace Get_A_Job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Applicant : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        OtherNames = c.String(),
                        Address = c.String(),
                        State = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applicants", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Applicants", new[] { "UserId" });
            DropTable("dbo.Applicants");
        }
    }
}
