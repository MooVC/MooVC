namespace MooVC.Syntax.CSharp.Attributes.Project.PropertyTests;

public sealed class WhenInequalityOperatorPropertyPropertyIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Property left = PropertyTestsData.Create();
        Property right = PropertyTestsData.Create(name: new Identifier("Other"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}