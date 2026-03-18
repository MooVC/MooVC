namespace MooVC.Syntax.CSharp.Generics.Constraints.ConstraintTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenIsUnspecifiedIsCalled
{
    [Test]
    public async Task GivenUnspecifiedConstraintThenReturnsTrue()
    {
        // Arrange
        Constraint subject = Constraint.Unspecified;

        // Act
        bool result = subject.IsUnspecified;

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenSpecifiedConstraintThenReturnsFalse()
    {
        // Arrange
        var subject = new Constraint
        {
            Base = new Symbol { Name = "Result" },
        };

        // Act
        bool result = subject.IsUnspecified;

        // Assert
        await Assert.That(result).IsFalse();
    }
}