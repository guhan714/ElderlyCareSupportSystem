using ElderlyCareSupportSystem.Application.Interface.Services;
using ElderlyCareSupportSystem.Application.Models.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElderlyCareSupportSystem.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IValidator<CompanyViewModel> _companyValidator;
        private readonly ICompanyService _companyService;
        
        public HomeController(ILogger<HomeController> logger, IValidator<CompanyViewModel> companyValidator, ICompanyService companyService)
        {
            _logger = logger;
            _companyValidator = companyValidator;
            _companyService = companyService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
