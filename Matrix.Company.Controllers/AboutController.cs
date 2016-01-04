using System;
using System.Collections.Generic;
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
    public class AboutController : Controller
    {
        private IAboutService aboutservice;
        private IUnitOfWork uow;

        public AboutController(IAboutService _aboutservice, IUnitOfWork _uow)
        {
            this.aboutservice = _aboutservice;
            this.uow = _uow;
        }

        //
        // GET: /About/
        [HttpGet]
        public ActionResult Index()
        {
            var about = aboutservice.All(x => x.Status == true);
            return View(about);
        }

        [HttpGet]
        public ActionResult IndexAdmin()
        {
            var about = aboutservice.All()
                .Select(x => new About
                {
                    Description = x.Description.Substring(0, 200)
                });
            return View(about);
        }

        //
        // GET: /About/
        [HttpGet]
        public ViewResult Details(int id)
        {
            About about = aboutservice.Find(id);
            return View(about);
        }

        [HttpGet]
        public ViewResult DetailsAll()
        {
            return View(aboutservice.All());
        }

        //
        // GET: /About/Create/5
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /About/Create/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(About about)
        {
            if (ModelState.IsValid)
            {
                aboutservice.Add(about);
                this.uow.SaveChanges();
                return RedirectToAction("IndexAdmin", "About");
            }
            return View(about);
        }

        //
        // GET: /News/Edit/5
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            About about = aboutservice.Find(id);
            return View(about);
        }

        //
        // POST: /News/Edit/5

        [HttpPost]
        public ActionResult Edit(About about)
        {
            if (ModelState.IsValid)
            {
                aboutservice.Edit(about);
                this.uow.SaveChanges();
                return RedirectToAction("IndexAdmin", "About");
            }
            return View(about);
        }

        //
        // GET: /News/Delete/5
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            About about = aboutservice.Find(id);
            return View(about);
        }

        //
        //
        // POST: /News/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            About about = aboutservice.Find(id);
            aboutservice.Delete(about);
            this.uow.SaveChanges();
            return RedirectToAction("IndexAdmin", "About");
        }

        protected override void Dispose(bool disposing)
        {
            aboutservice.Dispose();
            base.Dispose(disposing);
        }
    }
}