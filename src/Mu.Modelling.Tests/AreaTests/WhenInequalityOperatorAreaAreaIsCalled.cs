namespace Mu.Modelling.AreaTests;

public sealed class WhenInequalityOperatorAreaAreaIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Area left = ModellingTestData.CreateArea();
        Area right = ModellingTestData.CreateArea(name: ModellingTestData.CreateAlternateName());

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Area left = ModellingTestData.CreateArea();
        Area right = ModellingTestData.CreateArea();

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}