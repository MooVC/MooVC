namespace MooVC.Syntax.CSharp.Generics.IdentifierTests;

public sealed class WhenInequalityOperatorIdentifierIdentifierIsCalled
{
    private const string Alternative = "Other";
    private const string Value = "Value";

    [Test]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Identifier? left = default;
        Identifier? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Identifier? left = default;
        Identifier right = Value;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Identifier left = Value;
        Identifier? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        Identifier first = Value;
        Identifier second = first;

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Identifier left = Value;
        Identifier right = Value;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Identifier left = Value;
        Identifier right = Alternative;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}