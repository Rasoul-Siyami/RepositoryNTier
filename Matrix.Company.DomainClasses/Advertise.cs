using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Matrix.Company.DomainClasses
{
    public class Advertise : PublishingOption
    {
        public int Id { get; set; }

        [Display(Name = "عنوان تبلیغات")]
        [Required(ErrorMessage = "لطفا عنوان تبلیغ را مشخص نمائید.")]
        public string AdverTitle { get; set; }

        [Display(Name = "آدرس لینک")]
        [Required(ErrorMessage = "لطفا عنوان وب لینک را مشخص نمائید.")]
        public string WebURL { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "وضیعت انتشار")]
        public bool Status { get; set; }
    }
}