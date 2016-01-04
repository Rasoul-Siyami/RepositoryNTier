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
    public class Slider
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "عنوان را مشخص کنید.")]
        [Display(Name = "عنوان")]
        public string TitleName { get; set; }

        [Required(ErrorMessage = "عکس را مشخص کنید.")]
        [Display(Name = "عکس")]
        public string Image { get; set; }

        [Display(Name = "لینک")]
        public string URLSilder { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "وضیعت انتشار")]
        public bool Status { get; set; }
    }
}