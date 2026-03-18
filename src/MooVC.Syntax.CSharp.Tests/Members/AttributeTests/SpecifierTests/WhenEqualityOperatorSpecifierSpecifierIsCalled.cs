namespace MooVC.Syntax.CSharp.Members.AttributeTests.SpecifierTests;

public sealed class WhenEqualityOperatorSpecifierSpecifierIsCalled
{
    private const string Alternative = "property";

    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifier? left = default;
        Attribute.Specifier? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifier? left = default;
        Attribute.Specifier right = Attribute.Specifier.Method;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifier left = Attribute.Specifier.Method;
        Attribute.Specifier? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifier first = Attribute.Specifier.Method;
        Attribute.Specifier second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifier left = Attribute.Specifier.Method;
        Attribute.Specifier right = Attribute.Specifier.Method;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifier left = Attribute.Specifier.Method;
        Attribute.Specifier right = Alternative;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}