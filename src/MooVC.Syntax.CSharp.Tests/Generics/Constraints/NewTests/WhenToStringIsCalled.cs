namespace MooVC.Syntax.CSharp.Generics.Constraints.NewTests;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenRequiredThenReturnsNewConstraint()
    {
        // Arrange
        New subject = New.Required;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe("new()");
    }

    [Fact]
    public void GivenNotRequiredThenReturnsEmpty()
    {
        // Arrange
        New subject = New.NotRequired;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }
}
