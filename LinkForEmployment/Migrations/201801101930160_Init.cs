namespace LinkForEmployment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.PersonalDatas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PersonalDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.String(),
                        Job = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
