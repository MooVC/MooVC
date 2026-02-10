namespace Mu.Modelling.ViewTests;

public sealed class WhenInequalityOperatorViewViewIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        View left = ModellingTestData.CreateView();
        View right = ModellingTestData.CreateView(name: ModellingTestData.CreateAlternateName());

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
        View left = ModellingTestData.CreateView();
        View right = ModellingTestData.CreateView();

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}