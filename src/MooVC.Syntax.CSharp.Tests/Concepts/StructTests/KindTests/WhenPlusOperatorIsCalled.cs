namespace MooVC.Syntax.CSharp.Concepts.StructTests.KindTests;

public sealed class WhenPlusOperatorIsCalled
{
    [Fact]
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

    [Fact]
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

    [Fact]
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

    [Fact]
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