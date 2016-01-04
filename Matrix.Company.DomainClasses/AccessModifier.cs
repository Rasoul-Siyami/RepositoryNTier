using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Matrix.Company.DomainClasses
{
    /// <summary>
    /// سطح دسترسی
    /// </summary>

    public enum AccessModifier
    {
        /// <summary>
        /// عمومی
        /// </summary>
        General,
        /// <summary>
        /// ثبت نام کرده
        /// </summary>
        SignUp,
        /// <summary>
        /// ویژه
        /// </summary>
        Special,
        /// <summary>
        /// مدیر
        /// </summary>
        Admin
    }
}