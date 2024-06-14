using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SampleWeb.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
