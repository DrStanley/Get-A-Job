namespace Get_A_Job.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobOffer1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOffers", "Image", c => c.Binary());
            DropColumn("dbo.JobOffers", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobOffers", "State", c => c.String());
            DropColumn("dbo.JobOffers", "Image");
        }
    }
}
