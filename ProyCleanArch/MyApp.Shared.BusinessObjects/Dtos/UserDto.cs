namespace MyApp.Shared.BusinessObjects.Dtos;

public class UserDto
{
    public string Id { get; }
    public string Email { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string PasswordHash { get; }
    public string OrganizationId { get; set; }

    public UserDto(string id, string email, string firstName, string lastName, string passwordHash, string organizationId)
    {
        Id = id;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        PasswordHash = passwordHash;
        OrganizationId = organizationId;
    }

    public string FullName => $"{FirstName} {LastName}";
}
