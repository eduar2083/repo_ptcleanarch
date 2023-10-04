namespace Core.Entities.Abstracts;

public abstract class AbstractValidator<T> : IValidator<T>
{
    public IEnumerable<DomainError> Validate(T entity)
    {
        List<DomainError> Errors = new();
        var Properties = typeof(T).GetProperties();
        foreach (var Property in Properties)
        {
            var PropertyErrors = ValidateProperty(entity, Property.Name);
            if (PropertyErrors.Any())
            {
                Errors.AddRange(PropertyErrors);
            }
        }

        return Errors;
    }

    public IEnumerable<DomainError> ValidateProperty(T entity, string propertyName)
    {
        List<DomainError> Errors = new();
        ValidatePropertyRules(entity, propertyName, Errors);

        return Errors;
    }

    protected abstract void ValidatePropertyRules(T entity, string propertyName, List<DomainError> errors);

    protected bool ValidateRule(Func<bool> predicate, string propertyName, string message, List<DomainError> errors)
    {
        bool Result = true;

        if (!predicate())
        {
            errors.Add(new DomainError(propertyName, message));
            Result = false;
        }

        return Result;
    }
}
