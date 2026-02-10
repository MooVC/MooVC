namespace Mu.Modelling.UnitTests;

public sealed class WhenInequalityOperatorUnitUnitIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Unit left = ModellingTestData.CreateUnit();
        Unit right = ModellingTestData.CreateUnit(name: ModellingTestData.CreateAlternateName());

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
        Unit left = ModellingTestData.CreateUnit();
        Unit right = ModellingTestData.CreateUnit();

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}