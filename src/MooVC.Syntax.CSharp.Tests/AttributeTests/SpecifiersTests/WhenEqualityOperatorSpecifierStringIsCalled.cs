namespace MooVC.Syntax.CSharp.AttributeTests.SpecifiersTests;

public sealed class WhenEqualityOperatorSpecifierStringIsCalled
{
    private const string Same = "class";
    private const string Different = "module";

    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifiers? left = default;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifiers left = Attribute.Specifiers.Class;
        string right = Different;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifiers left = Attribute.Specifiers.Class;
        string right = Same;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifiers? left = default;
        string right = Same;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifiers left = Attribute.Specifiers.Class;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}