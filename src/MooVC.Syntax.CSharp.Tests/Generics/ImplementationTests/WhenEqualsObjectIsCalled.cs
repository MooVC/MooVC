namespace MooVC.Syntax.CSharp.Generics.Constraints.ImplementationTests;

public sealed class WhenEqualsObjectIsCalled
{
    private const string Same = "IAlpha";
    private const string Different = "IBeta";

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Implementation subject = new Declaration { Name = Same };
        object? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Implementation subject = new Declaration { Name = Same };
        object other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Implementation left = new Declaration { Name = Same };
        object right = (Implementation)new Declaration { Name = Same };

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Implementation left = new Declaration { Name = Same };
        object right = (Implementation)new Declaration { Name = Different };

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenNonImplementationThenReturnsFalse()
    {
        // Arrange
        Implementation subject = new Declaration { Name = Same };
        object other = new Declaration { Name = Same };

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}