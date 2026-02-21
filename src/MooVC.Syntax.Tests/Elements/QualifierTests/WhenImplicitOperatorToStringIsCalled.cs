namespace MooVC.Syntax.Elements.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string First = "System";
    private const string Second = "Collections";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Qualifier? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenQualifierThenStringMatchesToString()
    {
        // Arrange
        Qualifier subject = ImmutableArray.Create(
            new Name(First),
            new Name(Second));

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}