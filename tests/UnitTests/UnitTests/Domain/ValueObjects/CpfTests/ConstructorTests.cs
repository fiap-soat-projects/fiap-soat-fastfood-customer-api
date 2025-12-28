using Domain.ValueObjects;
using Domain.ValueObjects.Exceptions;

namespace UnitTests.Domain.ValueObjects.CpfTests;

public class ConstructorTests
{
    [Fact]
    public void When_CpfIsNull_Then_ThrowArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => _ = new Cpf(null!));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void When_CpfIsEmptyOrWhiteSpace_Then_ThrowArgumentException(string? number)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => _ = new Cpf(number!));
    }

    [Theory]
    [InlineData("123")]
    [InlineData("abcdefghijk")]
    [InlineData("1111111111a")]
    public void When_CpfIsInvalidFormat_Then_ThrowInvalidCpfException(string number)
    {
        // Act & Assert
        Assert.Throws<InvalidCpfException>(() => _ = new Cpf(number));
    }

    [Fact]
    public void When_CpfIsValid_Then_Create()
    {
        // Arrange
        var value = "12345678901";

        // Act
        var cpf = new Cpf(value);

        // Assert
        Assert.Equal(value, cpf.Number);
        Assert.Equal(value, cpf.ToString());
    }
}
