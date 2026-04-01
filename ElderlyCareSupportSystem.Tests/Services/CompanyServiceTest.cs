using ElderlyCareSupportSystem.Application.Implementation.Services;
using ElderlyCareSupportSystem.Application.Interface.Repository;
using ElderlyCareSupportSystem.Application.Interface.Services;
using ElderlyCareSupportSystem.Application.Mappers.DataTransfer;
using ElderlyCareSupportSystem.Application.Mappers.Domain.DomainMapper;
using ElderlyCareSupportSystem.Application.Models.ViewModels;
using ElderlyCareSupportSystem.Tests.Seed.Domain;
using ElderlyCareSupportSystem.Tests.Seed.DTO;
using ElderlyCareSupportSystem.Tests.TestUtility;
using Imposter.Abstractions;
using Shouldly;

namespace ElderlyCareSupportSystem.Tests.Services;

public sealed class CompanyServiceTest
{
    
    private readonly CompanyService _sut;
    private readonly ICompanyRepositoryImposter _companyRepository;
    private readonly IUserServiceImposter _userService;
    private readonly DomainMapperImposter _domainMapperImposter;
    private readonly DtoMapperImposter _dtoMapperImposter;


    public CompanyServiceTest()
    {
        _userService = IUserService.Imposter();
        _companyRepository = ICompanyRepository.Imposter();
        _domainMapperImposter = DomainMapper.Imposter();
        _dtoMapperImposter = DtoMapper.Imposter();
        _sut = new CompanyService(_companyRepository.Instance(),  _domainMapperImposter.Instance(), _dtoMapperImposter.Instance(), _userService.Instance());
    }


    [Fact]
    public async Task GetCompanyAsync_ShouldReturnCompany_WhenCompanyExists()
    {
        // arrange
        var guid = TestConstants.CompanyId;
        var company = CompanySeed.GetCompanySeed();

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
        _companyRepository.GetAsync(Arg<Guid>.Any()).ReturnsAsync(null);
        
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


    [Fact]
    public async Task CreateCompanyAsync_ShouldCreateCompany_WhenCompanyIsValid()
    {
        //  Arrange
        var company = CompanySeed.GetCompanySeed();
        var user = UserRequestSeed.Seed();
        var userResult = UserRequestSeed.SeedResult();
        _companyRepository.AddAsync(company).ReturnsAsync(company);
        _userService.AddUser(user).ReturnsAsync(userResult);
        
        //  Act
        var companyInput = CompanyDtoSeed.Seed();
        var result = await _sut.CreateCompanyAsync(companyInput);
        
        //  Assert
        result.IsSuccess.ShouldBeTrue();
        result.Message.ShouldContain("Company created successfully");
    }
    
}