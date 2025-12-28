using Domain.Entities;
using Domain.Gateways.Repositories.Interfaces;
using Domain.UseCases;
using NSubstitute;

namespace UnitTests.Domain.UseCases.CustomerUseCaseTests.Methods;

public class UpdateAsyncTests
{
    [Fact]
    public async Task When_CustomerIsNull_Then_ThrowArgumentNullException()
    {
        // Arrange
        var repository = Substitute.For<ICustomerRepository>();
        var sut = new CustomerUseCase(repository);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await sut.UpdateAsync(null!, CancellationToken.None);
        });
    }

    [Fact]
    public async Task When_Invoked_Then_CallRepositoryToUpdateCustomer()
    {
        // Arrange
        var repository = Substitute.For<ICustomerRepository>();
        var sut = new CustomerUseCase(repository);

        var customer = new Customer(1, DateTime.Now)
        {
            Name = "AnyName2",
            Cpf = "22222222222",
            Email = "test@test2.com"
        };

        // Act
        await sut.UpdateAsync(customer, CancellationToken.None);

        // Assert
        await repository.Received(1).UpdateAsync(customer, CancellationToken.None);
    }
}
