using Domain.Exceptions;

namespace Domain.Entities.Exceptions;

internal class CustomerPropertyException : DomainException
{
    private const string INVALID_CUSTOMER_PROPERTY_TEMPLATE_MESSAGE = "The property {0} is invalid";

    public CustomerPropertyException(string propertyName) : base(string.Format(INVALID_CUSTOMER_PROPERTY_TEMPLATE_MESSAGE, propertyName))
    {

    }

    public static void ThrowIfNullOrWhiteSpace(string? value, string propertyName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new CustomerPropertyException(propertyName);
        }
    }

    public static void ThrowIfNull<T>(T? value, string propertyName) where T : struct
    {
        if (!value.HasValue || EqualityComparer<T>.Default.Equals(value.Value, default))
        {
            throw new CustomerPropertyException(propertyName);
        }
    }
}
