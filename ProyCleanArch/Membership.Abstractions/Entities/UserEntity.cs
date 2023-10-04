namespace Membership.Abstractions.Entities;

public class UserEntity
{
    public string Id { get; }
    public string Email { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string[] Roles { get; }
    public IEnumerable<Claim> Claims { get; set; }

    public UserEntity(string id, string email, string firstName, string lastName, string[] roles)
    {
        Id = id;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Roles = roles;
    }

    public string FullName => $"{FirstName} {LastName}";
}