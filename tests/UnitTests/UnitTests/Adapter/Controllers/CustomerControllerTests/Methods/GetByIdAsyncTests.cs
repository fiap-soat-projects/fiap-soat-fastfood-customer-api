using Adapter.Controllers;
using Domain.Entities;
using Domain.UseCases.Interfaces;
using NSubstitute;

namespace UnitTests.Adapter.Controllers.CustomerControllerTests.Methods;

public class GetByIdAsyncTests
{
    [Fact]
    public async Task When_Invoked_Then_CallGetByIdAsyncUseCase()
    {
        // Arrange
        var useCase = Substitute.For<ICustomerUseCase>();
        var sut = new CustomerController(useCase);

        var id = 1;

        var customer = new Customer(id, DateTime.UtcNow, "AnyName", "11111111111", "test@test.com");

        useCase.GetByIdAsync(id, CancellationToken.None).Returns(customer);

        // Act
        var result = await sut.GetByIdAsync(id, CancellationToken.None);

        // Assert
        Assert.Equal(customer.Id, result.ViewModel.Id);
        Assert.Equal(customer.CreatedAt, result.ViewModel.CreatedAt);
        Assert.Equal(customer.Name, result.ViewModel.Name);
        Assert.Equal(customer.Cpf, result.ViewModel.Cpf);
        Assert.Equal(customer.Email.ToString(), result.ViewModel.Email);
        Assert.Null(result.ViewModel.UpdatedAt);
    }
}
