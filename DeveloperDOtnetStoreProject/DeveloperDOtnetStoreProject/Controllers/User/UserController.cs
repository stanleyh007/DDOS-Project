using DeveloperDOtnetStoreProject.Models.Repositories;
using DeveloperDOtnetStoreProject.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeveloperDOtnetStoreProject.Interfaces;
using System.Net;
using Microsoft.AspNet.Identity.Owin;
using DeveloperDOtnetStoreProject.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace DeveloperDOtnetStoreProject.Controllers.User
{
    // Add new Product??? Need??

    [Authorize(Roles = "Administrator")]
    public class UserController : Controller
    {
        private UserRepository userRepo = new UserRepository();

        [AllowAnonymous]
        // Get: User
        public ActionResult Index()
        {
            return View(userRepo.GetAll());
        }

        // Get: user details
        public ActionResult Details(string id)
        {
            return View(userRepo.Find(id));
        }

        /*
        [AllowAnonymous]
        // Get: user creation
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        // Post: user creation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplicationUser model)
        {
            if (ModelState.IsValid)
            {
                // user is created
                userRepo.InsertOrUpdate(model);
            }
            return View();
        }
        */
        
        // Get: user update
        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpNotFoundResult();
            }

            ApplicationUser user = userRepo.Find(id);

            if (user == null)
            {
                return new HttpNotFoundResult();
            }

            return View(user);
        }

        // Post: user update
        [HttpPost]
        public ActionResult Edit(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                userRepo.InsertOrUpdate(user);
                return RedirectToAction("Index");
            }
            return View();
        }

        // Get: user remove
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ApplicationUser user = userRepo.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // Post: user remove
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            userRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }


}