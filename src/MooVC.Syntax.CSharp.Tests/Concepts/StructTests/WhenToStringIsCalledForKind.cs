namespace MooVC.Syntax.CSharp.Concepts.StructTests;

public sealed class WhenToStringIsCalledForKind
{
    [Fact]
    public void GivenKindThenReturnsUnderlyingValue()
    {
        // Arrange
        Struct.Kind subject = Struct.Kind.Ref;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe("ref");
    }
}
