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
    public class RolesController : Controller
    {
        private IRoleService rolservice;
        private IUnitOfWork uow;

        public RolesController(IRoleService _rolservice, IUnitOfWork _uow)
        {
            this.rolservice = _rolservice;
            this.uow = _uow;
        }

        //
        // GET: /Roles/

        [HttpGet]
        public ActionResult Index()
        {
            var rol = rolservice.All();
            return View(rol);
        }

        [HttpGet]
        public ViewResult Details(int id)
        {
            Role rol = rolservice.Find(id);
            return View(rol);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Role rol)
        {
            if (ModelState.IsValid)
            {
                rolservice.Add(rol);
                uow.SaveChanges();
                return RedirectToAction("Index", "Roles");
            }
            return View(rol);
        }

        //
        // GET: /Roles/Edit/5
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            Role rol = rolservice.Find(id);
            return View(rol);
        }

        //
        // POST: /Roles/Edit/5

        [HttpPost]
        public ActionResult Edit(Role rol)
        {
            if (ModelState.IsValid)
            {
                rolservice.Edit(rol);
                uow.SaveChanges();
                return RedirectToAction("Index", "Roles");
            }
            return View(rol);
        }

        //
        // GET: /Roles/Delete/5
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            Role rol = rolservice.Find(id);
            return View(rol);
        }

        //
        //
        // POST: /Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Role rol = rolservice.Find(id);
            rolservice.Delete(rol);
            uow.SaveChanges();
            return RedirectToAction("Index", "Roles");
        }

        protected override void Dispose(bool disposing)
        {
            rolservice.Dispose();
            base.Dispose(disposing);
        }
    }
}