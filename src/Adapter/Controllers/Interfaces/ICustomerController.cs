using Adapter.Presenters;
using Adapter.Presenters.DTOs;

namespace Adapter.Controllers.Interfaces;

public interface ICustomerController
{
    Task<CustomerPresenter> CreateAsync(CreateCustomerRequest request, CancellationToken cancellationToken);
    Task<CustomerPresenter> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<CustomerPresenter> GetByCpfAsync(string cpf, CancellationToken cancellationToken);
    Task<CustomerPresenter> UpdateAsync(UpdateCustomerRequest request, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}
