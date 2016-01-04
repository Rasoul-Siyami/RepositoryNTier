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
    public class WebLinkConfig : EntityTypeConfiguration<Weblink>
    {
        public WebLinkConfig()
        {
            this.ToTable("weblink");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.WebLinkTitle).IsRequired().HasMaxLength(100);
            this.Property(x => x.URL).IsRequired();
            this.Property(x => x.Description).IsMaxLength();
            //this.Property(x => x.RowVersion).HasColumnType("Timestamp");
        }
    }
}