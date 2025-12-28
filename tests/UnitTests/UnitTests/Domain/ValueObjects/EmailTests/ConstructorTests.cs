using Domain.ValueObjects;

namespace UnitTests.Domain.ValueObjects.EmailTests;

public class ConstructorTests
{
    [Fact]
    public void When_EmailIsNull_Then_ThrowArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => _ = new Email(null!));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void When_EmailIsEmptyOrWhiteSpace_Then_ThrowArgumentException(string? address)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => _ = new Email(address!));
    }

    [Fact]
    public void When_EmailIsValid_Then_Create()
    {
        // Arrange
        var value = "test@test.com";

        // Act
        var email = new Email(value);

        // Assert
        Assert.Equal(value, email.Adress);
        Assert.Equal(value, email.ToString());
    }
}
