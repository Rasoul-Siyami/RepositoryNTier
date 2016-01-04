using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Matrix.Company.DomainClasses
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "لطفا عنوان گروه را وارد نمایید")]
        public string CategoryTitle { get; set; }

        [Display(Name = "والد")]
        public virtual Category Parent { get; set; }

        public int? ParentId { get; set; }

        public virtual ICollection<Category> Children { get; set; }

        [Display(Name = "وضیعت انتشار")]
        public bool Status { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        // public ICollection<Article> Article { get; set; }
    }
}