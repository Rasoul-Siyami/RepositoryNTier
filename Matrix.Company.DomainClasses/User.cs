using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Matrix.Company.DomainClasses
{
    public class User
    {
        public User()
        {
            Roles = new List<Role>();
        }

        public int Id { get; set; }

        [Display(Name = "نام")]
        //[Required(ErrorMessage = "نام کاربری باید مشخص شود")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوداگی")]
        //[Required(ErrorMessage = "نام خانوادگی باید مشخص شود")]
        public string LastName { get; set; }

        [Display(Name = "نام کاربری")]
        //[Required(ErrorMessage = "نام کاربری باید مشخص شود")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        //[Required(ErrorMessage = "ایمیل باید مشخص شود")]
        [RegularExpression(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")]
        public string Email { get; set; }

        [Display(Name = "شماره همراه")]
        //[Required(ErrorMessage = "شماره همراه باید مشخص شود")]
        public int Tele { get; set; }

        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        //[Required(ErrorMessage = "رمز عبور باید مشخص شود")]
        public string Password { get; set; }

        [Display(Name = "فعال")]
        public bool IsActive { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}