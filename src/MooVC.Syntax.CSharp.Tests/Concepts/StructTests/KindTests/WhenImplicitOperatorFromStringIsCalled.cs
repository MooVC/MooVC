namespace MooVC.Syntax.CSharp.Concepts.StructTests.KindTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Fact]
    public void GivenStringThenReturnsKind()
    {
        // Arrange
        const string Value = "record";

        // Act
        Struct.Kind result = Value;

        // Assert
        result.ShouldBe(Struct.Kind.Record);
    }
}