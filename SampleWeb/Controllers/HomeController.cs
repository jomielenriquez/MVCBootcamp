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
    public IActionResult EditPerson(){
        var person = new Person();
        person.Name = "Jomiel Enriquez";
        return View(person);
    }
    public IActionResult Test(Person person){
        return RedirectToAction("Index");
    }
}
