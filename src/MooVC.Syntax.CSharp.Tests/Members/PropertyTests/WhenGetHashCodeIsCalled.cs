namespace MooVC.Syntax.CSharp.Members.PropertyTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEquivalentInstancesThenHashCodesAreEqual()
    {
        // Arrange
        Property first = PropertyTestsData.Create();
        Property second = PropertyTestsData.Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Fact]
    public void GivenDifferentInstancesThenHashCodesAreNotEqual()
    {
        // Arrange
        Property first = PropertyTestsData.Create();
        Property second = PropertyTestsData.Create(name: "Other");

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}