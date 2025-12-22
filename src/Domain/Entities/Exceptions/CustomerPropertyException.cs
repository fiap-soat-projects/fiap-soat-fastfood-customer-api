namespace Domain.Entities.Exceptions;

internal class CustomerPropertyException : Exception
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
        if (!value.HasValue)
        {
            throw new CustomerPropertyException(propertyName);
        }
    }
}
