namespace MyApp.Shared.Validators;

internal sealed class UserCredentialsValidator : AbstractValidator<UserCredentialsDto>
{
    protected override void ValidatePropertyRules(UserCredentialsDto entity, string propertyName, List<DomainError> errors)
    {
        switch (propertyName)
        {
            case nameof(UserCredentialsDto.UserName):
                ValidateRule(() => !string.IsNullOrWhiteSpace(entity.UserName), propertyName, "El usuario es requerido", errors);
                break;

            case nameof(UserCredentialsDto.Password):
                ValidateRule(() => !string.IsNullOrWhiteSpace(entity.Password), propertyName, "La contraseña es requerida", errors);
                break;
        }
    }
}
