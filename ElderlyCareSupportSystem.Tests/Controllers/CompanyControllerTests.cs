using ElderlyCareSupport.Domain.Entities;
using ElderlyCareSupportSystem.Application.Interface.Services;
using ElderlyCareSupportSystem.Application.Models.Reponse;
using ElderlyCareSupportSystem.Application.Models.ViewModels;
using ElderlyCareSupportSystem.Web.Controllers;
using FluentValidation;
using Imposter.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shouldly;

namespace ElderlyCareSupportSystem.Tests.Controllers;

public class CompanyControllerTests
{
    private readonly ICompanyServiceImposter _companyService;
    private readonly IValidatorImposter<CompanyViewModel> _validator;
    private readonly ICountryServiceImposter _countryService;
    private readonly CompanyController _sut;

    public CompanyControllerTests()
    {
        _countryService = ICountryService.Imposter();
        _validator = new IValidatorImposter<CompanyViewModel>();
        _companyService = ICompanyService.Imposter();
        _sut = new CompanyController(_companyService.Instance(), _validator.Instance() , _countryService.Instance());
    }
    
    [Fact]
    public async Task Register_ShouldReturnView_WhenModelStateIsValid()
    {
        //  Arrange
        var countries = new List<Country>(){ new Country()
        {
            Id = Guid.NewGuid(),
            Name = "Austria",
            Code = "AUS"
        }}.AsReadOnly();
        var countriesResult = Result<IReadOnlyList<Country>>.Success(countries);
        _countryService.GetCountriesAsync().ReturnsAsync(countriesResult);
        //  Act
        var result = await _sut.Register() as ViewResult;
        //  Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<ViewResult>();
        result.ViewData["Countries"].ShouldBeOfType<List<SelectListItem>>();
        var viewBagCount = result.ViewData["Countries"]as List<SelectListItem>;
        viewBagCount.Count.ShouldBe(1);
    }


    [Fact]
    public async Task Register_ShouldThrowException_WhenCompanyIsNull()
    {
        //  Arrange
        
        //  Act
        var result = await _sut.Register(null);
        //  Assert
        result.ShouldBeOfType<BadRequestResult>();
    }
}