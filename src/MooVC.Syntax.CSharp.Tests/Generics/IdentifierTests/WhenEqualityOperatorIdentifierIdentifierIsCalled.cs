namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

public sealed class WhenEqualityOperatorIdentifierIdentifierIsCalled
{
    private const string Alternative = "Other";
    private const string Value = "Value";

    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Identifier? left = default;
        Identifier? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Identifier? left = default;
        Identifier right = Value;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Identifier left = Value;
        Identifier? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Identifier first = Value;
        Identifier second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Identifier left = Value;
        Identifier right = Value;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Identifier left = Value;
        Identifier right = Alternative;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}