namespace MooVC.Syntax.Elements.IdentifierTests.OptionsTests;

public sealed class WhenEqualityOperatorOptionsOptionsIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Identifier.Options? left = default;
        Identifier.Options? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Identifier.Options? left = default;
        var right = new Identifier.Options();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Identifier.Options();
        var right = new Identifier.Options();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Identifier.Options { Casing = Identifier.Casing.Camel };
        var right = new Identifier.Options { Casing = Identifier.Casing.Kebab };

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}