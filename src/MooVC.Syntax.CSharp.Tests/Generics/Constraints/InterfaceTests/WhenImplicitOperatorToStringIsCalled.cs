namespace MooVC.Syntax.CSharp.Generics.Constraints.InterfaceTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Name = "IDisposable";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Interface? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenInterfaceThenStringMatchesToString()
    {
        // Arrange
        Interface subject = new Declaration
        {
            Name = Name,
        };

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject);
    }
}