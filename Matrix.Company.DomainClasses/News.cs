using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Matrix.Company.DomainClasses
{
    public class News : PublishingOption
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "عنوان خبر را مشخص کنید.")]
        [Display(Name = "عنوان خبر")]
        public string NewsTitle { get; set; }

        [Required(ErrorMessage = "نویسنده را مشخص کنید.")]
        [Display(Name = "نویسنده")]
        public string Author { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "وضیعت انتشار")]
        public bool Status { get; set; }
    }
}