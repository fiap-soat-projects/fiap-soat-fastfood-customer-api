using Domain.Entities;
using Domain.Exceptions;
using Domain.Gateways.Repositories.Interfaces;
using Domain.UseCases;
using NSubstitute;

namespace UnitTests.Domain.UseCases.CustomerUseCaseTests.Methods;

public class GetByCpfAsyncTests
{
    [Fact]
    public async Task When_CpfIsNull_Then_ThrowArgumentNullException()
    {
        // Arrange
        var repository = Substitute.For<ICustomerRepository>();
        var sut = new CustomerUseCase(repository);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            _ = await sut.GetByCpfAsync(null!, CancellationToken.None);
        });
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public async Task When_CpfIsEmptyOrWhiteSpace_Then_ThrowArgumentException(string? customerCpf)
    {
        // Arrange
        var repository = Substitute.For<ICustomerRepository>();
        var sut = new CustomerUseCase(repository);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            _ = await sut.GetByCpfAsync(customerCpf!, CancellationToken.None);
        });
    }

    [Fact]
    public async Task When_CustomerWasNotFound_Then_ThrowCustomerNotFoundException()
    {
        // Arrange
        var repository = Substitute.For<ICustomerRepository>();
        var sut = new CustomerUseCase(repository);

        var customerCpf = "11111111111";

        // Act & Assert
        await Assert.ThrowsAsync<CustomerNotFoundException>(async () =>
        {
            _ = await sut.GetByCpfAsync(customerCpf, CancellationToken.None);
        });
    }

    [Fact]
    public async Task When_Invoked_Then_ReturnCustomer()
    {
        // Arrange
        var repository = Substitute.For<ICustomerRepository>();
        var sut = new CustomerUseCase(repository);

        var customer = new Customer(1, DateTime.UtcNow, "AnyName", "11111111111", "test@test.com");

        repository.GetByCpfAsync(customer.Cpf, CancellationToken.None).Returns(customer);

        // Act
        var result = await sut.GetByCpfAsync(customer.Cpf, CancellationToken.None);

        // Assert
        Assert.Equivalent(customer, result);
    }
}
