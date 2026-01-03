using Domain.ValueObjects;

namespace UnitTests.Domain.ValueObjects.EmailTests;

public class OperatorTests
{
    [Fact]
    public void When_ToString_Then_ReturnAddress()
    {
        // Arrange
        var value = "test@test.com";
        var email = new Email(value);

        // Act
        var text = email.ToString();

        // Assert
        Assert.Equal(value, text);
    }

    [Fact]
    public void When_AdressProperty_Then_ReturnAddress()
    {
        // Arrange
        var value = "test@test.com";
        var email = new Email(value);

        // Assert
        Assert.Equal(value, email.Adress);
    }
}
