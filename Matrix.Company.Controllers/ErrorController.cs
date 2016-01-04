using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Matrix.Company.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// خطای 403 از خطاهای رایج بوده و زمانی که یک وب سرویس بنا
        /// به دلایلی دسترسی شمارا محدود کند، این کد را باز می گرداند.
        /// </summary>
        /// <returns></returns>
        public ActionResult Forbidden()
        {
            return View();
        }

        /// <summary>
        /// خطای 404 به معنای یافت نشد خطایی است که به کاربر اعلام می کند صفحه ای که در آن هستید در سایت وجود ندارد.
        /// </summary>
        /// <returns></returns>
        public ActionResult NotFound()
        {
            return View();
        }

        /// <summary>
        /// برخی اوقات وب سایت شما load نمیشود و با خطای internal server error یا همان خطای شماره ی 500 مواجه میشود.
        /// </summary>
        /// <returns></returns>
        public ActionResult Internalerror()
        {
            return View();
        }
    }
}