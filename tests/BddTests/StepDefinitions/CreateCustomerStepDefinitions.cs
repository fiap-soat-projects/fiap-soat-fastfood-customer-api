using Adapter.Controllers;
using Adapter.Presenters;
using Adapter.Presenters.DTOs;
using Domain.Entities;
using Domain.UseCases.Interfaces;
using NSubstitute;

namespace BddTests.StepDefinitions;

[Binding]
public sealed class CreateCustomerStepDefinitions
{
    private CreateCustomerRequest _request = default!;
    private CustomerPresenter _presenter = default!;

    private readonly ICustomerUseCase _customerUseCase;
    private readonly CustomerController _sut;

    public CreateCustomerStepDefinitions()
    {
        _customerUseCase = Substitute.For<ICustomerUseCase>();
        _sut = new CustomerController(_customerUseCase);
    }

    [Given("a valid create customer request with name {string}, cpf {string} and email {string}")]
    public void GivenAValidCreateCustomerRequest(string name, string cpf, string email)
    {
        _request = new CreateCustomerRequest
        {
            Name = name,
            Cpf = cpf,
            Email = email
        };
    }

    [When("the client calls the Create endpoint")]
    public async Task WhenTheClientCallsTheCreateEndpoint()
    {
        var createdCustomer = new Customer(1, DateTime.UtcNow, _request.Name, _request.Cpf, _request.Email!);

        _customerUseCase
            .CreateAsync(Arg.Any<Customer>(), Arg.Any<CancellationToken>())
            .Returns(createdCustomer);

        _presenter = await _sut.CreateAsync(_request, CancellationToken.None);
    }

    [Then("the response should contain the created customer with id {int} and the same name, cpf and email and updatedAt null")]
    public void ThenTheResponseShouldContainTheCreatedCustomer(string expectedId)
    {
        Assert.NotNull(_presenter);
        Assert.Equal(expectedId, _presenter.ViewModel.Id);
        Assert.Equal(_request.Name, _presenter.ViewModel.Name);
        Assert.Equal(_request.Cpf, _presenter.ViewModel.Cpf);
        Assert.Equal(_request.Email, _presenter.ViewModel.Email);
        Assert.Null(_presenter.ViewModel.UpdatedAt);
    }
}