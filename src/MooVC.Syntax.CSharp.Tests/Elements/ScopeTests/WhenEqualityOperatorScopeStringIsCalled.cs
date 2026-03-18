namespace MooVC.Syntax.CSharp.Elements.ScopeTests;

public sealed class WhenEqualityOperatorScopeStringIsCalled
{
    private const string Same = "internal";
    private const string Different = "public";

    [Test]
    public async Task GivenSubjectNullValueNullThenReturnsTrue()
    {
        // Arrange
        Scope? left = default;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenSubjectNullValueThenReturnsFalse()
    {
        // Arrange
        Scope? left = default;
        string right = Same;

        // Act
        bool result = left == right;

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSubjectValueValueNullThenReturnsFalse()
    {
        // Arrange
        Scope left = Same;
        string? right = default;

        // Act
        bool result = left == right;

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Scope left = Same;
        string right = Same;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        await Assert.That(resultLeftRight).IsTrue();
        await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Scope left = Same;
        string right = Different;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        await Assert.That(resultLeftRight).IsFalse();
        await Assert.That(resultRightLeft).IsFalse();
    }
}