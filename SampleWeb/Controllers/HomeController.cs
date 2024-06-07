using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SampleWeb.Models;

namespace SampleWeb.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        User user = new User();
        user.FullName = "Jomiel L. Enriquez";
        return View(user);
    }
    public IActionResult Test(User user){
        return RedirectToAction("Index");
    }
}
