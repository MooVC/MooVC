namespace MooVC.Syntax.Concepts.ResourceTests;

using System.Linq;
using MooVC.Syntax.Attributes.Resource;
using Resource = MooVC.Syntax.Concepts.Resource;

public sealed class WhenWithDataIsCalled
{
    [Test]
    public async Task GivenDataThenReturnsUpdatedInstance()
    {
        // Arrange
        Data existing = ResourceTestsData.CreateData();
        var additional = new Data { Name = "Other", Value = "Other" };
        Resource original = ResourceTestsData.Create(data: existing);

        // Act
        Resource result = original.WithData(additional);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Data).IsEqualTo(original.Data.Concat([additional]));
        _ = await Assert.That(result.Assemblies).IsEqualTo(original.Assemblies);
    }
}