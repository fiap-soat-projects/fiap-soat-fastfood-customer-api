using Domain.Entities;

namespace UnitTests.Domain.Entities.CustomerTests;

public class UpdateTests
{
    [Fact]
    public void When_UpdateWithName_Then_SetNameAndUpdatedAt()
    {
        // Arrange
        var customer = new Customer("AnyName", "12345678901", "test@test.com");

        // Act
        customer.Update(name: "NewName");

        // Assert
        Assert.Equal("NewName", customer.Name);
        Assert.NotNull(customer.UpdatedAt);
    }

    [Fact]
    public void When_UpdateWithEmail_Then_SetEmailAndUpdatedAt()
    {
        // Arrange
        var customer = new Customer("AnyName", "12345678901", "test@test.com");

        // Act
        customer.Update(email: "new@test.com");

        // Assert
        Assert.Equal("new@test.com", customer.Email.ToString());
        Assert.NotNull(customer.UpdatedAt);
    }

    [Fact]
    public void When_UpdateWithNulls_Then_DoNotChangeNameButSetUpdatedAt()
    {
        // Arrange
        var customer = new Customer("AnyName", "12345678901", "test@test.com");
        var createdAt = customer.CreatedAt;

        // Act
        customer.Update(name: null, email: null);

        // Assert
        Assert.Equal("AnyName", customer.Name);
        Assert.Equal(createdAt, customer.CreatedAt);
        Assert.NotNull(customer.UpdatedAt);
    }
}
