namespace ElderlyCareSupportSystem.Application.Modules.Role.Models;

public sealed class RoleViewModel
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public string? CreatedBy { get; set; }
    public string? CreatedOn { get; set; }
    public string? ModifiedBy { get; set; }
    public string? ModifiedOn { get; set; }
}