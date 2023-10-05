namespace MyApp.Backend.BussinessObjects.Interfaces.Services;

public interface IUserService
{
    bool IsAuthenticated { get; }

    string UserId { get; }

    string UserName { get; }

    string FullName { get; }

    string OrganizationId { get; }
}