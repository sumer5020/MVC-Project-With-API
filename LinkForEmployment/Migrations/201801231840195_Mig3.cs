namespace LinkForEmployment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ideas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Category = c.String(),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.jobs", "DurationOfEmploymentContract", c => c.String(nullable: false));
            AddColumn("dbo.jobs", "WorkingHours", c => c.String(nullable: false));
            AddColumn("dbo.jobs", "SalaryPaymentPeriod", c => c.String());
            AddColumn("dbo.jobs", "DurationAvailableForApply", c => c.Int(nullable: false));
            AddColumn("dbo.jobs", "applayPeriod", c => c.String());
            AddColumn("dbo.jobs", "UserId", c => c.String());
            DropColumn("dbo.jobs", "jobDuration");
            DropColumn("dbo.jobs", "timeNumber");
            DropColumn("dbo.jobs", "gender");
            DropColumn("dbo.jobs", "NumberDuration");
            DropColumn("dbo.jobs", "applayDuration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.jobs", "applayDuration", c => c.String());
            AddColumn("dbo.jobs", "NumberDuration", c => c.Int(nullable: false));
            AddColumn("dbo.jobs", "gender", c => c.String());
            AddColumn("dbo.jobs", "timeNumber", c => c.String(nullable: false));
            AddColumn("dbo.jobs", "jobDuration", c => c.String(nullable: false));
            DropColumn("dbo.jobs", "UserId");
            DropColumn("dbo.jobs", "applayPeriod");
            DropColumn("dbo.jobs", "DurationAvailableForApply");
            DropColumn("dbo.jobs", "SalaryPaymentPeriod");
            DropColumn("dbo.jobs", "WorkingHours");
            DropColumn("dbo.jobs", "DurationOfEmploymentContract");
            DropTable("dbo.Ideas");
        }
    }
}
