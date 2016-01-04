using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.AspNet;
using Matrix.Company.Common.Captcha;
using Matrix.Company.Controllers;
using Matrix.Company.Controllers.Filters;
using Matrix.Company.DataLayer;
using Matrix.Company.DomainClasses;
using Matrix.Company.ServiceLayer.Contracts;
using Matrix.Company.ServiceLayer.Service;
using Matrix.Company.ViewModel;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;

namespace Matrix.Company.Controllers.Base
{
    public class ControllerBase<TEntity> : Controller
    {
    }
}