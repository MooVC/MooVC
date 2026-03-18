namespace MooVC.Syntax.CSharp.VariableTests.OptionsTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEqualOptionsThenHashCodesAreEqual()
    {
        // Arrange
        var first = new Variable.Options();
        var second = new Variable.Options();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentOptionsThenHashCodesAreDifferent()
    {
        // Arrange
        var first = new Variable.Options();
        var second = new Variable.Options { UseUnderscore = true };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }
}