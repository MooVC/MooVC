namespace MooVC.Syntax.CSharp.DirectiveTests;

using System.Collections.Immutable;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Alias = "System";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Directive? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenDirectiveThenStringMatchesToString()
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
        _ = await Assert.That(result).IsEqualTo(subject.ToString());
    }
}