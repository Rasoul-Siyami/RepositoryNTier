using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Matrix.Company.ViewModel.Account
{
    public class UserProfileViewModel
    {
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "نام  باید مشخص شود")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوداگی")]
        [Required(ErrorMessage = "نام خانوادگی باید مشخص شود")]
        public string LastName { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "نام کاربری باید مشخص شود")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "ایمیل باید مشخص شود")]
        [RegularExpression(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")]
        public string Email { get; set; }

        [Display(Name = "شماره همراه")]
        [Required(ErrorMessage = "شماره همراه باید مشخص شود")]
        public int Tele { get; set; }

        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "رمز عبور باید مشخص شود")]
        public string Password { get; set; }
    }
}