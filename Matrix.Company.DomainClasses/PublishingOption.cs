using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Matrix.Company.DomainClasses
{
    public class PublishingOption
    {
        //[Required(ErrorMessage = "ثبت کننده رکورد خالی است")]
        [StringLength(maximumLength: 450, MinimumLength = 1, ErrorMessage = "نام کاربری باید بین 1 تا 450 کاراکتر باشد.")]
        [Display(Name = "ایجاد کننده")]
        public string CreatedBy { set; get; }

        //[Required(ErrorMessage = "تاریخ ایجاد خالی است")]
        [Display(Name = "تاریخ ایجاد فارسی")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "تاریخ باید حداکثر 50 کاراکتر باشد.")]
        public string CreatedOnPersian { set; get; }

        //[Required(ErrorMessage = "آخرین تاریخ به روز رسانی خالی است")]
        [Display(Name = "تاریخ بروز رسانی")]
        [DataType(DataType.Date)]
        public DateTime ModifiedOn { set; get; }

        //[Required(ErrorMessage = "ویرایش کننده رکورد خالی است")]
        [Display(Name = "ویرایش کننده")]
        //[StringLength(maximumLength: 450, MinimumLength = 1, ErrorMessage = "نام کاربری باید بین 1 تا 450 کاراکتر باشد.")]
        public string ModifiedBy { set; get; }

        [Display(Name = "تاریخ انتشار")]
        public string StartPublishing { get; set; }

        [Display(Name = "پایان انتشار")]
        public string FinishPublishing { get; set; }
    }
}