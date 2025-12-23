namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenEmptyReturned()
    {
        // Arrange
        Operators subject = Operators.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }
}
