namespace MooVC.Syntax.CSharp.Generics.Constraints.ConstraintTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenIsUnspecifiedIsCalled
{
    [Test]
    public void GivenUnspecifiedConstraintThenReturnsTrue()
    {
        // Arrange
        Constraint subject = Constraint.Unspecified;

        // Act
        bool result = subject.IsUnspecified;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenSpecifiedConstraintThenReturnsFalse()
    {
        // Arrange
        var subject = new Constraint
        {
            Base = new Symbol { Name = "Result" },
        };

        // Act
        bool result = subject.IsUnspecified;

        // Assert
        result.ShouldBeFalse();
    }
}