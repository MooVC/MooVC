namespace MooVC.Syntax.CSharp.MonikerTests;

public sealed class WhenInequalityOperatorMonikerMonikerIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Moniker left = "Value";
        Moniker right = "Other";

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Moniker left = "Value";
        Moniker right = "Value";

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}