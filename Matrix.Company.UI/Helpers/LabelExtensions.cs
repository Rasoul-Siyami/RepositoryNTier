using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Matrix.Company.Controllers.Helpers
{
    public static class LabelExtensions
    {
        public static MvcHtmlString MyLabel(this HtmlHelper helper, string target, string text)
        {
            return MvcHtmlString.Create(string.Format("<Label for='{0}'>{1}</Label>", target, text));
        }

        public static MvcHtmlString MyNewLabel(this HtmlHelper helper, string target, string text)
        {
            var mytag = new TagBuilder("Label");
            mytag.MergeAttribute("for", target);
            mytag.InnerHtml = text;
            return MvcHtmlString.Create(mytag.ToString());
        }
    }
}