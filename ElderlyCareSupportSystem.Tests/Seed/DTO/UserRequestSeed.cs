using ElderlyCareSupportSystem.Application.Models.DTO;
using ElderlyCareSupportSystem.Application.Models.Response;

namespace ElderlyCareSupportSystem.Tests.Seed.DTO;

public static class UserRequestSeed
{
    public static UserDto Seed()
    {
        var user = new UserDto()
        {
            UserId = Guid.NewGuid(),
            UserName = "admin",
            Email = "sample@gmail.com",
            PasswordHash = "acubq1e2891u92ey182eydhqcfw89g21",
            CompanyName = "Mappa Studios",
            CreatedByUserId = Guid.Parse("2467ff03-1578-47dd-9330-a8dcf035882c"),
            ModifiedByUserId = Guid.Parse("2467ff03-1578-47dd-9330-a8dcf035882c")
        };
        
        return user;
    }
    
    public static Result SeedResult()
    {
        var user = new UserDto()
        {
            UserId = Guid.NewGuid(),
            UserName = "admin",
            Email = "sample@gmail.com",
            PasswordHash = "acubq1e2891u92ey182eydhqcfw89g21",
            CompanyName = "Mappa Studios",
            CreatedByUserId = Guid.Parse("2467ff03-1578-47dd-9330-a8dcf035882c"),
            ModifiedByUserId = Guid.Parse("2467ff03-1578-47dd-9330-a8dcf035882c")
        };
        
        return Result.Success($"User {user.UserName} has been created");
    }
}