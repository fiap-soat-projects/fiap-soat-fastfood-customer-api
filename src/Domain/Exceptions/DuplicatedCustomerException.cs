using System.Diagnostics.CodeAnalysis;

namespace Domain.Exceptions;

[ExcludeFromCodeCoverage]
public class DuplicatedCustomerException : DomainException
{
    const string DUPLICATED_CUSTOMER_TEMPLATE_MESSAGE = "A customer with same cpf already exists";

    public DuplicatedCustomerException() : base(DUPLICATED_CUSTOMER_TEMPLATE_MESSAGE)
    {

    }
}
