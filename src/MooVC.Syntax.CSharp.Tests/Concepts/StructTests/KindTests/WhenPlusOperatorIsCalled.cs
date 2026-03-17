namespace MooVC.Syntax.CSharp.Concepts.StructTests.KindTests;

public sealed class WhenPlusOperatorIsCalled
{
    [Test]
    public void GivenReadonlyRecordThenCombinedKindReturned()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.ReadOnly;
        Struct.Kind right = Struct.Kind.Record;

        // Act
        Struct.Kind result = left + right;

        // Assert
        result.ToString().ShouldBe("readonly record");
    }

    [Test]
    public void GivenInvalidCombinationThenThrows()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.Ref;
        Struct.Kind right = Struct.Kind.Record;

        // Act
        Func<Struct.Kind> result = () => left + right;

        // Assert
        _ = result.ShouldThrow<InvalidOperationException>();
    }

    [Test]
    public void GivenNullLeftThenThrows()
    {
        // Arrange
        Struct.Kind? left = default;
        Struct.Kind right = Struct.Kind.Record;

        // Act
        Func<Struct.Kind> result = () => left! + right;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void GivenNullRightThenThrows()
    {
        // Arrange
        Struct.Kind left = Struct.Kind.Record;
        Struct.Kind? right = default;

        // Act
        Func<Struct.Kind> result = () => left + right!;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }
}