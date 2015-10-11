namespace OptionWebsite.Migration.Records
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatestudentnamemaxchar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Choices", "StudentFirstName", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Choices", "StudentLastName", c => c.String(nullable: false, maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Choices", "StudentLastName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Choices", "StudentFirstName", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
