namespace Membership.Shared.Validators;

internal sealed class RegisterUserValidator : AbstractValidator<RegisterUserDto>
{
    protected override void ValidatePropertyRules(RegisterUserDto entity, string propertyName, List<MembershipError> errors)
    {
        switch (propertyName)
        {
            case nameof(RegisterUserDto.FirstName):
                var IsValid = ValidateRule(() => !string.IsNullOrWhiteSpace(entity.FirstName), propertyName, "Primer nombre es requerido", errors);
                if (IsValid)
                {
                    ValidateRule(() => entity.FirstName.Length <= 100, propertyName, "Primer nombre debe tener 100 caracteres como máximo", errors);
                }
                break;

            case nameof(RegisterUserDto.LastName):
                IsValid = ValidateRule(() => !string.IsNullOrWhiteSpace(entity.LastName), propertyName, "Apellido es requerido", errors);
                if (IsValid)
                {
                    ValidateRule(() => entity.LastName.Length <= 100, propertyName, "Apellido debe tener 100 caracteres como máximo", errors);
                }
                break;

            case nameof(RegisterUserDto.Email):
                IsValid = ValidateRule(() => !string.IsNullOrWhiteSpace(entity.Email), propertyName, "Correo electrónico es requerido", errors);
                if (IsValid)
                {
                    IsValid = ValidateRule(() => entity.Email.Length <= 100, propertyName, "Correo electrónico debe tener 100 caracteres como máximo", errors);
                }
                if (IsValid)
                {
                    var Regex = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
                    ValidateRule(() => Regex.IsMatch(entity.Email), propertyName, "Correo electrónico no válido", errors);
                }
                break;

            case nameof(RegisterUserDto.Password):
                ValidateRule(() => !string.IsNullOrWhiteSpace(entity.Password), propertyName, "Contraseña es requerida", errors);
                break;

            case nameof(RegisterUserDto.ConfirmPassword):
                IsValid = ValidateRule(() => !string.IsNullOrWhiteSpace(entity.ConfirmPassword), propertyName, "La confirmación de contraseña es requerida", errors);
                if (IsValid)
                {
                    ValidateRule(() => entity.Password == entity.ConfirmPassword, propertyName, "La contraseña y su confirmación no coinciden", errors);
                }
                break;
        }
    }
}