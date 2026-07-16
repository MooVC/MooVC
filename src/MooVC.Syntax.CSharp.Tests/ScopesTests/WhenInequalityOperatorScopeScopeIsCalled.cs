namespace MooVC.Syntax.CSharp.ScopesTests;

public sealed class WhenInequalityOperatorScopeScopeIsCalled
{
    private const string Same = "internal";
    private const string Different = "public";

    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Scopes? left = default;
        Scopes? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Scopes left = Same;
        Scopes right = Different;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Scopes left = Same;
        Scopes right = Same;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Scopes? left = default;
        Scopes right = Same;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Scopes left = Same;
        Scopes? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}