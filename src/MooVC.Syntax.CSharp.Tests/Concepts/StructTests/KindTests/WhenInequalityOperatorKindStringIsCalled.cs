namespace MooVC.Syntax.CSharp.Concepts.StructTests.KindTests;

public sealed class WhenInequalityOperatorKindStringIsCalled
{
    [Test]
    public async Task GivenKindMatchesStringThenReturnsFalse()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.Record;
        const string Right = "record";

        // Act
        bool result = left != Right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenKindDiffersFromStringThenReturnsTrue()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.Ref;
        const string Right = "readonly";

        // Act
        bool result = left != Right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullKindThenReturnsFalseWhenComparedToNull()
    {
        // Arrange
        Struct.Kind left = default!;

        // Act
        bool result = left != default(string);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}