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
    public class SliderConfig : EntityTypeConfiguration<Slider>
    {
        public SliderConfig()
        {
            this.ToTable("slider");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.TitleName).IsRequired().HasMaxLength(100);
            this.Property(x => x.URLSilder).IsRequired();
            this.Property(x => x.URLSilder).IsOptional();
            this.Property(x => x.Description).IsOptional().IsMaxLength();
        }
    }
}