namespace MooVC.Syntax.CSharp.Generics.Constraints.InterfaceTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualsDeclarationIsCalled
{
    private const string Same = "IAlpha";
    private const string Different = "IBeta";

    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Interface subject = new Declaration { Name = Same };
        Declaration? other = default;

        // Act
        bool resultLeftRight = subject.Equals(other);
        bool resultRightLeft = other?.Equals(subject) ?? false;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Interface left = new Declaration { Name = Same };
        var right = new Declaration { Name = Same };

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Interface left = new Declaration { Name = Same };
        var right = new Declaration { Name = Different };

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}