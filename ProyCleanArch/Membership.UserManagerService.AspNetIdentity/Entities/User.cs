namespace Membership.UserManagerService.AspNetIdentity.Entities;

internal class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CompanyId { get; set; }
}
