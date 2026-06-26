namespace MooVC.Syntax.CSharp.ConversionTests.IntentsTests;

public sealed class WhenEqualsStringIsCalled
{
    private const string Value = "From";
    private const string Other = "To";

    [Test]
    public async Task GivenADifferentValueThenReturnsFalse()
    {
        // Arrange
        Conversion.Intents intent = Conversion.Intents.From;

        // Act
        bool result = intent.Equals(Other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Conversion.Intents intent = Conversion.Intents.From;

        // Act
        bool result = intent.Equals(default(string?));

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Conversion.Intents intent = Conversion.Intents.From;

        // Act
        bool result = intent.Equals(Value);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}