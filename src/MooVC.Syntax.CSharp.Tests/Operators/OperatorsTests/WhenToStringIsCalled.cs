namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

public sealed class WhenToStringIsCalled
{
    [Test]
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