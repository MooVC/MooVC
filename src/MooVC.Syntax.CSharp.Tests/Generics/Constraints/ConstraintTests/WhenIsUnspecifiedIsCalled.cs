namespace MooVC.Syntax.CSharp.Generics.Constraints.ConstraintTests;

using MooVC.Syntax.CSharp.Elements;
using Identifier = MooVC.Syntax.CSharp.Elements.Identifier;

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
            Base = new Symbol { Name = new Identifier("Result") },
        };

        // Act
        bool result = subject.IsUnspecified;

        // Assert
        result.ShouldBeFalse();
    }
}