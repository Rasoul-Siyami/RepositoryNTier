using System.Web;
using System.Web.Mvc;
using Matrix.Company.Controllers;
using Matrix.Company.Controllers.Filters;
using Matrix.Company.DataLayer;
using Matrix.Company.DomainClasses;
using Matrix.Company.ServiceLayer;

namespace Matrix.Company.UI.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ElmahHandledErrorLoggerFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }
}