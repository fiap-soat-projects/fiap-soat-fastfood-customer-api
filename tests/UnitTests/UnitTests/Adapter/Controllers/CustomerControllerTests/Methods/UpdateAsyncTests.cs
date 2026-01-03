using Adapter.Controllers;
using Adapter.Presenters.DTOs;
using Domain.Entities;
using Domain.UseCases.Interfaces;
using NSubstitute;
using NSubstitute.ReceivedExtensions;

namespace UnitTests.Adapter.Controllers.CustomerControllerTests.Methods;

public class UpdateAsyncTests
{
    [Fact]
    public async Task When_Invoked_Then_CallUpdateAsyncUseCase()
    {
        // Arrange
        var useCase = Substitute.For<ICustomerUseCase>();
        var sut = new CustomerController(useCase);

        var id = 1;

        var request = new UpdateCustomerRequest
        {
            Id = id,
            Name = "AnyName2",
            Email = "test2@test.com"
        };

        var currentCustomer = new Customer(id, DateTime.UtcNow, "AnyName", "11111111111", "test@test.com");

        useCase.GetByIdAsync(id, CancellationToken.None).Returns(currentCustomer);

        // Act
        var result = await sut.UpdateAsync(request, CancellationToken.None);

        // Assert
        Assert.Equal(request.Id, result.ViewModel.Id);
        Assert.Equal(currentCustomer.CreatedAt, result.ViewModel.CreatedAt);
        Assert.Equal(request.Name, result.ViewModel.Name);
        Assert.Equal(currentCustomer.Cpf, result.ViewModel.Cpf);
        Assert.Equal(request.Email, result.ViewModel.Email);
        Assert.NotNull(result.ViewModel.UpdatedAt);

        await useCase.Received(1).UpdateAsync(Arg.Is<Customer>(customer =>
            customer.Id == request.Id
            && customer.Name == request.Name
            && customer.Email.ToString() == request.Email
        ), Arg.Any<CancellationToken>());
    }
}
