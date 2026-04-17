using ElderlyCareSupportSystem.Application.Mappers.Domain.DomainMapper;
using ElderlyCareSupportSystem.Application.Models.DTO;
using ElderlyCareSupportSystem.Application.Models.Response;
using ElderlyCareSupportSystem.Application.Models.ViewModels;
using ElderlyCareSupportSystem.Application.Modules.Common.Contracts;
using ElderlyCareSupportSystem.Application.Modules.Company.Contracts;
using ElderlyCareSupportSystem.Application.Modules.CompanyModule.Contracts;
using ElderlyCareSupportSystem.Application.Modules.Security.Contracts;
using ElderlyCareSupportSystem.Application.Modules.User.Contracts;
using ElderlyCareSupportSystem.Application.Modules.Users.Mapper;
using DtoMapper = ElderlyCareSupportSystem.Application.Mappers.DataTransfer.DtoMapper;

namespace ElderlyCareSupportSystem.Application.Modules.Company.Implementation;

public sealed class CompanyService : ICompanyService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICompanyRepository _companyRepository;
    private readonly IHashingService _hashingService;
    
    private readonly DomainMapper _domainMapper;
    private readonly DtoMapper _dtoMapper;

    public CompanyService(ICompanyRepository companyRepository, DomainMapper domainMapper, DtoMapper dtoMapper, IUnitOfWork unitOfWork, IHashingService hashingService)
    {
        _companyRepository = companyRepository;
        _domainMapper = domainMapper;
        _dtoMapper = dtoMapper;
        _unitOfWork = unitOfWork;
        _hashingService = hashingService;
    }

    public async Task<Result> CreateCompanyAsync(CompanyViewModel company)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var companyEntity = _domainMapper.ToCompany(company);
            companyEntity.Id = Guid.NewGuid();

            var user = MapUserDto(company, companyEntity);

            companyEntity.CreatedById = user.CreatedByUserId;
            companyEntity.CreatedOn = DateTime.UtcNow;
            companyEntity.UpdatedById = user.CreatedByUserId;
            companyEntity.UpdatedOn = DateTime.UtcNow;

            await _unitOfWork.Companies.AddAsync(companyEntity);

            var userEntity = UserMapper.ToUser(user);
            
            await _unitOfWork.Users.AddAsync(userEntity);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return Result.Success("Company created successfully");
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackAsync();
            return Result.Fail(ex.Message);
        }
    }

    public async Task<Result> UpdateCompanyAsync(CompanyViewModel company)
    {
        var companyEntity = _domainMapper.ToCompany(company);
        var result = await _companyRepository.UpdateAsync(companyEntity);

        if (result is null)
            return Result.Fail("Could not update company");

        return Result.Success("Company updated successfully");
    }

    public async Task<Result<CompanyViewModel>> GetCompanyAsync(Guid companyId)
    {
        if (companyId == Guid.Empty)
            return Result<CompanyViewModel>.Fail("Company id cannot be empty");

        var result = await _companyRepository.GetAsync(companyId);

        if (result is null)
            return Result<CompanyViewModel>.Fail("Company not found");

        var mappedResult = _dtoMapper.ToCompany(result);
        return Result<CompanyViewModel>.Success(mappedResult);
    }

    public async Task<Result> DeleteCompanyAsync(Guid id)
    {
        var company = await _companyRepository.GetAsync(id);
        if (company is null)
            return Result.Fail("Company not found");

        var result = await _companyRepository.DeleteAsync(company);

        return Result.Success("Company deleted successfully");
    }


    private UserDto MapUserDto(CompanyViewModel companyViewModel, ElderlyCareSupport.Domain.Entities.Company company)
    {
        var user = new UserDto()
        {
            UserId = Guid.NewGuid(),
            UserName = companyViewModel.UserName,
            Email = company.Email,
            PasswordHash = _hashingService.HashPassword(companyViewModel.Password),
            CompanyName = company.Name,
            CreatedByUserId = Guid.Parse("2467ff03-1578-47dd-9330-a8dcf035882c"),
            ModifiedByUserId = Guid.Parse("2467ff03-1578-47dd-9330-a8dcf035882c")
        };

        return user;
    }
}