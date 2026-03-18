namespace MooVC.Syntax.CSharp.PropertyTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEquivalentInstancesThenHashCodesAreEqual()
    {
        // Arrange
        Property first = PropertyTestsData.Create();
        Property second = PropertyTestsData.Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentInstancesThenHashCodesAreNotEqual()
    {
        // Arrange
        Property first = PropertyTestsData.Create();
        Property second = PropertyTestsData.Create(name: "Other");

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }
}