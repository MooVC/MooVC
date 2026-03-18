namespace MooVC.Syntax.CSharp.Members.FieldTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEqualFieldsThenHashCodesAreEqual()
    {
        // Arrange
        Field first = FieldTestsData.Create();
        Field second = FieldTestsData.Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentFieldsThenHashCodesAreDifferent()
    {
        // Arrange
        Field first = FieldTestsData.Create();
        Field second = FieldTestsData.Create(isStatic: true);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }
}