namespace MooVC.Syntax.CSharp.Generics.Constraints.ConstraintTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Fact]
    public void GivenNullSubjectThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Constraint? subject = default;

        // Act
        Func<string> result = () => subject;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenConstraintThenStringMatchesToString()
    {
        // Arrange
        var subject = new Constraint
        {
            Base = Base.Unspecified,
            Interfaces = [Interface.Undefined],
            Nature = Nature.Unspecified,
        };

        // Act
        string result = subject;

        // Assert
        result.ShouldBe(subject.ToString());
    }
}