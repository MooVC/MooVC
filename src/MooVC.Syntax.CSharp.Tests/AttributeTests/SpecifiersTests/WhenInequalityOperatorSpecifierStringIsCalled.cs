namespace MooVC.Syntax.CSharp.AttributeTests.SpecifiersTests;

public sealed class WhenInequalityOperatorSpecifierStringIsCalled
{
    private const string Same = "type";
    private const string Different = "delegate";

    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifiers? left = default;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifiers left = Attribute.Specifiers.Type;
        string right = Different;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Attribute.Specifiers left = Attribute.Specifiers.Type;
        string right = Same;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifiers? left = default;
        string right = Same;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Attribute.Specifiers left = Attribute.Specifiers.Type;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}