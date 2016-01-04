using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Matrix.Company.DomainClasses.Poll
{
    public class OptionPoll
    {
        public int Id { get; set; }

        [Display(Name = "گزینه ها")]
        public string OptionText { get; set; }

        public virtual QuestionPoll QuesionPoll { get; set; }

        public virtual ICollection<VotesPoll> VotesPoll { get; set; }
    }
}