namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.OptionsTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public void GivenMatchingValuesThenReturnsSameHash()
    {
        // Arrange
        var first = new Argument.Options();
        var second = new Argument.Options();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Test]
    public void GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        var first = new Argument.Options();

        Argument.Options second = new Argument.Options()
            .WithNaming(Variable.Options.Pascal);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}