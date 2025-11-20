namespace MooVC.Syntax.CSharp.Generics.Constraints.InterfaceTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenEqualsObjectIsCalled
{
    private const string Same = "IAlpha";
    private const string Different = "IBeta";

    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Interface subject = new Declaration { Name = new Identifier(Same) };
        object? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Interface subject = new Declaration { Name = new Identifier(Same) };
        object other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Interface left = new Declaration { Name = new Identifier(Same) };
        object right = (Interface)new Declaration { Name = new Identifier(Same) };

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Interface left = new Declaration { Name = new Identifier(Same) };
        object right = (Interface)new Declaration { Name = new Identifier(Different) };

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenNonInterfaceThenReturnsFalse()
    {
        // Arrange
        Interface subject = new Declaration { Name = new Identifier(Same) };
        object other = new Declaration { Name = new Identifier(Same) };

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}