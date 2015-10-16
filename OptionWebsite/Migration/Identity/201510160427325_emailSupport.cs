namespace OptionWebsite.Migration.Identity
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailSupport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Email", c => c.String());
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String());
            DropColumn("dbo.AspNetUsers", "Email");
        }
    }
}
