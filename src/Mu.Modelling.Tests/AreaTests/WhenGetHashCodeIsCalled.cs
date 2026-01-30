namespace Mu.Modelling.AreaTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenSameValuesThenHashesMatch()
    {
        // Arrange
        Area left = ModellingTestData.CreateArea();
        Area right = ModellingTestData.CreateArea();

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldBe(rightHash);
    }

    [Fact]
    public void GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        Area left = ModellingTestData.CreateArea();
        Area right = ModellingTestData.CreateArea(name: ModellingTestData.CreateAlternateName());

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }

    [Fact]
    public void GivenSameInstanceThenHashIsStable()
    {
        // Arrange
        Area subject = ModellingTestData.CreateArea();

        // Act
        int firstHash = subject.GetHashCode();
        int secondHash = subject.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }
}