using Microsoft.AspNetCore.Mvc;

namespace ElderlyCareSupportSystem.Web.Controllers;

public class RoleController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}