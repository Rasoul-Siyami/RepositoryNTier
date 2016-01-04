using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Matrix.Company.DomainClasses
{
    public class About
    {
        public int Id { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "وضیعت انتشار")]
        public bool Status { get; set; }
    }
}