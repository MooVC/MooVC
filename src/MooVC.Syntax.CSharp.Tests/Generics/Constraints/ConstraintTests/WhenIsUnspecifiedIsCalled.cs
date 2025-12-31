namespace MooVC.Syntax.CSharp.Generics.Constraints.ConstraintTests;

using MooVC.Syntax.CSharp.Elements;
using Variable = MooVC.Syntax.CSharp.Elements.Variable;

public sealed class WhenIsUnspecifiedIsCalled
{
    [Fact]
    public void GivenUnspecifiedConstraintThenReturnsTrue()
    {
        // Arrange
        Constraint subject = Constraint.Unspecified;

        // Act
        bool result = subject.IsUnspecified;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenSpecifiedConstraintThenReturnsFalse()
    {
        // Arrange
        var subject = new Constraint
        {
            Base = new Symbol { Name = new Variable("Result") },
        };

        // Act
        bool result = subject.IsUnspecified;

        // Assert
        result.ShouldBeFalse();
    }
}