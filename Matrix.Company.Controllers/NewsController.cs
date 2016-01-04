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
    public class NewsController : Controller
    {
        private INewsService newsservice;
        private IUnitOfWork uow;

        public NewsController(INewsService _newsservice, IUnitOfWork _uow)
        {
            this.newsservice = _newsservice;
            this.uow = _uow;
        }

        //
        // GET: /News/
        [HttpGet]
        public ActionResult Index()
        {
            var news = newsservice.All(x => x.Status == true)
                .Select(x => new News
                {
                    Id = x.Id,
                    Description = x.Description.Substring(0, 300),
                    NewsTitle = x.NewsTitle,
                    Author = x.Author,
                    CreatedOnPersian = x.CreatedOnPersian
                })
                    .OrderByDescending(x => x.CreatedOnPersian);

            return View(news);
        }

        //
        // GET: /News/
        [HttpGet]
        public ActionResult Readmore(int id)
        {
            News news = newsservice.Find(id);
            return View(news);
        }

        [HttpGet]
        public ActionResult IndexAdmin()
        {
            var news = newsservice.All();
            return View(news);
        }

        //
        // GET: /News/
        [HttpGet]
        public ViewResult Details(int id)
        {
            News news = newsservice.Find(id);
            return View(news);
        }

        [HttpGet]
        public ViewResult DetailsAll()
        {
            return View(newsservice.All());
        }

        //
        // GET: /News/Create/5
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /News/Create/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {
                newsservice.Add(news);
                this.uow.SaveChanges();
                return RedirectToAction("IndexAdmin", "News");
            }
            return View(news);
        }

        //
        // GET: /News/Edit/5
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            News news = newsservice.Find(id);
            return View(news);
        }

        //
        // POST: /News/Edit/5

        [HttpPost]
        public ActionResult Edit(News news)
        {
            if (ModelState.IsValid)
            {
                newsservice.Edit(news);
                this.uow.SaveChanges();
                return RedirectToAction("IndexAdmin", "News");
            }
            return View(news);
        }

        //
        // GET: /News/Delete/5
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            News news = newsservice.Find(id);
            return View(news);
        }

        //
        //
        // POST: /News/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = newsservice.Find(id);
            newsservice.Delete(news);
            this.uow.SaveChanges();
            return RedirectToAction("IndexAdmin", "News");
        }

        protected override void Dispose(bool disposing)
        {
            newsservice.Dispose();
            base.Dispose(disposing);
        }
    }
}