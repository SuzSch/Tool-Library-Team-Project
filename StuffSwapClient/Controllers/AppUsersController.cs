using Microsoft.AspNetCore.Mvc;
using StuffSwapClient.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Web;
// using System.Web.HttpCookie;
// using System.Web.HttpContext;

namespace StuffSwapClient.Controllers
{
    public class AppUsersController : Controller{
        public IActionResult Index(){
            List<AppUser> appUsers = AppUser.GetUsers("appUsers");
            
            return View(appUsers);
        }
        public ActionResult Login(){
            // ViewBag.test = HttpContext.Request.Cookies["jwt"];
            return View();
        } 

        [HttpPost]
        public ActionResult Login(AppUser appUser)
        {
            string token = AppUser.LogIn(appUser);
            //Need to clean up "" showing up with token. Why are they showing up?
            string cleanedToken = token.Replace("\"", "");
            HttpContext.Response.Cookies.Append("jwt", cleanedToken);
            return RedirectToAction("Login");
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
            return RedirectToAction("Login");
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