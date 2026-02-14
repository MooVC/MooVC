namespace Mu.Modelling.FeatureTests;

public sealed class WhenEqualityOperatorFeatureFeatureIsCalled
{
    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Feature left = ModellingTestData.CreateFeature();
        Feature right = ModellingTestData.CreateFeature();

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Feature left = ModellingTestData.CreateFeature();
        Feature right = ModellingTestData.CreateFeature(name: ModellingTestData.CreateAlternateName());

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}