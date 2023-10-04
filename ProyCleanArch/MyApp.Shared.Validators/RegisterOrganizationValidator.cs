namespace MyApp.Shared.Validators;

internal sealed class RegisterOrganizationValidator : AbstractValidator<RegisterOrganizationDto>
{
    protected override void ValidatePropertyRules(RegisterOrganizationDto entity, string propertyName, List<DomainError> errors)
    {
        switch (propertyName)
        {
            case nameof(RegisterOrganizationDto.Ruc):
                var IsValid = ValidateRule(() => !string.IsNullOrWhiteSpace(entity.Ruc), propertyName, "El ruc es requerido", errors);
                if (IsValid)
                {
                    ValidateRule(() => entity.Ruc.Length == 11, propertyName, "El ruc debe tener 11 caracteres", errors);
                }
                break;

            case nameof(RegisterOrganizationDto.Name):
                IsValid = ValidateRule(() => !string.IsNullOrWhiteSpace(entity.Name), propertyName, "El nombre es requerido", errors);
                if (IsValid)
                {
                    ValidateRule(() => entity.Name.Length <= 100, propertyName, "El nombre debe tener 100 caracteres como máximo", errors);
                }
                break;
        }
    }
}
