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
    public class RoleConfig : EntityTypeConfiguration<Role>
    {
        public RoleConfig()
        {
            this.ToTable("Roles");
            this.HasKey(x => x.RoleId);
            this.Property(x => x.RoleId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.RoleName).IsRequired().HasMaxLength(50);
            this.Property(x => x.RoleDescription).IsOptional().IsMaxLength();
        }
    }
}