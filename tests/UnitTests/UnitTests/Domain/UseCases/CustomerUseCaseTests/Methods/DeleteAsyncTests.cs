using Domain.Gateways.Repositories.Interfaces;
using Domain.UseCases;
using NSubstitute;

namespace UnitTests.Domain.UseCases.CustomerUseCaseTests.Methods;

public class DeleteAsyncTests
{
    [Fact]
    public async Task When_Invoked_Then_CallRepositoryToDeleteCustomer()
    {
        // Arrange
        var repository = Substitute.For<ICustomerRepository>();
        var sut = new CustomerUseCase(repository);

        var customerId = 1;

        // Act
        await sut.DeleteAsync(customerId, CancellationToken.None);

        // Assert
        await repository.Received(1).DeleteAsync(customerId, CancellationToken.None);
    }
}
