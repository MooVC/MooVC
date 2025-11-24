namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using MooVC.Syntax.CSharp.Members;

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
        Base subject = new Symbol
        {
            Name = Value,
        };

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}