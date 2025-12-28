using Domain.Entities;
using Domain.Entities.Exceptions;

namespace UnitTests.Domain.Entities.CustomerTests;

public class ConstructorTests
{
    [Fact]
    public void When_NameIsNull_Then_ThrowCustomerPropertyException()
    {
        // Act & Assert
        Assert.Throws<CustomerPropertyException>(() => _ = new Customer(null!, "12345678901", "test@test.com"));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void When_NameIsEmptyOrWhiteSpace_Then_ThrowCustomerPropertyException(string? name)
    {
        // Act & Assert
        Assert.Throws<CustomerPropertyException>(() => _ = new Customer(name!, "12345678901", "test@test.com"));
    }

    [Fact]
    public void When_Invoked_Then_Create()
    {
        // Arrange
        var name = "AnyName";
        var cpf = "12345678901";
        var email = "test@test.com";

        // Act
        var customer = new Customer(name, cpf, email);

        // Assert
        Assert.Equal(name, customer.Name);
        Assert.Equal(cpf, customer.Cpf);
        Assert.Equal(email, customer.Email);
    }

    [Fact]
    public void When_CtorWithId_Then_SetProperties()
    {
        // Arrange
        var id = 1;
        var createdAt = DateTime.UtcNow;

        // Act
        var customer = new Customer(id, createdAt)
        {
            Name = "AnyName",
            Cpf = "12345678901",
            Email = "test@test.com"
        };

        // Assert
        Assert.Equal(id, customer.Id);
        Assert.Equal(createdAt, customer.CreatedAt);
        Assert.Null(customer.UpdatedAt);
        Assert.Equal("AnyName", customer.Name);
        Assert.Equal("12345678901", customer.Cpf);
        Assert.Equal("test@test.com", customer.Email);
    }
}
