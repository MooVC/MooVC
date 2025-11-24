namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Value = "BaseClass";

    [Fact]
    public void GivenNullSubjectThenEmptyIsReturned()
    {
        // Arrange
        Base? subject = default;

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenBaseThenStringMatchesToString()
    {
        // Arrange
        var subject = new Base
        {
            Type = new Declaration
            {
                Name = new Identifier(Value),
            },
        };

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}
