namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.ModeTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenMatchingValuesThenReturnsSameHash()
    {
        // Arrange
        Argument.Mode first = Argument.Mode.Ref;
        Argument.Mode second = Argument.Mode.Ref;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsDifferentHashes()
    {
        // Arrange
        Argument.Mode first = Argument.Mode.In;
        Argument.Mode second = Argument.Mode.Out;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}