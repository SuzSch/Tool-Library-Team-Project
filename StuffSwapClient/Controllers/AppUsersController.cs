using Microsoft.AspNetCore.Mvc;
using StuffSwapClient.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace StuffSwapClient.Controllers
{
    public class AppUsersController : Controller{
        public IActionResult Index(){
            List<AppUser> appUsers = AppUser.GetUsers("appUsers");
            return View(appUsers);
        }
        public ActionResult Login(){
            return View();
        }
 
        public IActionResult Details(int id)
        {
            AppUser appUser = AppUser.GetDetails(id, "appUsers");
            return View(appUser);
        }

        //Register method
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AppUser appUser)
        {
            AppUser.Post(appUser, "appUsers");
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            AppUser appUser = AppUser.GetDetails(id, "appUsers");
            return View(appUser);
        }

        [HttpPost]
        public ActionResult Edit(AppUser appUser)
        {
            AppUser.Put(appUser, "appUsers");
            return RedirectToAction("Details", new { id = appUser.AppUserId });
        }

        public ActionResult Delete(int id)
        {
            AppUser appUser = AppUser.GetDetails(id, "appUsers");
            return View(appUser);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            AppUser.Delete(id, "appUsers");
            return RedirectToAction("Index");
        }
    }
}