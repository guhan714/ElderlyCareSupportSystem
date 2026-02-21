using ElderlyCareSupport.Domain.Entities;
using ElderlyCareSupportSystem.Application.Interface.Repository;
using ElderlyCareSupportSystem.Application.Interface.Services;
using ElderlyCareSupportSystem.Application.Mappers;
using ElderlyCareSupportSystem.Application.Models.Reponse;
using ElderlyCareSupportSystem.Application.Models.ViewModels;

namespace ElderlyCareSupportSystem.Application.Implementation.Services;

public sealed class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly CompanyMapper _companyMapper;
    public CompanyService(ICompanyRepository companyRepository, CompanyMapper companyMapper)
    {
        _companyRepository = companyRepository;
        _companyMapper = companyMapper;
    }

    public async Task<Result> CreateCompanyAsync(CompanyViewModel company)
    {
        try
        {
            var companyEntity = _companyMapper.CompanyVmToCompany(company);
            companyEntity.Id = Guid.NewGuid();
            
            var result = await _companyRepository.AddAsync(companyEntity); 
            
            if(result is null)
                return Result.Fail("Could not create company");
            
            return Result.Success("Company created successfully");
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }

    public async Task<Result> UpdateCompanyAsync(CompanyViewModel company)
    {
        try
        {
            var companyEntity = _companyMapper.CompanyVmToCompany(company);
            var result = await _companyRepository.UpdateAsync(companyEntity); 
            
            if(result is null)
                return Result.Fail("Could not update company");
            
            return Result.Success("Company updated successfully");
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }

    public async Task<Result<CompanyViewModel>> GetCompanyAsync(Guid companyId)
    {
        try
        {
            var result = await _companyRepository.GetAsync(companyId);
            
            if(result is null)
                return Result<CompanyViewModel>.Fail("Company not found");
            
            var mappedResult = _companyMapper.CompanyToCompanyViewModel(result);
            return Result<CompanyViewModel>.Success(mappedResult);
        }
        catch (Exception e)
        {
            return Result<CompanyViewModel>.Fail(e.Message);
        }
    }

    public async Task<Result> DeleteCompanyAsync(CompanyViewModel company)
    {
        try
        {
            var companyEntity = _companyMapper.CompanyVmToCompany(company);
            var result = await _companyRepository.DeleteAsync(companyEntity); 
            
            if(result is null)
                return Result.Fail("Could not delete company");
            
            return Result.Success("Company deleted successfully");
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }
}