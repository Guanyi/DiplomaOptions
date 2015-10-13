namespace OptionWebsite.Migration.Identity
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixapplicationdberror : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String());
        }
    }
}
