using System.IO;
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
    public class ContactController : Controller
    {
        private IContactService contactservice;
        private IUnitOfWork uow;

        //public ContactController()
        //{
        //    uow = new Context();
        //    this.contactservice = new ContactService(uow);
        //}

        public ContactController(IContactService _contactservice, IUnitOfWork _uow)
        {
            this.contactservice = _contactservice;
            this.uow = _uow;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var contact = contactservice.All();
            return View(contact);
        }

        //
        // GET: /Contact/Details/5
        [HttpGet]
        public ViewResult Details(int id)
        {
            Contact contact = contactservice.Find(id);
            return View(contact);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contactservice.Add(contact);
                uow.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(contact);
        }

        //
        // GET: /WebLink/Edit/5
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            Contact contact = contactservice.Find(id);
            return View(contact);
        }

        //
        // POST: /WebLink/Edit/5
        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contactservice.Edit(contact);
                uow.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(contact);
        }

        //
        // GET: /WebLink/Delete/5
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            Contact contact = contactservice.Find(id);
            return View(contact);
        }

        //
        //
        // POST: /WebLink/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = contactservice.Find(id);
            contactservice.Delete(contact);
            uow.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            contactservice.Dispose();
            base.Dispose(disposing);
        }

        //[Authorize]
        public ActionResult InsertData(string name)
        {
            // Check for input errors.
            if (string.IsNullOrWhiteSpace(name))
            {
                TempData["error"] = "name is required.";
                return RedirectToAction("ShowError");
            }
            // No errors
            // ...
            return View();
        }

        public ActionResult ShowError()
        {
            var error = TempData["error"] as string;
            if (!string.IsNullOrWhiteSpace(error))
            {
                ViewBag.Error = error;
            }
            return View();
        }
    }
}