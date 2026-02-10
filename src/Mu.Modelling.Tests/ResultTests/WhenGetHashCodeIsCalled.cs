namespace Mu.Modelling.ResultTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenSameValuesThenHashesMatch()
    {
        // Arrange
        Result left = ModellingTestData.CreateResult();
        Result right = ModellingTestData.CreateResult();

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
        Result left = ModellingTestData.CreateResult();
        Result right = ModellingTestData.CreateResult(name: ModellingTestData.CreateAlternateName());

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
        Result subject = ModellingTestData.CreateResult();

        // Act
        int firstHash = subject.GetHashCode();
        int secondHash = subject.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }
}