using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Matrix.Company.DomainClasses.Poll
{
    public class QuestionPoll
    {
        public int Id { get; set; }

        [Display(Name = "سوال نظرسنجی")]
        public string QuestionText { get; set; }

        [Display(Name = "وضیعت انتشار")]
        public bool Sataus { get; set; }

        public virtual ICollection<OptionPoll> OptionPoll { get; set; }
    }
}