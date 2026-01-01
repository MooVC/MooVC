namespace MooVC.Syntax.CSharp.Members.FieldTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualFieldsThenHashCodesAreEqual()
    {
        // Arrange
        Field first = FieldTestsData.Create();
        Field second = FieldTestsData.Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Fact]
    public void GivenDifferentFieldsThenHashCodesAreDifferent()
    {
        // Arrange
        Field first = FieldTestsData.Create();
        Field second = FieldTestsData.Create(isStatic: true);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}