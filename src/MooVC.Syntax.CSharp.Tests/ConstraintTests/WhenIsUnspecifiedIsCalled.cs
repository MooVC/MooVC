namespace MooVC.Syntax.CSharp.ConstraintTests;

public sealed class WhenIsUnspecifiedIsCalled
{
    [Test]
    public async Task GivenSpecifiedConstraintThenReturnsFalse()
    {
        // Arrange
        var subject = new Constraint
        {
            Base = new() { Name = "Result" },
        };

        // Act
        bool result = subject.IsUnspecified;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenUnspecifiedConstraintThenReturnsTrue()
    {
        // Arrange
        Constraint subject = Constraint.Unspecified;

        // Act
        bool result = subject.IsUnspecified;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}