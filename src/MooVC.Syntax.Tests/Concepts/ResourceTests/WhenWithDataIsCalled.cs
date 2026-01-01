namespace MooVC.Syntax.Concepts.ResourceTests;

using System.Linq;
using MooVC.Syntax.Attributes.Resource;

public sealed class WhenWithDataIsCalled
{
    [Fact]
    public void GivenDataThenReturnsUpdatedInstance()
    {
        // Arrange
        Data existing = ResourceTestsData.CreateData();
        var additional = new Data { Name = "Other", Value = "Other" };
        Resource original = ResourceTestsData.Create(data: existing);

        // Act
        Resource result = original.WithData(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Data.ShouldBe(original.Data.Concat([additional]));
        result.Assemblies.ShouldBe(original.Assemblies);
    }
}