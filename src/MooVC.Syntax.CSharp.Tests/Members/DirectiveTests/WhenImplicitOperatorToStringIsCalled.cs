namespace MooVC.Syntax.CSharp.Members.DirectiveTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Alias = "System";

    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Directive? subject = default;

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenDirectiveThenStringMatchesToString()
    {
        // Arrange
        var subject = new Directive
        {
            Alias = new Identifier(Alias),
            Qualifier = new Segment("Collections"),
        };

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}
