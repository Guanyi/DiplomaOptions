namespace OptionWebsite.Migration.Records
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InChoicetablesetYearTermtoberequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Choices", "YearTerm_YearTermId", "dbo.YearTerms");
            DropIndex("dbo.Choices", new[] { "YearTerm_YearTermId" });
            AlterColumn("dbo.Choices", "YearTerm_YearTermId", c => c.Int(nullable: false));
            CreateIndex("dbo.Choices", "YearTerm_YearTermId");
            AddForeignKey("dbo.Choices", "YearTerm_YearTermId", "dbo.YearTerms", "YearTermId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Choices", "YearTerm_YearTermId", "dbo.YearTerms");
            DropIndex("dbo.Choices", new[] { "YearTerm_YearTermId" });
            AlterColumn("dbo.Choices", "YearTerm_YearTermId", c => c.Int());
            CreateIndex("dbo.Choices", "YearTerm_YearTermId");
            AddForeignKey("dbo.Choices", "YearTerm_YearTermId", "dbo.YearTerms", "YearTermId");
        }
    }
}
