using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Matrix.Company.DomainClasses.Poll
{
    public class VotesPoll
    {
        public int Id { get; set; }

        [Display(Name = "گزینه انتخابی")]
        public virtual OptionPoll OptionPoll { get; set; }

        public DateTime Date { get; set; }

        public string IP { get; set; }
    }
}