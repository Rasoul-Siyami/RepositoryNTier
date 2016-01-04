using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using Matrix.Company.DomainClasses;
using Matrix.Company.DomainClasses.Maping;
using Matrix.Company.DomainClasses.Poll;

namespace Matrix.Company.DataLayer
{
    public class Context : DbContext, IUnitOfWork
    {
        public Context()
            : base("dbcompany")
        {
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Advertise> Advertises { get; set; }

        public DbSet<Weblink> WebLinks { set; get; }

        public DbSet<Category> Categorys { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<About> About { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Slider> Sliders { get; set; }

        //public DbSet<QuestionPoll> QestionPolls { get; set; }

        //public DbSet<OptionPoll> OptionPolls { get; set; }

        //public DbSet<VotesPoll> VotesPolls { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryConfig());
            modelBuilder.Configurations.Add(new WebLinkConfig());
            modelBuilder.Configurations.Add(new ArticleConfig());
            modelBuilder.Configurations.Add(new AdvertiseConfig());
            modelBuilder.Configurations.Add(new ContactConfig());
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new RoleConfig());
            modelBuilder.Configurations.Add(new NewsConfig());
            modelBuilder.Configurations.Add(new AboutConfig());
            modelBuilder.Configurations.Add(new SliderConfig());
            //modelBuilder.Configurations.Add(new QuestionPollConfig());
            //modelBuilder.Configurations.Add(new OptionPollConfig());
            //modelBuilder.Configurations.Add(new VotesPollConfig());
            //modelBuilder.Ignore<PublishingOption>();
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException validationException)
            {
                StringBuilder errM = new StringBuilder();
                foreach (var error in validationException.EntityValidationErrors)
                {
                    var entry = error.Entry;
                    foreach (var err in error.ValidationErrors)
                    {
                        errM.AppendLine(err.ErrorMessage);
                    }
                }
                throw new Exception(errM.ToString());
            }
            catch (DbUpdateConcurrencyException concurrencyException)
            {
                //بررسی مورد اول
                var dbEntityEntry = concurrencyException.Entries.First();
                var dbPropertyValues = dbEntityEntry.GetDatabaseValues();
            }
            catch (DbUpdateException updateException)
            {
                StringBuilder errM = new StringBuilder();
                if (updateException.InnerException != null)
                    errM.AppendLine(updateException.InnerException.Message);

                foreach (var entry in updateException.Entries)
                {
                    errM.AppendLine(entry.Entity.ToString());
                }
                throw new Exception(errM.ToString());
            }
            return base.SaveChanges();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}