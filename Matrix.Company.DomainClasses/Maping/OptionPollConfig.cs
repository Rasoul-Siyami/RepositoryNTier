using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Matrix.Company.DomainClasses.Poll;

namespace Matrix.Company.DomainClasses.Maping
{
    public class OptionPollConfig : EntityTypeConfiguration<OptionPoll>
    {
        public OptionPollConfig()
        {
            this.ToTable("optionpoll");
            this.HasKey(p => p.Id);
            this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.OptionText).IsRequired();
        }
    }
}