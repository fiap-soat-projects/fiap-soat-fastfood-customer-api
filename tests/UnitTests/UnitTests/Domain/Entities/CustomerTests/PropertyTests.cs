using Domain.Entities;
using Domain.Entities.Exceptions;

namespace UnitTests.Domain.Entities.CustomerTests;

public class PropertyTests
{
    [Fact]
    public void When_SetIdToNull_Then_ThrowCustomerPropertyException()
    {
        // Arrange
        var customer = new Customer("AnyName", "12345678901", "test@test.com");

        // Act & Assert
        Assert.Throws<CustomerPropertyException>(() => customer.Id = default);
    }

    [Fact]
    public void When_SetNameToNull_Then_ThrowCustomerPropertyException()
    {
        // Arrange
        var customer = new Customer("AnyName", "12345678901", "test@test.com");

        // Act & Assert
        Assert.Throws<CustomerPropertyException>(() => customer.Name = null!);
    }

    [Fact]
    public void When_SetCpfToNull_Then_ThrowCustomerPropertyException()
    {
        // Arrange
        var customer = new Customer("AnyName", "12345678901", "test@test.com");

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => customer.Cpf = null!);
    }

    [Fact]
    public void When_SetEmailToNullOrWhiteSpace_Then_DoNotSet()
    {
        // Arrange
        var customer = new Customer("AnyName", "12345678901", "test@test.com");

        // Act
        customer.Update(email: null);

        // Assert
        Assert.Equal("test@test.com", customer.Email.ToString());
    }

    [Fact]
    public void When_Update_Then_SetUpdatedAt()
    {
        // Arrange
        var customer = new Customer("AnyName", "12345678901", "test@test.com");

        // Act
        customer.Update();

        // Assert
        Assert.NotNull(customer.UpdatedAt);
    }
}
