namespace MooVC.Syntax.CSharp.Elements.VariableTests.OptionsTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public void GivenEqualOptionsThenHashCodesAreEqual()
    {
        // Arrange
        var first = new Variable.Options();
        var second = new Variable.Options();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Test]
    public void GivenDifferentOptionsThenHashCodesAreDifferent()
    {
        // Arrange
        var first = new Variable.Options();
        var second = new Variable.Options { UseUnderscore = true };

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}