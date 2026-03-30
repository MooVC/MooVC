namespace MooVC.Syntax.CSharp.NatureTests;

public sealed class WhenEqualityOperatorNatureNatureIsCalled
{
    private const string Same = "class";
    private const string Different = "struct";

    [Test]
    public async Task GivenBothSidesNullThenReturnsTrue()
    {
        // Arrange
        Nature? left = default;
        Nature? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Nature left = Same;
        Nature right = Different;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEitherSideNullThenReturnsFalse()
    {
        // Arrange
        Nature left = Same;
        Nature? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Nature left = Same;
        Nature right = Same;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}