namespace OptionWebsite.Migration.Records
{
    using DiplomaDataModel.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OptionWebsite.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migration\Records";
        }

        protected override void Seed(OptionWebsite.Models.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            List<YearTerm> yearTerms = new List<YearTerm>();
            yearTerms.Add(new YearTerm() { Year = 2015, Term = 10, IsDefault = false });
            yearTerms.Add(new YearTerm() { Year = 2015, Term = 20, IsDefault = false });
            yearTerms.Add(new YearTerm() { Year = 2015, Term = 30, IsDefault = false });
            yearTerms.Add(new YearTerm() { Year = 2016, Term = 10, IsDefault = true });

            context.YearTerms.AddRange(yearTerms);
            context.SaveChanges();



            List<Option> options = new List<Option>();
            options.Add(new Option() { Title = "Data Communications", IsActive = true });
            options.Add(new Option() { Title = "Client Server", IsActive = true });
            options.Add(new Option() { Title = "Digital Processing", IsActive = true });
            options.Add(new Option() { Title = "Information Systems", IsActive = true });
            options.Add(new Option() { Title = "Database", IsActive = false });
            options.Add(new Option() { Title = "Web & Mobile", IsActive = true });
            options.Add(new Option() { Title = "Tech Pro", IsActive = false });

            context.Options.AddRange(options);
            context.SaveChanges();
        }
    }
}
