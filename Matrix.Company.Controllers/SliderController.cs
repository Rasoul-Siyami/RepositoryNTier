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
    public class SliderController : Controller
    {
        private ISliderService sliderservice;
        private IUnitOfWork uow;

        public SliderController(ISliderService _sliderservice, IUnitOfWork _uow)
        {
            this.sliderservice = _sliderservice;
            this.uow = _uow;
        }

        //
        //Get: /Slider/
        public ActionResult Index()
        {
            var slide = sliderservice.All(x => x.Status == true)
                .Select(x => new Slider
                {
                    Id = x.Id,
                    TitleName = x.TitleName,
                    Image = x.Image,
                    Description = x.Description.Substring(0, 100),
                    URLSilder = x.URLSilder
                });
            return View();
        }

        [HttpGet]
        public ActionResult IndexAdmin()
        {
            var slide = sliderservice.All();
            return View(slide);
        }

        //
        // GET: /Slider/
        [HttpGet]
        public ViewResult Details(int id)
        {
            Slider slide = sliderservice.Find(id);
            return View(slide);
        }

        [HttpGet]
        public ViewResult DetailsAll()
        {
            return View(sliderservice.All());
        }

        //
        // GET: /Slider/Create/5
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Slider/Create/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Slider slide)
        {
            if (ModelState.IsValid)
            {
                sliderservice.Add(slide);
                this.uow.SaveChanges();
                return RedirectToAction("IndexAdmin", "Slider");
            }
            return View(slide);
        }

        //
        // GET: /Slider/Edit/5
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            Slider slide = sliderservice.Find(id);
            return View(slide);
        }

        //
        // POST: /Slider/Edit/5

        [HttpPost]
        public ActionResult Edit(Slider slide)
        {
            if (ModelState.IsValid)
            {
                sliderservice.Edit(slide);
                this.uow.SaveChanges();
                return RedirectToAction("IndexAdmin", "Slider");
            }
            return View(slide);
        }

        //
        // GET: /News/Delete/5
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            Slider slide = sliderservice.Find(id);
            return View(slide);
        }

        //
        //
        // POST: /News/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slide = sliderservice.Find(id);
            sliderservice.Delete(slide);
            this.uow.SaveChanges();
            return RedirectToAction("IndexAdmin", "Slider");
        }

        protected override void Dispose(bool disposing)
        {
            sliderservice.Dispose();
            base.Dispose(disposing);
        }
    }
}