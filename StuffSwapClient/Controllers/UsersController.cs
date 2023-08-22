using Microsoft.AspNetCore.Mvc;
using StuffSwapClient.Models;

namespace StuffSwapClient.Controllers{
    public class UsersController: Controller{
        public IActionResult Index(){
            List<User> users = User.GetUsers("users");
            return View(users);
        }

        public IActionResult Details(int id)
        {
            User user = User.GetById(id, "users");
            return View(user);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            User.Post(user, "users");
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            User user = User.GetDetails(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            User.Put(user, "users");
            return RedirectToAction("Details", new { id = user.Id });
        }

        public ActionResult Delete(int id)
        {
            User user = User.GetDetails(id);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            User.Delete(id, "users");
            return RedirectToAction("Index");
        }
    }
}