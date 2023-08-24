using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using StuffSwapClient.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;


namespace StuffSwapClient.Controllers;

public class ToolsController : Controller
{
    public IActionResult Index()
    {
        List<Tool> tools = Tool.GetTools("tools");
        return View(tools);
    }

    public IActionResult Details(int id)
    {
        Tool tool = Tool.GetDetails(id, "tools");
        AppUser owner = AppUser.GetDetails(tool.AppUserId, "appUsers");
        ViewBag.UserName = owner.UserName;
        return View(tool);
    }

    public ActionResult Create(){
        return View();
    }

    [HttpPost]
    public ActionResult Create(Tool tool){
        Tool.Post(tool, "tools");
        return RedirectToAction("Index");
    }

    public ActionResult Edit(int id){
        Tool tool = Tool.GetDetails(id, "tools");
        return View(tool);
    }

    [HttpPost]
    public ActionResult Edit(Tool tool){
        Tool.Put(tool, "tools");
        return RedirectToAction("Details", new { id = tool.ToolId});
    }

    public ActionResult Delete(int id){
        Tool tool = Tool.GetDetails(id, "tools");
        return View(tool);

    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id){
        Tool.Delete(id, "tools");
        return RedirectToAction("Index");
    }
}