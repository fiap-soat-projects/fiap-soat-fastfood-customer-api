using Adapter.Controllers.Interfaces;
using Adapter.Presenters.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints;

[ApiController]
[Route("/v1/customer")]
public class Customer : ControllerBase
{
    private readonly ICustomerController _customerController;

    public Customer(ICustomerController customerController)
    {
        _customerController = customerController;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCustomerRequest createCustomerRequest, CancellationToken cancellationToken)
    {
        var presenter = await _customerController.CreateAsync(createCustomerRequest, cancellationToken);

        return Created(
            Url.Action(nameof(GetByIdAsync), new { id = presenter.ViewModel.Id }),
            presenter.ViewModel);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        var presenter = await _customerController.GetByIdAsync(id, cancellationToken);

        return Ok(presenter.ViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> GetByCpfAsync([FromQuery] string cpf, CancellationToken cancellationToken)
    {
        var presenter = await _customerController.GetByCpfAsync(cpf, cancellationToken);

        return Ok(presenter.ViewModel);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateCustomerRequest updateCustomerRequest, CancellationToken cancellationToken)
    {
        if (updateCustomerRequest.Id is null)
        {
            updateCustomerRequest = updateCustomerRequest with { Id = id };
        }

        var presenter = await _customerController.UpdateAsync(updateCustomerRequest, cancellationToken);

        return Ok(presenter.ViewModel);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        await _customerController.DeleteAsync(id, cancellationToken);

        return NoContent();
    }
}
