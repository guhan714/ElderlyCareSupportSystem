using Microsoft.AspNetCore.Mvc;

namespace ElderlyCareSupportSystem.Web.Controllers;

public class AuthController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}