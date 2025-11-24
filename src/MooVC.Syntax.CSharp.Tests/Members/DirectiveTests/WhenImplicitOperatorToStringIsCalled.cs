namespace MooVC.Syntax.CSharp.Members.DirectiveTests;

using System.Collections.Immutable;

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
            Alias = Alias,
            Qualifier = ImmutableArray.Create(new Segment("Collections")),
        };

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}