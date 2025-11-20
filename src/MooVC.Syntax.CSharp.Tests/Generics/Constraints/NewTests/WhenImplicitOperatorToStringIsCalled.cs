namespace MooVC.Syntax.CSharp.Generics.Constraints.NewTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Fact]
    public void GivenNewConstraintThenReturnsValue()
    {
        // Arrange
        New subject = "new()";

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}
