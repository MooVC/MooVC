namespace MooVC.Syntax.CSharp.Concepts.StructTests.KindTests;

public sealed class WhenToStringIsCalled
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