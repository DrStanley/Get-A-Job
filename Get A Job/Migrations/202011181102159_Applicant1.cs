namespace Get_A_Job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Applicant1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applicants", "Phonenumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applicants", "Phonenumber");
        }
    }
}
