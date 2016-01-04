using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Matrix.Company.DomainClasses
{
    public class Role
    {
        public Role()
        {
            Users = new List<User>();
        }

        public int RoleId { get; set; }

        [Display(Name = "نام نقش")]
        [Required(ErrorMessage = "لطفا نام نقش را وارد کنید.")]
        public string RoleName { get; set; }

        [Display(Name = "توضیحات")]
        [DataType(DataType.MultilineText)]
        public string RoleDescription { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}