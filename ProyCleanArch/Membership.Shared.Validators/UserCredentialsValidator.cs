namespace Membership.Shared.Validators;

internal sealed class UserCredentialsValidator : AbstractValidator<UserCredentialsDto>
{
    protected override void ValidatePropertyRules(UserCredentialsDto entity, string propertyName, List<MembershipError> errors)
    {
        switch (propertyName)
        {
            case nameof(UserCredentialsDto.Email):
                ValidateRule(() => !string.IsNullOrWhiteSpace(entity.Email), propertyName, "El usuario es requerido", errors);
                break;

            case nameof(RegisterUserDto.Password):
                ValidateRule(() => !string.IsNullOrWhiteSpace(entity.Password), propertyName, "La contraseña es requerida", errors);
                break;
        }
    }
}
