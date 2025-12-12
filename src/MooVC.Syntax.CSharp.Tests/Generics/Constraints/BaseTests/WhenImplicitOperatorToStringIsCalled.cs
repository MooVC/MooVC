namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using MooVC.Syntax.CSharp.Members;
using Shouldly;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    private const string Value = "BaseClass";

    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Base? @base = default;

        // Act
        Func<string> result = () => @base;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
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