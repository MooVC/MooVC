namespace MooVC.Syntax.CSharp.Elements.ParameterTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Name = ParameterTestsData.DefaultName;

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Parameter? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenParameterThenStringMatchesToString()
    {
        // Arrange
        Parameter subject = ParameterTestsData.Create(name: Name);

        // Act
        string result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(subject.ToString());
    }
}