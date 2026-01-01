namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Name = "Sample";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Declaration? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenDeclarationThenStringMatchesToString()
    {
        // Arrange
        var subject = new Declaration
        {
            Name = Name,
        };

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}