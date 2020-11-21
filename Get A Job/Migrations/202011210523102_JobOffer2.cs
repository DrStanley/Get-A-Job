namespace Get_A_Job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobOffer2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOffers", "AplicationRequirement", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobOffers", "AplicationRequirement");
        }
    }
}
