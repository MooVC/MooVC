namespace Mu.Modelling.NonMutationalTests;

using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    private const string ViewNameValue = "ViewName";

    [Fact]
    public void GivenValuesThenContainsDetails()
    {
        // Arrange
        var view = new Identifier(ViewNameValue);
        NonMutational subject = ModellingTestData.CreateNonMutational(view: view);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldContain(nameof(NonMutational));
        result.ShouldContain(ViewNameValue);
    }
}