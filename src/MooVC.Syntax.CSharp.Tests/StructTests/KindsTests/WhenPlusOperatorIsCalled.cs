namespace MooVC.Syntax.CSharp.StructTests.KindsTests;

public sealed class WhenPlusOperatorIsCalled
{
    [Test]
    public async Task GivenInvalidCombinationThenThrows()
    {
        // Arrange
        Struct.Kinds left = Struct.Kinds.Ref;
        Struct.Kinds right = Struct.Kinds.Record;

        // Act
        Func<Struct.Kinds> result = () => left + right;

        // Assert
        _ = await Assert.That(result).Throws<InvalidOperationException>();
    }

    [Test]
    public async Task GivenNullLeftThenThrows()
    {
        // Arrange
        Struct.Kinds? left = default;
        Struct.Kinds right = Struct.Kinds.Record;

        // Act
        Func<Struct.Kinds> result = () => left! + right;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenNullRightThenThrows()
    {
        // Arrange
        Struct.Kinds left = Struct.Kinds.Record;
        Struct.Kinds? right = default;

        // Act
        Func<Struct.Kinds> result = () => left + right!;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenReadonlyRecordThenCombinedKindReturned()
    {
        // Arrange
        Struct.Kinds left = Struct.Kinds.ReadOnly;
        Struct.Kinds right = Struct.Kinds.Record;

        // Act
        Struct.Kinds result = left + right;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo("readonly record");
    }
}