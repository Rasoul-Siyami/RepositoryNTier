using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DotNetOpenAuth.AspNet;
using Matrix.Company.Common.Captcha;
using Matrix.Company.Controllers;
using Matrix.Company.Controllers.Filters;
using Matrix.Company.DataLayer;
using Matrix.Company.DataLayer.Migrations;
using Matrix.Company.DomainClasses;
using Matrix.Company.ServiceLayer.Contracts;
using Matrix.Company.ServiceLayer.Service;
using Matrix.Company.UI.App_Start;
using Microsoft.Web.WebPages.OAuth;
using StructureMap;
using WebMatrix.WebData;

namespace Matrix.Company.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode,
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // GlobalFilters.Filters.Add(new AuthorizationFilteA() { Order = 2 });
            //view Engin Razor
            MvcHandler.DisableMvcResponseHeader = true;
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            
            //Migration
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>());

            //StructureMap
            initStructureMap();
            AreaRegistration.RegisterAllAreas();
            
            //Automapper
            AutoMapperWebConfiguration.Configure();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            ModelBinders.Binders.Add(typeof(DateTime), new PersianDateModelBinder());
            
        }

        private static void initStructureMap()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<IUnitOfWork>().HttpContextScoped().Use(() => new Context());
                x.For<IAboutService>().Use<AboutService>();
                x.For<IWeblinkService>().Use<WeblinkService>();
                //x.For<IAdvertiseService>().Use<AdvertiseService>();
                //x.For<IArticleService>().Use<ArticleService>();
                x.For<IContactService>().Use<ContactService>();
                x.For<IUserService>().Use<UserService>();
                x.For<IRoleService>().Use<RolesService>();
                //x.For<ICategoryService>().Use<CategoryService>();
                x.For<INewsService>().Use<NewsService>();
                x.For<ISliderService>().Use<SliderService>();
                /* x.For<IThirdEntity>().Use<ThirdEntity>();*/
            });

            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects();
        }

        public class StructureMapControllerFactory : DefaultControllerFactory
        {
            protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
            {
                return ObjectFactory.GetInstance(controllerType) as Controller;
            }
        }
    }
}