namespace LinkForEmployment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add13NewTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcadimicDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        acadimicName = c.String(),
                        acadimicType = c.String(),
                        acadimicTitle = c.String(),
                        acadimicEndDate = c.DateTime(nullable: false),
                        acadimicCountry = c.String(),
                        acadimicCity = c.String(),
                        acadimicCertificate = c.String(),
                        JobSeekerId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryValue = c.String(nullable: false, maxLength: 128),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.CountryValue);
            
            CreateTable(
                "dbo.CourseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        courseTitle = c.String(),
                        courseCertificate = c.String(),
                        JobSeekerId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployerInfoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        compName = c.String(),
                        compLocation = c.String(),
                        compSize = c.String(),
                        compWorkName = c.String(),
                        JobTitle = c.String(),
                        compLogo = c.String(),
                        receiveApplay = c.Boolean(nullable: false),
                        reportAndUpdate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExamDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        examTitle = c.String(),
                        examCertificate = c.String(),
                        JobSeekerId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobSeekerInfoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        firstName = c.String(),
                        middleName = c.String(),
                        lastName = c.String(),
                        bornDate = c.DateTime(nullable: false),
                        gender = c.String(),
                        personalPhoto = c.String(),
                        country = c.String(),
                        city = c.String(),
                        street = c.String(),
                        socialStatus = c.String(),
                        phoneNumber = c.Int(nullable: false),
                        countryCode = c.String(),
                        Email = c.String(),
                        dreamJobTitle = c.String(),
                        jobField = c.String(),
                        experienceLevels = c.String(),
                        dreamJobLocation = c.String(),
                        jobTime = c.String(),
                        isYouWork = c.Boolean(nullable: false),
                        hasCourse = c.Boolean(nullable: false),
                        hasworldCert = c.Boolean(nullable: false),
                        isVoluntaryWork = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NationalityGets",
                c => new
                    {
                        NationalityValue = c.String(nullable: false, maxLength: 128),
                        NationalityName = c.String(),
                    })
                .PrimaryKey(t => t.NationalityValue);
            
            CreateTable(
                "dbo.NationalitySets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nationality = c.String(),
                        JobSeekerId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Code = c.String(),
                        JobSeekerId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        skillName = c.String(),
                        JobSeekerId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VoluntaryWorkDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        voluntaryWorkTitle = c.String(),
                        voluntaryWorkStartDate = c.DateTime(nullable: false),
                        voluntaryWorkEndDate = c.DateTime(nullable: false),
                        voluntaryWorkDescribe = c.String(),
                        voluntaryCertificate = c.String(),
                        JobSeekerId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WebSites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Website = c.String(),
                        JobSeekerId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        workStartDate = c.DateTime(nullable: false),
                        workEndDate = c.DateTime(nullable: false),
                        iWorkNow = c.Boolean(nullable: false),
                        workLocation = c.String(),
                        compName = c.String(),
                        compWork = c.String(),
                        compField = c.String(),
                        workTitle = c.String(),
                        workDescribe = c.String(),
                        workCertificate = c.String(),
                        JobSeekerId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "UserType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserType");
            DropTable("dbo.WorkDetails");
            DropTable("dbo.WebSites");
            DropTable("dbo.VoluntaryWorkDetails");
            DropTable("dbo.Skills");
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.NationalitySets");
            DropTable("dbo.NationalityGets");
            DropTable("dbo.JobSeekerInfoes");
            DropTable("dbo.ExamDetails");
            DropTable("dbo.EmployerInfoes");
            DropTable("dbo.CourseDetails");
            DropTable("dbo.Countries");
            DropTable("dbo.AcadimicDetails");
        }
    }
}
