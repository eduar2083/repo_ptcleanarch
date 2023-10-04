namespace MyApp.EFCore.Repositories.Entities;

internal class User
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string OrganizationId { get; set; }

    public Organization Organization { get; set; }
}
