namespace MooVC.Syntax.CSharp.Concepts.StructTests.KindTests;

public sealed class WhenPlusOperatorIsCalled
{
    [Test]
    public async Task GivenReadonlyRecordThenCombinedKindReturned()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.ReadOnly;
        Struct.Kind right = Struct.Kind.Record;

        // Act
        Struct.Kind result = left + right;

        // Assert
        await Assert.That(result.ToString()).IsEqualTo("readonly record");
    }

    [Test]
    public async Task GivenInvalidCombinationThenThrows()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.Ref;
        Struct.Kind right = Struct.Kind.Record;

        // Act
        Func<Struct.Kind> result = () => left + right;

        // Assert
        await Assert.That(result).Throws<InvalidOperationException>();
    }

    [Test]
    public async Task GivenNullLeftThenThrows()
    {
        // Arrange
        Struct.Kind? left = default;
        Struct.Kind right = Struct.Kind.Record;

        // Act
        Func<Struct.Kind> result = () => left! + right;

        // Assert
        await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenNullRightThenThrows()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.Record;
        Struct.Kind? right = default;

        // Act
        Func<Struct.Kind> result = () => left + right!;

        // Assert
        await Assert.That(result).Throws<ArgumentNullException>();
    }
}