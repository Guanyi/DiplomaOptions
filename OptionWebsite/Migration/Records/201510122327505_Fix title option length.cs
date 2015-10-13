namespace OptionWebsite.Migration.Records
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixtitleoptionlength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Options", "Title", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Options", "Title", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
