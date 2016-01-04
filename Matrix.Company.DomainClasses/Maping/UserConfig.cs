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
    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            this.ToTable("users");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //this.Property(x => x.FirstName).IsRequired().HasMaxLength(30);
            //this.Property(x => x.LastName).IsRequired().HasMaxLength(30);
            //this.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            //this.Property(x => x.Password).IsRequired().HasMaxLength(50);
            //this.Property(x => x.Email).IsRequired();
            this.Property(x => x.FirstName).HasMaxLength(30);
            this.Property(x => x.LastName).HasMaxLength(30);
            this.Property(x => x.UserName).HasMaxLength(50);
            this.Property(x => x.Password).HasMaxLength(50);
            this.Property(x => x.Email);
            //many to many
            this.HasMany(p => p.Roles)
                .WithMany(t => t.Users)
                .Map(mc =>
                    {
                        mc.ToTable("UsersInRoles");
                        mc.MapLeftKey("RoleId");
                        mc.MapRightKey("UserId");
                    });
        }
    }
}