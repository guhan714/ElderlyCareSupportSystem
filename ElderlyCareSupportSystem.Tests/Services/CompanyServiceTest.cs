using ElderlyCareSupport.Domain.Entities;
using ElderlyCareSupportSystem.Application.Implementation.Services;
using ElderlyCareSupportSystem.Application.Interface.Repository;
using ElderlyCareSupportSystem.Application.Interface.Services;
using ElderlyCareSupportSystem.Application.Mappers;
using ElderlyCareSupportSystem.Application.Models.ViewModels;
using Moq;
using Shouldly;

namespace ElderlyCareSupportSystem.Tests.Services;

public sealed class CompanyServiceTest
{
    
    private readonly CompanyService _sut;
    private readonly Mock<ICompanyRepository> _companyRepository;
    private readonly Mock<CompanyMapper> _companyMapper;


    public CompanyServiceTest()
    {
        _companyRepository = new  Mock<ICompanyRepository>();
        _companyMapper = new  Mock<CompanyMapper>();
        _sut = new CompanyService(_companyRepository.Object,  _companyMapper.Object);
    }


    [Fact]
    public async Task GetCompanyAsync_ShouldReturnCompany_WhenCompanyExists()
    {
        // arrange
        var guid = Guid.NewGuid();
        var company = new Company()
        {
            Id = guid,
            Name = "Mappa Studios",
            AddressLine1 = "123 Main St",
            AddressLine2 = "123 Main St",
            AddressLine3 = "123 Main St",
            Email = "sample@gmail.com"
        };

        _companyRepository.Setup(a => a.GetAsync(guid)).ReturnsAsync(company);

        // Act
        
        var result = await _sut.GetCompanyAsync(guid);
        
        // Assert
        
        result.IsSuccess.ShouldBeTrue();
        result.Data.ShouldNotBeNull();
        result.Data.ShouldBeOfType<CompanyViewModel>();
        result.Data.Id.ShouldBe(company.Id);
        result.Data.Name.ShouldBe(company.Name);
        result.Data.Email.ShouldBe(company.Email);
    }
    
}