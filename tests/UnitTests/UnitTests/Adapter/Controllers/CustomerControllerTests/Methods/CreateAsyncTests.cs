using Adapter.Controllers;
using Adapter.Presenters.DTOs;
using Domain.Entities;
using Domain.UseCases.Interfaces;
using NSubstitute;

namespace UnitTests.Adapter.Controllers.CustomerControllerTests.Methods;

public class CreateAsyncTests
{
    [Fact]
    public async Task When_Invoked_Then_CallCreateAsyncUseCase()
    {
        // Arrange
        var useCase = Substitute.For<ICustomerUseCase>();
        var sut = new CustomerController(useCase);

        var request = new CreateCustomerRequest
        {
            Name = "AnyName",
            Cpf = "11111111111",
            Email = "test@test.com"
        };

        var customer = new Customer(1, DateTime.UtcNow, request.Name, request.Cpf, request.Email);

        useCase.CreateAsync(Arg.Any<Customer>(), Arg.Any<CancellationToken>()).Returns(customer);

        // Act
        var result = await sut.CreateAsync(request, CancellationToken.None);

        // Assert
        Assert.Equal(customer.Id, result.ViewModel.Id);
        Assert.Equal(customer.CreatedAt, result.ViewModel.CreatedAt);
        Assert.Equal(customer.Name, result.ViewModel.Name);
        Assert.Equal(customer.Cpf, result.ViewModel.Cpf);
        Assert.Equal(customer.Email.ToString(), result.ViewModel.Email);
        Assert.Null(result.ViewModel.UpdatedAt);
    }
}
