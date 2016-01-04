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
    public class AdvertiseConfig : EntityTypeConfiguration<Advertise>
    {
        public AdvertiseConfig()
        {
            // Primary Key
            this.HasKey(x => x.Id);

            // Properties
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.AdverTitle).IsRequired().HasMaxLength(50);
            this.Property(x => x.WebURL).IsRequired();
            this.Property(x => x.Description).IsOptional().IsMaxLength();

            // Table & Column Mappings
            this.ToTable("advertise");

            // Relationships
        }
    }
}