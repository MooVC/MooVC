namespace MooVC.Syntax.CSharp.Members.DirectiveTests;

using System.Collections.Immutable;
using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Alias = "System";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Directive? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenDirectiveThenStringMatchesToString()
    {
        // Arrange
        var subject = new Directive
        {
            Alias = Alias,
            Qualifier = ImmutableArray.Create(new Name("Collections")),
        };

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}