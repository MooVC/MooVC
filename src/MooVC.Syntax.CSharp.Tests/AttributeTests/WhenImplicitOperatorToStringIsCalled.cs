namespace MooVC.Syntax.CSharp.AttributeTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Name = "Obsolete";

    [Test]
    public async Task GivenAttributeThenStringMatchesToString()
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
        _ = await Assert.That(result).IsEqualTo(subject.ToString());
    }

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Attribute? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }
}