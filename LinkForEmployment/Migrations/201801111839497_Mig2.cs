namespace LinkForEmployment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        jobName = c.String(nullable: false),
                        jobDuration = c.String(nullable: false),
                        timeNumber = c.String(nullable: false),
                        jobsalary = c.Int(nullable: false),
                        currency = c.String(),
                        gender = c.String(),
                        country = c.String(nullable: false),
                        city = c.String(nullable: false),
                        street = c.String(nullable: false),
                        NumberDuration = c.Int(nullable: false),
                        applayDuration = c.String(),
                        applayConditions = c.String(),
                        jobDescrib = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.jobs");
        }
    }
}
