using Domain.Entities;

namespace Domain.Exceptions;

public class CustomerNotFoundException : DomainException
{
    private const string CUSTOMER_NOT_FOUND_TEMPLATE_MESSAGE = "Customer '{0}' was not found";

    public CustomerNotFoundException(int id) : base(string.Format(CUSTOMER_NOT_FOUND_TEMPLATE_MESSAGE, id))
    {

    }

    public CustomerNotFoundException(string cpf) : base(string.Format(CUSTOMER_NOT_FOUND_TEMPLATE_MESSAGE, cpf))
    {

    }

    public static void ThrowIfNull(Customer? customer, int id)
    {
        if (customer is null)
        {
            throw new CustomerNotFoundException(id);
        }
    }

    public static void ThrowIfNull(Customer? customer, string cpf)
    {
        if (customer is null)
        {
            throw new CustomerNotFoundException(cpf);
        }
    }
}
