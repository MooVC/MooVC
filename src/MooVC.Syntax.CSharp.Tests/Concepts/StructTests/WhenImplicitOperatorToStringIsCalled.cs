namespace MooVC.Syntax.CSharp.Concepts.StructTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Fact]
    public void GivenKindThenReturnsString()
    {
        // Arrange
        Struct.Kind subject = Struct.Kind.ReadOnly;

        // Act
        string result = subject;

        // Assert
        result.ShouldBe("readonly");
    }
}
