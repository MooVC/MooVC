namespace MooVC.Syntax.Concepts.SolutionTests;

using System.Linq;
using MooVC.Syntax.Attributes.Solution;
using MooVC.Syntax.Elements;

public sealed class WhenWithPropertiesIsCalled
{
    [Fact]
    public void GivenPropertiesThenReturnsUpdatedInstance()
    {
        // Arrange
        Property existing = SolutionTestsData.CreateProperty();

        var additional = new Property
        {
            Name = "OtherName",
            Value = "OtherValue",
        };

        Solution original = SolutionTestsData.Create(property: existing);

        // Act
        Solution result = original.WithProperties(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Properties.ShouldBe(original.Properties.Concat([additional]));
        result.Configurations.ShouldBe(original.Configurations);
    }
}