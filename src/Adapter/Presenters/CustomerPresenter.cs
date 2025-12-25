using Adapter.Presenters.DTOs;
using Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Adapter.Presenters;

[ExcludeFromCodeCoverage]
public record CustomerPresenter
{
    public CustomerResponse ViewModel { get; init; }

    public CustomerPresenter(Customer customer)
    {
        ViewModel = new CustomerResponse(customer);
    }
}
