namespace MooVC.Syntax.CSharp.ConversionTests.IntentTests;

public sealed class WhenEqualsStringIsCalled
{
    private const string Value = "From";
    private const string Other = "To";

    [Test]
    public async Task GivenADifferentValueThenReturnsFalse()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        bool result = intent.Equals(Other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenANullReferenceThenReturnsFalse()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        bool result = intent.Equals(default(string?));

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenTheSameValueThenReturnsTrue()
    {
        // Arrange
        Conversion.Intent intent = Conversion.Intent.From;

        // Act
        bool result = intent.Equals(Value);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}