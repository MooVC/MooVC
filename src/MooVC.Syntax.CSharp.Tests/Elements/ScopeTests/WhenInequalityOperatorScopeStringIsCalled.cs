namespace MooVC.Syntax.CSharp.Elements.ScopeTests;

public sealed class WhenInequalityOperatorScopeStringIsCalled
{
    private const string Same = "internal";
    private const string Different = "public";

    [Test]
    public async Task GivenSubjectNullValueNullThenReturnsFalse()
    {
        // Arrange
        Scope? left = default;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSubjectNullValueThenReturnsTrue()
    {
        // Arrange
        Scope? left = default;
        string right = Same;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenSubjectValueValueNullThenReturnsTrue()
    {
        // Arrange
        Scope left = Same;
        string? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Scope left = Same;
        string right = Same;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Scope left = Same;
        string right = Different;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }
}