using ElderlyCareSupportSystem.Application.Modules.Security.Contracts;
using ElderlyCareSupportSystem.Infrastructure.Security.Implementation;
using Shouldly;

namespace ElderlyCareSupportSystem.Tests.Services;

public class BCryptHashingServiceTests
{
    private readonly IHashingService _sut;

    public BCryptHashingServiceTests()
    {
        _sut = new BCryptHashingService();
    }
    
    [Fact]
    public void HashPassword_ShouldThrowException_WhenPasswordIsNull()
    {
        Should.Throw<ArgumentNullException>(() =>  _sut.HashPassword(null));
    }

    [Fact]
    public void HashPassword_ShouldReturnHashedPassword_WhenPasswordIsValid()
    {
        //  Arrange
        var password = "guhan712004";
        //  Act
        var result = _sut.HashPassword(password);
        //  Assert
        result.ShouldNotBeNull(); ;
    }


    [Theory]
    [InlineData(null, "guhan712004")]
    [InlineData("$2a$12$lCu27RB0GjKWKGcNEzBWMODiZE6e81QteOiyG0GScYlcxCnigD0uy", null)]
    public void VerifyHashedPassword_ShouldThrowException_WhenHashedPasswordIsNull(string hashedPassword, string providedPassword)
    {
        Should.Throw<ArgumentNullException>(() =>  _sut.VerifyHashedPassword(hashedPassword, providedPassword));
    }

    [Fact]
    public void VerifyPassword_ShouldReturnTrue_WhenPasswordDoesMatch()
    {
        var password = "guhan712004";
        var hashedPassword = "$2a$12$lCu27RB0GjKWKGcNEzBWMODiZE6e81QteOiyG0GScYlcxCnigD0uy";
        
        var result = _sut.VerifyHashedPassword(password, hashedPassword);
        
        result.ShouldBe(true);
    }
}