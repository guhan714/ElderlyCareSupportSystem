using ElderlyCareSupportSystem.Application.Models.ViewModels;
using ElderlyCareSupportSystem.Tests.TestUtility;

namespace ElderlyCareSupportSystem.Tests.Seed.DTO;

public static class CompanyDtoSeed
{
    public static CompanyViewModel Seed()
    {
        return new CompanyViewModel()
        {
            Id = Guid.NewGuid(),
            Name = "Mappa Studios",
            AddressLine1 = "123 Main St",
            AddressLine2 = "123 Main St",
            AddressLine3 = "123 Main St",
            Email = "sample@gmail.com",
            PhoneNumber = "9232766612",
            City = "Edgebaston",
            CountryId = TestConstants.CountryId,
            Website = "https://mappa.com",
            UserName = "admin",
            
        };
    }
}