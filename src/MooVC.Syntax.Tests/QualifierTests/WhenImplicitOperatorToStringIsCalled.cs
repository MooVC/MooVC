namespace MooVC.Syntax.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string First = "System";
    private const string Second = "Collections";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Qualifier? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenQualifierThenStringMatchesToString()
    {
        // Arrange
        Qualifier subject = ImmutableArray.Create(
            new Name(First),
            new Name(Second));

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(subject.ToString());
    }
}