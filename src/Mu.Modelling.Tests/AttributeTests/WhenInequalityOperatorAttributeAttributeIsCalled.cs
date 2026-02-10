namespace Mu.Modelling.AttributeTests;

using ModellingAttribute = Mu.Modelling.Attribute;

public sealed class WhenInequalityOperatorAttributeAttributeIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        ModellingAttribute left = ModellingTestData.CreateAttribute();
        ModellingAttribute right = ModellingTestData.CreateAttribute(name: ModellingTestData.CreateAlternateName());

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
        ModellingAttribute left = ModellingTestData.CreateAttribute();
        ModellingAttribute right = ModellingTestData.CreateAttribute();

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}