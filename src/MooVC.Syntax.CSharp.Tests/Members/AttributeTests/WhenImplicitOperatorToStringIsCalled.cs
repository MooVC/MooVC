namespace MooVC.Syntax.CSharp.Members.AttributeTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Name = "Obsolete";

    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Attribute? subject = default;

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenAttributeThenStringMatchesToString()
    {
        // Arrange
        var subject = new Attribute
        {
            Name = new Identifier(Name),
        };

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}
