using ElderlyCareSupport.Domain.Entities;

namespace ElderlyCareSupportSystem.Tests.Seed.Domain;

public static class CompanySeed
{
    public static Company GetCompanySeed()
    {
        return new Company()
        {
            Id = Guid.NewGuid(),
            Name = "Mappa Studios",
            AddressLine1 = "123 Main St",
            AddressLine2 = "123 Main St",
            AddressLine3 = "123 Main St",
            Email = "sample@gmail.com"
        };
    }
}