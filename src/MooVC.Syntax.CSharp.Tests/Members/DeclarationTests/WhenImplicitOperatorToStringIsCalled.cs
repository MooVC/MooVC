namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Name = "Sample";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Declaration? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenDeclarationThenStringMatchesToString()
    {
        // Arrange
        var subject = new Declaration
        {
            Name = Name,
        };

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(subject.ToString());
    }
}