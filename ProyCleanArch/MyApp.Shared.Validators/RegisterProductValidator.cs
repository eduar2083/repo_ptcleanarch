namespace MyApp.Shared.Validators;

internal sealed class RegisterProductValidator : AbstractValidator<RegisterProductDto>
{
    protected override void ValidatePropertyRules(RegisterProductDto entity, string propertyName, List<DomainError> errors)
    {
        switch (propertyName)
        {
            case nameof(RegisterProductDto.Name):
                var IsValid = ValidateRule(() => !string.IsNullOrWhiteSpace(entity.Name), propertyName, "El nombre es requerido", errors);
                if (IsValid)
                {
                    ValidateRule(() => entity.Name.Length <= 100, propertyName, "El nombre debe tener 100 caracteres como máximo", errors);
                }
                break;

            case nameof(RegisterProductDto.UnitPrice):
                ValidateRule(() => entity.UnitPrice > 0, propertyName, "El precio debe ser mayor que cero", errors);
                break;
        }
    }
}
