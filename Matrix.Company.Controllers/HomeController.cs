using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using DotNetOpenAuth.AspNet;
using Matrix.Company.Common.Captcha;
using Matrix.Company.Controllers;
using Matrix.Company.Controllers.Filters;
using Matrix.Company.DataLayer;
using Matrix.Company.DomainClasses;
using Matrix.Company.ServiceLayer.Contracts;
using Matrix.Company.ServiceLayer.Service;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;

namespace Matrix.Company.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 60, VaryByParam = "parametr", Location = OutputCacheLocation.None, NoStore = true, CacheProfile = "aaa")]
        public ActionResult Index(string parametr)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            string Date = pc.GetYear(DateTime.Now) + "/" + pc.GetMonth(DateTime.Now) + "/" + pc.GetDayOfMonth(DateTime.Now);
            string time = pc.GetHour(DateTime.Now) + ":" + pc.GetMinute(DateTime.Now) + ":" + pc.GetSecond(DateTime.Now);
            //ViewData["DataTime"] = "<br/>" + DateTime.Now;
            ViewBag.Date = string.Format("{0}  {1}", Date, time);

            ViewBag.Message = "گروه مهندسی ماتریکس";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Map()
        {
            ViewBag.Message = "Your map page.";

            return View();
        }

        [HttpGet]
        public ActionResult SliderGallery()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FileUpload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
                else if (file.ContentLength > 0)
                {
                    int MaxContentLength = 1024 * 1024 * 3; //3 MB
                    string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png", ".pdf" };
                    if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                    {
                        ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                    }
                    else if (file.ContentLength > MaxContentLength)
                    {
                        ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                    }
                    else
                    {
                        //TO:DO
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Upload/Document"), fileName);
                        file.SaveAs(path);
                        ModelState.Clear();
                        ViewBag.Message = "File uploaded successfully";
                    }
                }
            }
            return View();
        }
    }
}