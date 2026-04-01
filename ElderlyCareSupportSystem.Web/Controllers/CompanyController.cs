using ElderlyCareSupportSystem.Application.Interface.Services;
using ElderlyCareSupportSystem.Application.Models.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ElderlyCareSupportSystem.Web.Controllers;

[AllowAnonymous]
public class CompanyController : Controller
{
    private readonly IValidator<CompanyViewModel> _validator;
    private readonly ICompanyService _companyService;
    private readonly ICountryService _countryService;

    public CompanyController(ICompanyService companyService, IValidator<CompanyViewModel> validator, ICountryService countryService)
    {
        _companyService = companyService;
        _validator = validator;
        _countryService = countryService;
    }

    [HttpGet]
    public async Task<IActionResult> Register()
    {
        var countries  = await _countryService.GetCountriesAsync();
        ViewBag.Countries = countries.Data.Select(a => new SelectListItem()
        {
            Value = a.Id.ToString(),
            Text = a.Name
        }).ToList();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register([FromBody]CompanyViewModel company)
    {
        if (company is null) return BadRequest();
        
        var validationResult = await _validator.ValidateAsync(company);

        if (!validationResult.IsValid)
        {
            return Json(new
                { success = false, validationResult = validationResult.Errors.Select(a => a.ErrorMessage) });
        }

        var companyCreation = await _companyService.CreateCompanyAsync(company);

        if (!companyCreation.IsSuccess)
            return Json(new { success = false, message = companyCreation.Message });

        return Json(new { success = true, redirectionUrl = Url.Action("Login", "Auth"), message = companyCreation.Message });

    }
}