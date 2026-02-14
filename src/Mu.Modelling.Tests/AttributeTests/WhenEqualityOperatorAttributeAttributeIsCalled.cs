namespace Mu.Modelling.AttributeTests;

using ModellingAttribute = Mu.Modelling.Attribute;

public sealed class WhenEqualityOperatorAttributeAttributeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        ModellingAttribute left = ModellingTestData.CreateAttribute();
        ModellingAttribute right = ModellingTestData.CreateAttribute();

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
        ModellingAttribute left = ModellingTestData.CreateAttribute();
        ModellingAttribute right = ModellingTestData.CreateAttribute(name: ModellingTestData.CreateAlternateName());

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}