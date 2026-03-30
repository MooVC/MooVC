namespace MooVC.Syntax.CSharp.AttributeTests.SpecifierTests;

public sealed class WhenEqualityOperatorSpecifierStringIsCalled
{
    private const string Same = "class";
    private const string Different = "module";

    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifier? left = default;
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
        Attribute.Specifier left = Attribute.Specifier.Class;
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
        Attribute.Specifier left = Attribute.Specifier.Class;
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
        Attribute.Specifier? left = default;
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
        Attribute.Specifier left = Attribute.Specifier.Class;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}