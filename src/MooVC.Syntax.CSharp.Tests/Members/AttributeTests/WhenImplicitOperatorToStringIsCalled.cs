namespace MooVC.Syntax.CSharp.Members.AttributeTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Name = "Obsolete";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Attribute? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenAttributeThenStringMatchesToString()
    {
        // Arrange
        var subject = new Attribute
        {
            Name = new Symbol
            {
                Name = Name,
            },
        };

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject);
    }
}