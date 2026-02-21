using Microsoft.AspNetCore.Identity;

namespace ElderlyCareSupport.Domain.Entities;

public class ApplicationUser : IdentityUser<Guid>  // or <string> if default
{
}