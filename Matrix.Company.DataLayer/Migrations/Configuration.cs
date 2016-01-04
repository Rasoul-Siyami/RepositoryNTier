using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using Matrix.Company.DataLayer;
using Matrix.Company.DomainClasses;
using Matrix.Company.DomainClasses.Maping;

namespace Matrix.Company.DataLayer.Migrations
{
    public class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Context context)
        {
            //var cat1 = new Category { CategoryTitle = "برنامه نویسی" };
            //var cat2 = new Category { CategoryTitle = "C#", Parent = cat1 };
            //var cat3 = new Category { CategoryTitle = "lambeda", Parent = cat2 };
            //context.Categorys.Add(cat1);
            //context.Categorys.Add(cat2);
            //context.Categorys.Add(cat3);
            //context.SaveChanges();
            base.Seed(context);
        }
    }
}