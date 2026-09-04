namespace MooVC.Syntax.CSharp.StructTests.KindsTests;

public sealed class WhenInequalityOperatorKindStringIsCalled
{
    [Test]
    public async Task GivenKindDiffersFromStringThenReturnsTrue()
    {
        // Arrange
        Struct.Kinds left = Struct.Kinds.Ref;
        const string Right = "readonly";

        // Act
        bool result = left != Right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenKindMatchesStringThenReturnsFalse()
    {
        // Arrange
        Struct.Kinds left = Struct.Kinds.Record;
        const string Right = "record";

        // Act
        bool result = left != Right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenNullKindThenReturnsFalseWhenComparedToNull()
    {
        // Arrange
        Struct.Kinds left = default!;

        // Act
        bool result = left != default(string);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}