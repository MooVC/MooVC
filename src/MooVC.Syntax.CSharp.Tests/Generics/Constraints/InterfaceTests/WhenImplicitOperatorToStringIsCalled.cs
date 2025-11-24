namespace MooVC.Syntax.CSharp.Generics.Constraints.InterfaceTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Name = "IDisposable";

    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Interface? subject = default;

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenInterfaceThenStringMatchesToString()
    {
        // Arrange
        var subject = new Interface
        {
            Declaration = new Declaration
            {
                Name = new Identifier(Name),
            },
        };

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}
