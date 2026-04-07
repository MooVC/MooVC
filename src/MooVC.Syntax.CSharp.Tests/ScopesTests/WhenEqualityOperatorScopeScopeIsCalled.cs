namespace MooVC.Syntax.CSharp.ScopesTests;

public sealed class WhenEqualityOperatorScopeScopeIsCalled
{
    private const string Same = "internal";
    private const string Different = "public";

    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Scopes? left = default;
        Scopes? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Scopes left = Same;
        Scopes right = Different;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Scopes left = Same;
        Scopes right = Same;

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Scopes? left = default;
        Scopes right = Same;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Scopes left = Same;
        Scopes? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Scopes first = Same;
        Scopes second = first;

        // Act
        bool result = first == second;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}