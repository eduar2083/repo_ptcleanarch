namespace Membership.Abstractions.Interfaces.Register;

public interface IRegisterUserInputPort
{
    Task RegisterAsync(RegisterUserDto user);
}
