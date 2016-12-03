using DeveloperDOtnetStoreProject.Models.Repositories;
using DeveloperDOtnetStoreProject.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeveloperDOtnetStoreProject.Interfaces;
using System.Net;

namespace DeveloperDOtnetStoreProject.Controllers.User
{
    // Add new Product??? Need??

    //[Authorize(Roles = "Administrator")]
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
        public ActionResult Details(int id)
        {
            return View(userRepo.Find(id));
        }

        // Get: user creation
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // Post: user creation
        [HttpPost]
        public ActionResult Create(UserModel user)
        {
            if (ModelState.IsValid)
            {
                // user is created
                userRepo.InsertOrUpdate(user);
                return RedirectToAction("Index");
            }
            return View();
        }

        // Get: user update
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpNotFoundResult();
            }

            UserModel user = userRepo.Find(id);

            if (user == null)
            {
                return new HttpNotFoundResult();
            }

            return View(user);
        }

        // Post: user update
        [HttpPost]
        public ActionResult Edit(UserModel user)
        {
            if (ModelState.IsValid)
            {
                userRepo.InsertOrUpdate(user);
                return RedirectToAction("Index");
            }
            return View();
        }

        // Get: user remove
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UserModel user = userRepo.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // Post: user remove
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            userRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }


}