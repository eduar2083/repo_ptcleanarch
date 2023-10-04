namespace MyApp.Shared.BusinessObjects.Dtos;

public class UserDto
{
    public string Id { get; }
    public string Email { get; }
    public string FirstName { get; }
    public string LastName { get; }

    public UserDto(string id, string email, string firstName, string lastName)
    {
        Id = id;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }

    public string FullName => $"{FirstName} {LastName}";
}
