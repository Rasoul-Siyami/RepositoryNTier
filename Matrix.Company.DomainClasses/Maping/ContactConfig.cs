using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Matrix.Company.DomainClasses.Maping
{
    public class ContactConfig : EntityTypeConfiguration<Contact>
    {
        public ContactConfig()
        {
            this.ToTable("contact");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.FullName).IsRequired().HasMaxLength(100);
            this.Property(x => x.Subject).IsRequired().HasMaxLength(100);
            this.Property(x => x.Email).IsRequired();
            this.Property(x => x.Description).IsMaxLength();
        }
    }
}