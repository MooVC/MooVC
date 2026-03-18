namespace MooVC.Syntax.CSharp.StructTests.KindTests;

public sealed class WhenEqualityOperatorKindStringIsCalled
{
    [Test]
    public async Task GivenKindMatchesStringThenReturnsTrue()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.Record;
        const string Right = "record";

        // Act
        bool result = left == Right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenKindDiffersFromStringThenReturnsFalse()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.Ref;
        const string Right = "readonly";

        // Act
        bool result = left == Right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenNullKindThenMatchesOnlyNullOrEmptyStrings()
    {
        // Arrange
        Struct.Kind left = default!;

        // Act
        bool result = left == default(string);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}