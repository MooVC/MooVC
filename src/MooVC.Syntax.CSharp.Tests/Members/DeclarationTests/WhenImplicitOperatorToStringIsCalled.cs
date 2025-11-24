namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Name = "Sample";

    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Declaration? subject = default;

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenDeclarationThenStringMatchesToString()
    {
        // Arrange
        var subject = new Declaration
        {
            Name = new Identifier(Name),
        };

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}
