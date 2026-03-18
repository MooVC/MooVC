namespace MooVC.Syntax.Concepts.SolutionTests;

using MooVC.Syntax.Attributes.Solution;
using MooVC.Syntax.Elements;

public sealed class WhenWithPropertiesIsCalled
{
    [Test]
    public async Task GivenPropertiesThenReturnsUpdatedInstance()
    {
        // Arrange
        Property existing = SolutionTestsData.CreateProperty();

        var additional = new Property
        {
            Name = Snippet.From("OtherName"),
            Value = Snippet.From("OtherValue"),
        };

        Solution original = SolutionTestsData.Create(property: existing);

        // Act
        Solution result = original.WithProperties(additional);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Properties).IsEquivalentTo([.. original.Properties, additional]);
        _ = await Assert.That(result.Configurations).IsEqualTo(original.Configurations);
    }
}