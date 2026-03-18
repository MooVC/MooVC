namespace MooVC.Syntax.CSharp.Generics.Constraints.InterfaceTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Name = "IDisposable";

    [Test]
    public async Task GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Interface? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = await Assert.That(result).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenInterfaceThenStringMatchesToString()
    {
        // Arrange
        Interface subject = new Declaration
        {
            Name = Name,
        };

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(subject.ToString());
    }
}