using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Matrix.Company.DomainClasses
{
    public class Contact
    {
        public int Id { get; set; }

        [Display(Name = "موضوع")]
        public string Subject { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا مشخصات را مشخص نمائید.")]
        public string FullName { get; set; }

        [Display(Name = "ایمیل")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "لطفا ایمیل را مشخص نمائید.")]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "لطفا توضیحات را وارد نمائید.")]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
    }
}