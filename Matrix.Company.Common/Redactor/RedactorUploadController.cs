using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Matrix.Company.Common.Redactor
{
    public class RedactorUploadController : Controller
    {
        public ActionResult FileUpload(HttpPostedFileBase uploadFile)
        {
            return View();
        }

        public ActionResult ImageUpload(HttpPostedFile uploadimage)
        {
            return View();
        }

        public ActionResult FileLinkUpload(HttpPostedFile filelinkupload)
        {
            return View();
        }
    }
}