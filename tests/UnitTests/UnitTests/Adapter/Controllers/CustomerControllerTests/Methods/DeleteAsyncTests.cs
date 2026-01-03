using Adapter.Controllers;
using Domain.UseCases.Interfaces;
using NSubstitute;

namespace UnitTests.Adapter.Controllers.CustomerControllerTests.Methods;

public class DeleteAsyncTests
{
    [Fact]
    public async Task When_Invoked_Then_CallDeleteAsyncUseCase()
    {
        // Arrange
        var useCase = Substitute.For<ICustomerUseCase>();
        var sut = new CustomerController(useCase);

        var customerId = 1;

        // Act
        await sut.DeleteAsync(customerId, CancellationToken.None);

        // Assert
        await useCase.Received(1).DeleteAsync(customerId, CancellationToken.None);
    }
}
