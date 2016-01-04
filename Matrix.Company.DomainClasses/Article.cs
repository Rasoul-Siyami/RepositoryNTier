using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Matrix.Company.DomainClasses
{
    public class Article : PublishingOption
    {
        public int Id { get; set; }

        [Display(Name = "عنوان مقاله")]
        [Required(ErrorMessage = "لطفا عنوان مقاله را مشخص نمائید.")]
        public string ArticleTitle { get; set; }

        //[Display(Name = "والد")]
        //public virtual Category Parent { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "وضیعت انتشار")]
        public bool Status { get; set; }
    }
}