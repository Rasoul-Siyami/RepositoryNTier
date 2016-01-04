using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Matrix.Company.DataLayer;
using Matrix.Company.DomainClasses;
using Matrix.Company.ServiceLayer;
using Matrix.Company.ServiceLayer.Contracts;
using Matrix.Company.ServiceLayer.Service;
using Matrix.Company.ViewModel;

namespace Matrix.Company.Controllers
{
    public class WebLinkController : Controller
    {
        private IWeblinkService weblinkservice;
        private IUnitOfWork uow;

        public WebLinkController(IWeblinkService _weblinkservice, IUnitOfWork _uow)
        {
            this.weblinkservice = _weblinkservice;
            this.uow = _uow;
        }

        //
        // GET: /WebLink/
        //[HttpGet]
        [ChildActionOnly]
        [AllowAnonymous]
        public ActionResult Index()
        {
            var weblink = weblinkservice.All(x => x.Status == true);
            var weblinkViewModel = new List<WebLinkViewModel>();
            Mapper.Map(weblink, weblinkViewModel);
            return View("Index", weblinkViewModel);
        }

        [HttpGet]
        public ActionResult IndexAdmin()
        {
            return View(weblinkservice.All());
        }

        //
        // GET: /WebLink/Details/5
        [HttpGet]
        public ViewResult Details(int id)
        {
            Weblink weblink = weblinkservice.Find(id);
            return View(weblink);
        }

        [HttpGet]
        public ViewResult DetailsAll()
        {
            return View(weblinkservice.All());
        }

        //
        // GET: /WebLink/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /WebLink/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Weblink weblink)
        {
            if (this.ModelState.IsValid)
            {
                weblinkservice.Add(weblink);
                this.uow.SaveChanges();
                return RedirectToAction("IndexAdmin", "WebLink");
            }

            return View(weblink);
        }

        //
        // GET: /WebLink/Edit/5
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            Weblink weblink = weblinkservice.Find(id);
            return View(weblink);
        }

        //
        // POST: /WebLink/Edit/5

        [HttpPost]
        public ActionResult Edit(Weblink weblink)
        {
            if (ModelState.IsValid)
            {
                weblinkservice.Edit(weblink);
                uow.SaveChanges();
                return RedirectToAction("IndexAdmin", "WebLink");
            }
            return View(weblink);
        }

        //
        // GET: /WebLink/Delete/5
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            Weblink weblink = weblinkservice.Find(id);
            return View(weblink);
        }

        //
        //
        // POST: /WebLink/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Weblink weblink = weblinkservice.Find(id);
            weblinkservice.Delete(weblink);
            uow.SaveChanges();
            return RedirectToAction("IndexAdmin", "WebLink");
        }

        protected override void Dispose(bool disposing)
        {
            weblinkservice.Dispose();
            base.Dispose(disposing);
        }
    }
}