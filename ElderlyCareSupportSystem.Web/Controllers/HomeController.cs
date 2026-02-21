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

        public IActionResult CompanyRegistration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CompanyViewModel company)
        {
            var validationResult = await _companyValidator.ValidateAsync(company);
            if(!validationResult.IsValid)
                return BadRequest(new {isValid = validationResult.IsValid, validationErrors = validationResult.Errors
                    .Select(e => new { field = e.PropertyName, message = e.ErrorMessage })});  
            
            var registrationResult = await _companyService.CreateCompanyAsync(company);
            if (!registrationResult.IsSuccess)
                return BadRequest(new { success = false, message = registrationResult.Message });
            
            _logger.LogInformation("Successfully registered a new company");
            return Ok(new { success = true });
        }
    }
}
