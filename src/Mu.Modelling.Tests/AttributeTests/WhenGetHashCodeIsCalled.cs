namespace Mu.Modelling.AttributeTests;

using ModellingAttribute = Mu.Modelling.Attribute;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenSameValuesThenHashesMatch()
    {
        // Arrange
        ModellingAttribute left = ModellingTestData.CreateAttribute();
        ModellingAttribute right = ModellingTestData.CreateAttribute();

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
        ModellingAttribute left = ModellingTestData.CreateAttribute();
        ModellingAttribute right = ModellingTestData.CreateAttribute(name: ModellingTestData.CreateAlternateName());

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
        ModellingAttribute subject = ModellingTestData.CreateAttribute();

        // Act
        int firstHash = subject.GetHashCode();
        int secondHash = subject.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }
}