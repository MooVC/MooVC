namespace MooVC.Syntax.CSharp.StructTests.KindsTests;

public sealed class WhenEqualityOperatorKindStringIsCalled
{
    [Test]
    public async Task GivenKindDiffersFromStringThenReturnsFalse()
    {
        // Arrange
        Struct.Kinds left = Struct.Kinds.Ref;
        const string Right = "readonly";

        // Act
        bool result = left == Right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenKindMatchesStringThenReturnsTrue()
    {
        // Arrange
        Struct.Kinds left = Struct.Kinds.Record;
        const string Right = "record";

        // Act
        bool result = left == Right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNullKindThenMatchesOnlyNullOrEmptyStrings()
    {
        // Arrange
        Struct.Kinds left = default!;

        // Act
        bool result = left == default(string);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}