using ElderlyCareSupport.Domain.Entities;
using ElderlyCareSupportSystem.Application.Implementation.Services;
using ElderlyCareSupportSystem.Application.Interface.Repository;
using ElderlyCareSupportSystem.Application.Mappers;
using ElderlyCareSupportSystem.Application.Models.ViewModels;
using Imposter.Abstractions;
using Shouldly;

namespace ElderlyCareSupportSystem.Tests.Services;

public sealed class CompanyServiceTest
{
    
    private readonly CompanyService _sut;
    private readonly ICompanyRepositoryImposter _companyRepository;
    private readonly CompanyMapperImposter _companyMapper;


    public CompanyServiceTest()
    {
        _companyRepository = ICompanyRepository.Imposter();
        _companyMapper = CompanyMapper.Imposter();
        _sut = new CompanyService(_companyRepository.Instance(),  _companyMapper.Instance());
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

        _companyRepository.GetAsync(guid).ReturnsAsync(company);

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

    [Fact]
    public async Task GetCompanyAsync_ShouldReturnNull_WhenCompanyDoesNotExist()
    {
        //  Arrange
        _companyRepository.GetAsync(Arg<Guid>.Any()).Returns(null);
        
        //  Act
        var result = await _sut.GetCompanyAsync(Guid.NewGuid());
        
        //  Assert
        result.IsSuccess.ShouldBeFalse();
        result.Data.ShouldBeNull();
    }
    
    
    [Fact]
    public async Task GetCompanyAsync_ShouldReturnNull_WhenCompanyIdIsEmpty()
    {
        // Arrange

        // Act
        var result = await _sut.GetCompanyAsync(Guid.Empty);
        
        result.IsSuccess.ShouldBeFalse();
        result.Message.ShouldContain("Company id cannot be empty");
        
        _companyRepository.GetAsync(Arg<Guid>.Any()).Called(Count.Never());
        
    }
    
}