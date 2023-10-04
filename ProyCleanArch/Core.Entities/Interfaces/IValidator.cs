namespace Core.Entities.Interfaces;

public interface IValidator<T>
{
    IEnumerable<DomainError> Validate(T entity);
    IEnumerable<DomainError> ValidateProperty(T entity, string propertyName);
}
