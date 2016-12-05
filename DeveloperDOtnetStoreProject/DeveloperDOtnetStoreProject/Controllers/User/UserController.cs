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
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        public UserController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        public ApplicationSignInManager SignInManager
        {
            get{ return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>(); }
            private set { _signInManager = value; }
        }

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
        public async Task<ActionResult> Create(UserModel model)
        {
            if (ModelState.IsValid)
            {
                // user is created
                userRepo.InsertOrUpdate(model);

                //user save to login
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    return RedirectToAction("Index", "Body");
                }
                AddErrors(result);
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