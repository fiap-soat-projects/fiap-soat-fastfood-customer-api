using Domain.Entities;
using Domain.Exceptions;
using Domain.Gateways.Repositories.Interfaces;
using Domain.UseCases;
using NSubstitute;

namespace UnitTests.Domain.UseCases.CustomerUseCaseTests.Methods;

public class GetByIdAsyncTests
{
    [Fact]
    public async Task When_CustomerWasNotFound_Then_ThrowCustomerNotFoundException()
    {
        // Arrange
        var repository = Substitute.For<ICustomerRepository>();
        var sut = new CustomerUseCase(repository);

        var customerId = 1;

        // Act & Assert
        await Assert.ThrowsAsync<CustomerNotFoundException>(async () =>
        {
            _ = await sut.GetByIdAsync(customerId, CancellationToken.None);
        });
    }

    [Fact]
    public async Task When_Invoked_Then_ReturnCustomer()
    {
        // Arrange
        var repository = Substitute.For<ICustomerRepository>();
        var sut = new CustomerUseCase(repository);

        var customer = new Customer(1, DateTime.UtcNow, "AnyName", "11111111111", "test@test.com");

        repository.GetByIdAsync(customer.Id, CancellationToken.None).Returns(customer);

        // Act
        var result = await sut.GetByIdAsync(customer.Id, CancellationToken.None);

        // Assert
        Assert.Equivalent(customer, result);
    }
}
