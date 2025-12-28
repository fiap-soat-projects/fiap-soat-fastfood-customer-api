using Domain.Entities;
using Domain.Gateways.Repositories.Interfaces;
using Domain.UseCases;
using NSubstitute;

namespace UnitTests.Domain.UseCases.CustomerUseCaseTests.Methods;

public class CreateAsyncTests
{
    [Fact]
    public async Task When_CustomerIsNull_Then_ThrowArgumentNullException()
    {
        // Arrange
        var repository = Substitute.For<ICustomerRepository>();
        var sut = new CustomerUseCase(repository);

        var customer = default(Customer);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            _ = await sut.CreateAsync(customer!, CancellationToken.None);
        });
    }

    [Fact]
    public async Task When_CustomerIsValid_Then_Create()
    {
        // Arrange
        var repository = Substitute.For<ICustomerRepository>();
        var sut = new CustomerUseCase(repository);

        var customer = new Customer("AnyName", "11111111111", "test@test.com");

        repository.CreateAsync(customer, CancellationToken.None).Returns(
            new Customer(1, DateTime.Now)
            {
                Name = customer.Name,
                Cpf = customer.Cpf,
                Email = customer.Email
            });

        // Act
        var result = await sut.CreateAsync(customer, CancellationToken.None);

        // Assert
        Assert.Equal(1, result.Id);
        Assert.Equal(customer.Name, result.Name);
        Assert.Equal(customer.Cpf, result.Cpf);
        Assert.Equal(customer.Email, result.Email);
        Assert.Null(result.UpdatedAt);
    }
}
