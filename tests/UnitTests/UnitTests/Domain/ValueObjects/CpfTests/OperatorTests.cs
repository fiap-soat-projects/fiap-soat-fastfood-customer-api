using Domain.ValueObjects;

namespace UnitTests.Domain.ValueObjects.CpfTests;

public class OperatorTests
{
    [Fact]
    public void When_ImplicitConversionFromString_Then_CreateCpf()
    {
        // Arrange
        var value = "12345678901";

        // Act
        Cpf cpf = value;

        // Assert
        Assert.Equal(value, cpf.Number);
    }

    [Fact]
    public void When_ImplicitConversionToString_Then_ReturnNumber()
    {
        // Arrange
        var value = "12345678901";
        var cpf = new Cpf(value);

        // Act
        string text = cpf;

        // Assert
        Assert.Equal(value, text);
    }
}
