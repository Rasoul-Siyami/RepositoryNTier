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
    public class Weblink
    {
        public int Id { get; set; }

        [Display(Name = "عنوان لینک")]
        [Required(ErrorMessage = "لطفا عنوان لینک را مشخص نمائید.")]
        public string WebLinkTitle { get; set; }

        [Display(Name = "آدرس لینک")]
        [Required(ErrorMessage = "لطفا آدرس لینک را مشخص نمائید")]
        public string URL { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "وضیعت انتشار")]
        public bool Status { get; set; }
    }
}