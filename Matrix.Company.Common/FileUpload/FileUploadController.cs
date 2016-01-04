using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Matrix.Company.Common.FileUpload
{
    public class FileUploadController : Controller
    {
        public ActionResult FileUpload()
        {
            return View();
        }

        [AllowUploadSafeFiles]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult FileUpload(HttpPostedFileBase uploadFile)
        {
            if (uploadFile.ContentLength > 0)
            {
                string filePath = Path.Combine(HttpContext.Server.MapPath("~/Content/Uploads/Document"),
                                               Path.GetFileName(uploadFile.FileName));
                uploadFile.SaveAs(filePath);
            }
            return View();
        }
    }
}