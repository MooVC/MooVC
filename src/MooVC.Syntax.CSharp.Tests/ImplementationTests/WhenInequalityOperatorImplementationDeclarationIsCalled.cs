namespace MooVC.Syntax.CSharp.ImplementationTests;

public sealed class WhenInequalityOperatorImplementationDeclarationIsCalled
{
    private const string Same = "IAlpha";
    private const string Different = "IBeta";

    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Implementation? left = default;
        Declaration? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Implementation left = new Declaration { Name = Same };
        var right = new Declaration { Name = Different };

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEitherSideNullThenReturnsTrue()
    {
        // Arrange
        Implementation left = new Declaration { Name = Same };
        Declaration? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Implementation left = new Declaration { Name = Same };
        var right = new Declaration { Name = Same };

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}