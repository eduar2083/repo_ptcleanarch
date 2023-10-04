namespace MyApp.Shared.BusinessObjects.Services;

public interface IValidator<T>
{
    IEnumerable<DomainError> Validate(T entity);
    IEnumerable<DomainError> ValidateProperty(T entity, string propertyName);
}
