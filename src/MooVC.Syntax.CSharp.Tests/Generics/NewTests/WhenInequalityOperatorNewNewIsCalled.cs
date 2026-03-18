namespace MooVC.Syntax.CSharp.Generics.Constraints.NewTests;

public sealed class WhenInequalityOperatorNewNewIsCalled
{
    private const string Same = "new()";
    private const string Different = "";

    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        New? left = default;
        New? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEitherSideNullThenReturnsTrue()
    {
        // Arrange
        New left = Same;
        New? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        New left = Same;
        New right = Same;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        New left = Same;
        New right = Different;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}