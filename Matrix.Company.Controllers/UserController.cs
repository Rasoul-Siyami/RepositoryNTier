using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using AutoMapper;
using DotNetOpenAuth.AspNet;
using Matrix.Company.Common.Captcha;
using Matrix.Company.Controllers;
using Matrix.Company.Controllers.Filters;
using Matrix.Company.DataLayer;
using Matrix.Company.DomainClasses;
using Matrix.Company.ServiceLayer.Contracts;
using Matrix.Company.ServiceLayer.Service;
using Matrix.Company.ViewModel.Account;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;

namespace Matrix.Company.Controllers
{
    public class UserController : Controller
    {
        private IUserService userservice;
        private IUnitOfWork uow;

        public UserController()
        {
            uow = new Context();
            this.userservice = new UserService(uow);
        }

        public UserController(IUserService _userservice, IUnitOfWork _uow)
        {
            this.userservice = _userservice;
            this.uow = _uow;
        }

        //
        // GET: /Roles/

        [HttpGet]
        public ActionResult Index()
        {
            var user = userservice.All();
            return View(user);
        }

        [HttpGet]
        public ViewResult Details(int id)
        {
            User user = userservice.Find(id);
            return View(user);
        }

        //[HttpGet]
        //public ActionResult Register()
        //{
        //    return View();
        //}

        //[HttpPost, ValidateCaptchaAttribute, ValidateAntiForgeryToken]
        //public ActionResult Register(RegisterViewModel model)
        //{
        //    if (!ModelState.IsValid) return View(model);
        //    TempData["message"] = "کد امنیتی را به درستی وارد کرده اید";
        //    return View(new RegisterViewModel { UserName = "", CaptchaInputText = "" });
        //}

        public CaptchaImageResult CaptchaImage()
        {
            return new CaptchaImageResult();
        }

        //
        //GET: /User/Create/
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateCaptchaAttribute]
        public ActionResult Create(RegisterViewModel userviewmodel)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                Mapper.Map(user, userviewmodel);
                userservice.Add(user);
                this.uow.SaveChanges();
                return RedirectToAction("Index", "Home"); ;
            }
            TempData["message"] = "کد امنیتی را به درستی وارد کرده اید";
            //return View(new RegisterViewModel { UserName = "", CaptchaInputText = "" });
            return View(userviewmodel);
        }

        //
        // GET: /User/Edit/5
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            User user = userservice.Find(id);
            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                userservice.Edit(user);
                uow.SaveChanges();
                return RedirectToAction("Index", "User");
            }
            return View(user);
        }

        //
        // GET: /User/Delete/5
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            User user = userservice.Find(id);
            return View(user);
        }

        //
        //
        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = userservice.Find(id);
            userservice.Delete(user);
            uow.SaveChanges();
            return RedirectToAction("Index", "User");
        }

        protected override void Dispose(bool disposing)
        {
            userservice.Dispose();
            base.Dispose(disposing);
        }
    }
}