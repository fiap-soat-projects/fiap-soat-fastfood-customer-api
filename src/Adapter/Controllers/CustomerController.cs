using Adapter.Controllers.Interfaces;
using Adapter.Presenters;
using Adapter.Presenters.DTOs;
using Domain.Entities;
using Domain.UseCases.Interfaces;

namespace Adapter.Controllers;

internal class CustomerController : ICustomerController
{
    private readonly ICustomerUseCase _customerUseCase;

    public CustomerController(ICustomerUseCase customerUseCase)
    {
        _customerUseCase = customerUseCase;
    }

    public async Task<CustomerPresenter> CreateAsync(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = new Customer(request.Name, request.Cpf, request.Email!);

        customer = await _customerUseCase.CreateAsync(customer, cancellationToken);

        return new CustomerPresenter(customer);
    }

    public async Task<CustomerPresenter> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var customer = await _customerUseCase.GetByIdAsync(id, cancellationToken);

        return new CustomerPresenter(customer);
    }

    public async Task<CustomerPresenter> GetByCpfAsync(string cpf, CancellationToken cancellationToken)
    {
        var customer = await _customerUseCase.GetByCpfAsync(cpf, cancellationToken);

        return new CustomerPresenter(customer);
    }

    public async Task<CustomerPresenter> UpdateAsync(UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = await _customerUseCase.GetByIdAsync(request.Id!.Value, cancellationToken);

        customer.Name = request.Name;
        customer.Cpf = request.Cpf;
        customer.Email = request.Email!;
        customer.Update();

        await _customerUseCase.UpdateAsync(customer, cancellationToken);

        return new CustomerPresenter(customer);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        await _customerUseCase.DeleteAsync(id, cancellationToken);
    }
}
